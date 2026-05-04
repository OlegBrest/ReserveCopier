using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReserveCopier
{
    public partial class MainReservCopyer : Form
    {
        int TotalDirs = 0;
        static int TotalFiles = 0;
        double TotalSize = 0;
        int log_rows = 0;
        static int currThreads = 0; // количество потоков для многопоточки
        int workMode = 0; // 0 - полное,1 - разностное по основному, 2 - разностное по последнему, 3 - обычное
        bool workReplaceOldFiles = false;
        string startButtonText = "Выполнить сейчас";
        bool deletebytimeinwork = false; //индикатор что удаление по времени запущено что бы не было многократных запусков удаления по времени
        public struct LogStr
        {
            public DateTime dtstr { get; set; }
            public string type { get; set; }
            public string mssg { get; set; }
        }
        DataTable dtLog = new DataTable();
        BindingSource logbs = new BindingSource();

        BindingList<LogStr> blistlog;
        List<LogStr> loglist;
        FormWindowState _windowState = FormWindowState.Normal;
        private bool MinimizeInTray = true;
        bool programmClose = false;

        //DataTable dtfiles = new DataTable();
        //bool MainDiffFileWrite = false; // индикатор записи полного файла
        /*        bool autostart = false; // индикатор выполнения автозапуска
                bool manualStart = false; // запуск по кнопке
                bool calctrdstarted = false; // запускался поток пересчёта
                bool copying = false; // в процессе копирования*/
        int step = 0; // шаги по выполнению 0 - ожидание , 1 - пересчёт файлов , 2 - запись индексов, 3 - запись файлов
        int currstep = 0; // текущий шаг (в начале функции)
        Thread trdfilecalc; // поток подсчёта файлов
        Thread trdfilecopy; // поток копирования файлов
        string current_path = "";
        double speedMbs = 0; // Скорость метров в сек
        double speedFiles = 0; // Скорость файлов в сек

        int ProgressValue = 0;
        string MainFileName = "";
        string MainFilePath = "";
        string DiffFileName = "";
        string DiffFilePath = "";

        FileData mainFiledata = new FileData();
        FileData diffFiledata = new FileData();
        FileData currFileData = new FileData();

        System.Timers.Timer InterfaceUpdateTimer = new System.Timers.Timer();
        System.Timers.Timer AutoCheckTimer = new System.Timers.Timer();


        //BindingList<LogStr> testBSL = new BindingList<LogStr>();
        BindingSource testbs = new BindingSource();
        List<string> dirsList = new List<string>();

        bool deleteOldFiles = false;
        int deletePeriodic = 1000;
        string deletePeriod = "Минут";
        bool inDeleting = false;
        SortableBindingList<FileInfo> reserveCopyes = new SortableBindingList<FileInfo>();

        bool delForFreeSpace = false;
        ulong delMinSize = 1000000000;
        DateTime oldestReserve = DateTime.MaxValue;

        public MainReservCopyer()
        {
            InitializeComponent();
            SetDoubleBuffered(dataGridViewprogress);
            SetDoubleBuffered(reserv_dgv);
            /*
            dtLog.Columns.Add("Время", typeof(DateTime));
            dtLog.Columns.Add("Cообщение", typeof(string));
            dtLog.BeginLoadData();
            logbs.DataSource = dtLog;
            dataGridViewprogress.DataSource = logbs;
            */
            loglist = new List<LogStr>();
            blistlog = new BindingList<LogStr>(loglist);
            logbs = new BindingSource(blistlog, null);
            dataGridViewprogress.DataSource = blistlog;

            //dataGridViewprogress.Columns.Add ("data", "Время");
            //dataGridViewprogress.Columns.Add("mssg", "Сообщение");
            //dataGridViewprogress.Columns["data"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss.fff";
            loglist.Capacity = 50000;
            dataGridViewprogress.Columns["dtstr"].HeaderText = "Время";
            dataGridViewprogress.Columns["type"].HeaderText = "Тип";
            dataGridViewprogress.Columns["mssg"].HeaderText = "Сообщение";
            dataGridViewprogress.Columns["dtstr"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss.fff";
            //  dataGridViewprogress.DataMember = "dtstr";


            InterfaceUpdateTimer.Elapsed += InterfaceUpdateTimer_Elapsed;
            InterfaceUpdateTimer.AutoReset = true;
            InterfaceUpdateTimer.Interval = 500;
            InterfaceUpdateTimer.Enabled = true;
            InterfaceUpdateTimer.Start();

            AutoCheckTimer.Elapsed += AutoCheckTimer_Elapsed;
            AutoCheckTimer.AutoReset = true;
            AutoCheckTimer.Interval = 30000;
            AutoCheckTimer.Enabled = Properties.Settings.Default.AutoStartCopy;
            if (autostart_chkbx.Checked) AutoCheckTimer.Start();
            else AutoCheckTimer.Stop();

            trdfilecalc = new Thread(CalcTotalFileDirsCount);
            trdfilecopy = new Thread(CopyFiles);
            //dtLog.Rows.Add(DateTime.Now, "52.Программа прошла инициализацию.");
            ReloadSettings();
            logg("Info","128.MainReservCopyer.Программа прошла инициализацию.");

            CheckPaths();

            reserv_dgv.AutoGenerateColumns = true;
            //testbs.DataSource = testBSL;
            //testbs.DataMember = "Lenght";
            /* test_dgv.Columns.Add("test", "Тест");
             test_dgv.Columns[0].DataPropertyName = "value";
             test_dgv.DataSource = testBSL;*/
            if (!RequestSeBackupPrivilege())
            {
                logg("Error","Cannot request privilege: ");
            }
            dirsList.Clear();
            notifyIcon.Visible = true;
            updateReserves();
            testbs.DataSource = reserveCopyes;
            reserv_dgv.DataSource = testbs;
        }

        #region автозапуск
        private void AutoCheckTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            uniinvoker.TryInvoke(this.autostart_chkbx, () =>
            {
                if (this.autostart_chkbx.BackColor == Color.LightPink)
                {
                    this.autostart_chkbx.BackColor = Color.LightGreen;
                }
                else
                {
                    this.autostart_chkbx.BackColor = Color.LightPink;
                }
            });
            DateTime dateNow = DateTime.Now;
            string dayofweek = Properties.Settings.Default.DayOfWeekCheck;
            int HourAdd = (int)Properties.Settings.Default.periodicHours;
            int MinutsAdd = (int)Properties.Settings.Default.PeriodicMinutes;
            DateTime nextdiffevent = Properties.Settings.Default.LastDiffTime.AddHours(HourAdd).AddMinutes(MinutsAdd);
            string FullWriteMode = Properties.Settings.Default.FullCopyPeriodic;
            DateTime nextfullevent = Properties.Settings.Default.LastFullTime;
            switch (FullWriteMode)
            {
                case "Ежедневно":
                    nextfullevent = nextfullevent.AddDays(1);
                    break;
                case "Еженедельно":
                    nextfullevent = nextfullevent.AddDays(7);
                    break;
                case "Ежемесячно":
                    nextfullevent = nextfullevent.AddMonths(1);
                    break;
                case "Ежегодно":
                    nextfullevent = nextfullevent.AddYears(1);
                    break;
            }
            // проверим потоки
            //if ((!trdfilecalc.IsAlive) && (!trdfilecopy.IsAlive) && !autostart && !calctrdstarted && !copying)
            if ((!trdfilecalc.IsAlive) && (!trdfilecopy.IsAlive) && (step == 0) && (currstep == 0))
            {
                try
                {
                    // проверим день недели
                    if (dayofweek.Contains(dateNow.DayOfWeek.ToString()))
                    {
                        if (workMode==0 || workMode==3)
                        {
                            if (dateNow > nextfullevent)
                            {
                                // autostart = true;
                                start_bttn_Click(start_bttn, new EventArgs());
                            }
                        }
                        else
                        {
                            //и время 
                            if (dateNow > nextdiffevent)
                            {
                                // autostart = true;
                                start_bttn_Click(start_bttn, new EventArgs());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //dtLog.Rows.Add(DateTime.Now, "169.Ошибка : " + ex.Message);
                    step = 0;
                    currstep = 0;
                    logg("Error", "215.AutoCheckTimer_Elapsed : " + ex.Message);

                    //autostart = false;
                    //InterfaceUpdateTimer_Tick();
                }
            }
        }
        #endregion
        private void StartDeleteOldFiles()
        {
            DateTime DateToDelete = DateTime.Now;
            switch (deletePeriod)
            {
                case "Минут":
                    DateToDelete = DateTime.Now.AddMinutes(-deletePeriodic); break;
                case "Часов":
                    DateToDelete = DateTime.Now.AddHours(-deletePeriodic); break;
                case "Дней":
                    DateToDelete = DateTime.Now.AddDays(-deletePeriodic); break;
                case "Недель":
                    DateToDelete = DateTime.Now.AddDays(-deletePeriodic * 7); break;
                case "Месяцев":
                    DateToDelete = DateTime.Now.AddMonths(-deletePeriodic); break;
            }
            DirectoryInfo scanPath = new DirectoryInfo(Properties.Settings.Default.OutputPath);
            updateReserves(DateToDelete);

            // удаляем пустые папки
            DeleteEmptyDirs(scanPath);
        }

        private void GetReserveCopyes(string[] KeyFilesName, DirectoryInfo startDir, bool restOldest)
        {
            if (restOldest) oldestReserve = DateTime.Now;
            if (!startDir.Exists) Directory.CreateDirectory(startDir.FullName);
            List<FileInfo> files = new List<FileInfo>();
            lock (testbs) ;
            foreach (string name in KeyFilesName)
            {
                files.AddRange(startDir.GetFiles(name, SearchOption.TopDirectoryOnly));
            }
            if (files.Count > 0)
            {
                foreach (FileInfo fi in files)
                {
                    if (fi.Exists)
                    {
                        try
                        {
                            reserveCopyes.Add(fi);
                            if (fi.LastWriteTime < oldestReserve) oldestReserve = fi.LastWriteTime;
                        }
                        catch (Exception ex)
                        {
                            logg("Error", "271.MainForm.GetReserveCopyes. " + ex.Message);
                        }
                    }
                }
            }
            else
            {

                DirectoryInfo[] dirs = null;
                try
                {
                    if (Directory.Exists(startDir.FullName))
                    {
                        dirs = startDir.GetDirectories("*", SearchOption.TopDirectoryOnly);
                    }
                }
                catch (Exception ex)
                {
                    logg("Error", "291.GetReserveCopyes" + ex.Message);
                    logg("Error", "291.GetReserveCopyes" + startDir.FullName);
                }
                if (dirs != null)
                {
                    foreach (DirectoryInfo dir in dirs)
                    {
                        files.Clear();
                        foreach (string name in KeyFilesName)
                        {
                            files.AddRange(startDir.GetFiles(name, SearchOption.TopDirectoryOnly));
                        }
                        if (files.Count > 0)
                        {
                            foreach (FileInfo fi in files)
                            {
                                if (fi.Exists)
                                {
                                    reserveCopyes.Add(fi);
                                    if (fi.LastWriteTime < oldestReserve) oldestReserve = fi.LastWriteTime;
                                }
                            }
                        }
                        else
                        {
                            GetReserveCopyes(KeyFilesName, dir, false);
                        }
                    }
                }
                testbs.EndEdit();
            }
        }
        private bool reserveDeleter(DateTime timeToDelete)
        {
            bool wasdeleted = false;
            if (reserveCopyes.Count > 0)
            {
                try
                {
                    foreach (FileInfo fi in reserveCopyes)
                    {
                        if (fi.Exists)
                        {
                            try
                            {
                                if (fi.LastWriteTime <= timeToDelete)
                                {
                                    wasdeleted = reserveDeleter(fi);
                                }
                            }
                            catch (Exception ex)
                            {
                                logg("Error", "315.reserveDeleter. : " + ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    logg("Error", "353.reserveDeleter. : " + ex.Message);
                }
            }
            deletebytimeinwork = false;
            return wasdeleted;
        }

        private bool reserveDeleter(FileInfo fileInfo)
        {
            bool wasdeleted = false;

            if (fileInfo.Exists)
            {
                try
                {
                    logg("Info", "328.reserveDeleter. Удаляю файлы из " + fileInfo.DirectoryName);
                    DirectoryInfo di = new DirectoryInfo(fileInfo.DirectoryName);
                    DirectoryInfo[] diffdirs = di.GetDirectories("*", SearchOption.TopDirectoryOnly);
                    if (diffdirs.Length > 10) logg("Info", "347. Удаляю " + diffdirs.Count().ToString() + " каталогов в " + di.FullName);
                    foreach (DirectoryInfo dir in diffdirs)
                    {
                        try
                        {
                            //logg("Info", "335.reserveDeleter. Удаляю не пустые каталоги и файлы из " + dir.FullName);
                            if (Directory.Exists(dir.FullName))
                            {
                                wasdeleted = DeleteNonEmptyDirs(dir);
                            }
                        }
                        catch (Exception ex)
                        {
                            logg("Error", "340.reserveDeleter. : " + ex.Message);
                        }
                        try
                        {
                            //logg("Info", "344.reserveDeleter. Удаляю файлы из " + dir.FullName);
                            wasdeleted = DeleteEmptyDirs(dir);
                        }
                        catch (Exception ex)
                        {
                            logg("Error", "349.reserveDeleter. : " + ex.Message);
                        }

                    }
                    if (diffdirs.Length > 10) logg("Info", "370. Удаляю " + diffdirs.Count().ToString() + " каталогов в " + di.FullName);
                    diffdirs = di.GetDirectories("*", SearchOption.TopDirectoryOnly);
                    if (diffdirs.Length == 0) Directory.Delete(fileInfo.DirectoryName, true);
                }
                catch (Exception ex)
                {
                    logg("Error", "286.reserveDeleter. :" + ex.Message);
                }
            }
            return wasdeleted;
        }

        private bool DeleteNonEmptyDirs(DirectoryInfo _dir)
        {
            bool wasdeleted = false;
            _dir.Attributes &= ~FileAttributes.ReadOnly;
            FileInfo[] files = _dir.GetFiles();
            foreach (FileInfo file in files)
            {
                try
                {
                    if (file.Exists)
                    {
                        FileSecurity security = new FileSecurity(file.FullName,
                AccessControlSections.Owner |
                AccessControlSections.Group |
                AccessControlSections.Access);
                        IdentityReference owner = security.GetOwner(typeof(NTAccount));
                        security.ModifyAccessRule(AccessControlModification.Set,
    new FileSystemAccessRule(owner, FileSystemRights.FullControl, AccessControlType.Allow),
    out bool modified);
                    }
                    file.Attributes &= ~FileAttributes.ReadOnly;
                    File.Delete(file.FullName);
                    wasdeleted = true;
                    //file.Delete();
                }
                catch (Exception ex)
                {
                    logg("Error", "388.DeleteNonEmptyDirs. : " + ex.Message);
                    logg("Error", "388.DeleteNonEmptyDirs. : " + file.FullName);
                }
            }
            DirectoryInfo[] diffdirs = _dir.GetDirectories("*", SearchOption.TopDirectoryOnly);
            if (diffdirs.Length>10) logg("Info","411. Удаляю " + diffdirs.Count().ToString() + " каталогов в " + _dir.FullName);
            foreach (DirectoryInfo dir in diffdirs)
            {
                current_path = dir.FullName;
                try
                {
                    //logg("Info","396. Удаляю не пустые каталоги и файлы из " + dir.FullName);
                    wasdeleted = DeleteNonEmptyDirs(dir);
                }
                catch (Exception ex)
                {
                    logg("Error", "400.DeleteNonEmptyDirs. : " + ex.Message);
                    logg("Error", "400.DeleteNonEmptyDirs. : " + dir.FullName);
                }

                try
                {

                    //logg("Info", "407. Удаляю пустые каталоги из " + dir.FullName);
                    wasdeleted = DeleteEmptyDirs(dir);
                }
                catch (Exception ex)
                {
                    logg("Error", "412.DeleteNonEmptyDirs. : " + ex.Message);
                    logg("Error", "412.DeleteNonEmptyDirs. : " + dir.FullName);
                }
            }
            if (diffdirs.Length > 10) logg("Info", "435.Обработано " + diffdirs.Count().ToString() + " каталогов в " + _dir.FullName);
            return wasdeleted;
        }

        private bool DeleteEmptyDirs(DirectoryInfo dir)
        {
            bool wasdeleted = false;
            if (dir.Exists)
            {
                DirectoryInfo[] directoryInfo = dir.GetDirectories();
                FileInfo[] fileInfos = dir.GetFiles();
                if (fileInfos.Length == 0)
                {
                    if (directoryInfo.Length == 0)
                    {
                        try
                        {
                            dir.Attributes &= ~FileAttributes.ReadOnly;
                        }
                        catch (Exception ex) 
                        {
                            logg("Error", "459.DeleteEmptyDirs. : " + ex.Message + " " + dir.FullName);
                        }
                        try
                        {
                            dir.Delete();
                            wasdeleted = true;
                        }
                        catch (Exception ex)
                        {
                            logg("Error", "468.DeleteEmptyDirs. : " + ex.Message + " " + dir.FullName);
                        }
                    }
                    else
                    {
                        foreach (DirectoryInfo _dir in directoryInfo)
                        {
                            DeleteEmptyDirs(_dir);
                        }
                    }
                }
                else return true;
            }
            return wasdeleted;
        }

        /// <summary>
        /// Установить двойной буфер для отрисовки , что бы не тормозило
        /// </summary>
        /// <param name="c">Контрол</param>
        /// <param name="value">true - разрешить , false - отменить</param>
        public void SetDoubleBuffered(Control c, bool value = true)
        {
            PropertyInfo pi = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic);
            if (pi != null)
            {
                pi.SetValue(c, value, null);
                MethodInfo mi = typeof(Control).GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.NonPublic);
                if (mi != null)
                {
                    mi.Invoke(c, new object[] { ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true });
                }
                mi = typeof(Control).GetMethod("UpdateStyles", BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.NonPublic);
                if (mi != null)
                {
                    mi.Invoke(c, null);
                }
            }
        }


        private void InterfaceUpdateTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            InterfaceUpdateTimer_Tick();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingForm sf = new SettingForm();
            DialogResult dr = sf.ShowDialog();
            ReloadSettings();
        }

        private void ReloadSettings()
        {
            logg("Info","238.Перезагружаю настройки");
            deleteOldFiles = Properties.Settings.Default.DeleteOld;
            deletePeriodic = (int)Properties.Settings.Default.DelPeriodNum;
            deletePeriod = Properties.Settings.Default.DelPeriodStr;
            MinimizeInTray = Properties.Settings.Default.MinimizeInTray;
            workReplaceOldFiles = Properties.Settings.Default.ReplaceOldFiles;
            string Mode = Properties.Settings.Default.CopyModeValue;
            switch (Mode)
            {
                case "Полное":
                    workMode = 0;
                    break;
                case "Разностное относительно первой копии":
                    workMode = 1;
                    break;
                case "Разностное относительно последней копии":
                    workMode = 2;
                    break;
                case "Обычное без разделения по датам":
                    workMode = 3;
                    break;
            }

            double multiplier = 1;
            string sizeType = Properties.Settings.Default.ClearForFreeSpaceSize;
            switch (sizeType)
            {
                case "Kb":
                    multiplier = Math.Pow(1024, 1); break;
                case "Mb":
                    multiplier = Math.Pow(1024, 2); break;
                case "Gb":
                    multiplier = Math.Pow(1024, 3); break;
                case "Tb":
                    multiplier = Math.Pow(1024, 4); break;
            }
            delMinSize = (ulong)((double)Properties.Settings.Default.ClearForFreeSpaceValue * multiplier);
            delForFreeSpace = Properties.Settings.Default.ClearForFreeSpaceCheck;
            inDeleting = false;
        }

        private void start_bttn_Click(object sender, EventArgs e)
        {
            // if ((!trdfilecopy.IsAlive) && (!trdfilecalc.IsAlive) && (!manualStart || autostart) && !calctrdstarted && !copying)
            if ((!trdfilecopy.IsAlive) && (!trdfilecalc.IsAlive) && (step == 0) && (currstep == 0))
            {
                step = 1;
                logg("Info","467.step = 1");
                if (deleteOldFiles && !inDeleting)
                {
                    inDeleting = true;
                    StartDeleteOldFiles();
                    inDeleting = false;
                }
                CheckPaths();
                TotalDirs = 0;
                TotalFiles = 0;
                TotalSize = 0;
                //dtfiles.Rows.Clear();
                mainFiledata.Clear();
                currFileData.Clear();
                diffFiledata.Clear();
                dirsList.Clear();
                string[] Paths = Properties.Settings.Default.InputPaths.Split('\n');
                trdfilecalc = new Thread(CalcTotalFileDirsCount);
                trdfilecalc.Start(Paths);
                currstep = 1;
                step = 0;
                logg("Info","488.currstep = 1;step = 0");
                //calctrdstarted = true;
            }
            else if (trdfilecopy.IsAlive || trdfilecalc.IsAlive) 
            {
                if (trdfilecopy.IsAlive) trdfilecopy.Abort();
                if (trdfilecalc.IsAlive) trdfilecalc.Abort();
                step = 0;
                currstep = 0;
            }
            //manualStart = true;
            //InterfaceUpdateTimer_Tick();
        }

        private void CalcTotalFileDirsCount(object _Paths)
        {
            string[] Paths = (string[])_Paths;
            //Параллельность портит данные по размерам файлов
            //Parallel.ForEach(Paths, path =>
            foreach (string path in Paths)
            {
                checkForDirFile(path);
            }//);
        }

        /// <summary>
        /// Запись в основной файл данных о файлах и каталогах
        /// </summary>
        /// <param name="extpath"></param>
        private void checkForDirFile(string extpath)
        {
            DirectoryInfo dirinfo = null;
            try
            {
                dirinfo = new DirectoryInfo(new DirectoryInfo(extpath).GetSymbolicLinkTarget());
            }
            catch (Exception e) 
            {
                logg("Error","600.Mainform.checkForDirFile. : " + e.Message + " \"" + extpath+"\"");
            }
            if (dirinfo != null)
            {
                string path = dirinfo.FullName;
                if (File.Exists(path))
                {
                    if (path.Length < 32567)
                    {
                        current_path = path;
                        TotalFiles++;
                        FileInfo fi = new FileInfo(path);
                        long length = fi.Length;
                        long chgtime = fi.LastWriteTime.Ticks;
                        TotalSize += length;
                        currFileData.AddRow("FILE", path, length, chgtime);
                    }
                    else
                    {
                        logg("Error", "271.Mainform.checkForDirFile. : Слишком длинный путь " + path);
                    }
                }
                else
                {
                    if (!dirsList.Contains(path) && Directory.Exists(path))
                    {
                        dirsList.Add(path);
                        TotalDirs++;
                        try
                        {
                            string[] dirs = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);
                            CalcTotalFileDirsCount(dirs);
                            try
                            {
                                string[] files = Directory.GetFiles(path);
                                if (files.Count() == 0) currFileData.AddRow("DIR", path, 0, 0);
                                CalcTotalFileDirsCount(files);
                            }
                            catch (Exception ex)
                            {
                                logg("Error", "265.Mainform.checkForDirFile. : " + ex.Message);
                                logg("Error", path);
                            }
                        }
                        catch (Exception ex)
                        {
                            logg("Error", "273.Mainform.checkForDirFile. : " + ex.Message);
                            logg("Error", path);
                        }
                    }
                }
            }
        }

        private void InterfaceUpdateTimer_Tick()
        {
            if (DirLabel.InvokeRequired)
            {
                DirLabel.BeginInvoke(new Action(updateDirLabel));
            }
            else updateDirLabel();
            if (FileLabel.InvokeRequired)
            {
                FileLabel.BeginInvoke(new Action(updateFileLabel));
            }
            else updateFileLabel();
            if (SizeLabel.InvokeRequired)
            {
                SizeLabel.BeginInvoke(new Action(updateSizeLabel));
            }
            else updateSizeLabel();
            if (SpeedLabel.InvokeRequired)
            {
                SpeedLabel.BeginInvoke(new Action(updateSpeedLabel));
            }
            else updateSpeedLabel();
            if (Path_txtBx.InvokeRequired)
            {
                Path_txtBx.BeginInvoke(new Action(updatePathTxtBx));
            }
            else updatePathTxtBx();
            if (dataGridViewprogress.InvokeRequired)
            {
                dataGridViewprogress.BeginInvoke(new Action(updateProgressView));
            }
            else updateProgressView();
            if (progressBar.InvokeRequired)
            {
                progressBar.BeginInvoke(new Action(updateProgressBar));
            }
            else updateProgressBar();

            // запишем файл
            if ((!trdfilecalc.IsAlive) && (currstep == 1) && (step == 0))
            {
                step = 1;
                logg("Info", "611.step = 1");
            }
            
            //if (!trdfilecalc.IsAlive && !trdfilecopy.IsAlive && (manualStart || autostart) && !copying)
            if (!trdfilecalc.IsAlive && !trdfilecopy.IsAlive && (step != 0) && (currstep != 0))
            {
                
                
                /* if (calctrdstarted)
                 {
                     manualStart = false;
                     autostart = false;
                     calctrdstarted = false;*/
                if ((step == 1) && (currstep == 1)) WriteIndexFiles(workMode);
                if ((step == 2) && (currstep == 2))
                {
                    currstep = 3;
                    logg("Info", "639.currstep = 3");
                    trdfilecopy = new Thread(CopyFiles);
                    trdfilecopy.Start(workMode);
                }
                //}
            }
            else if ((trdfilecalc.IsAlive || trdfilecopy.IsAlive) && (startButtonText != "Остановить"))
            {
                startButtonText = "Остановить";
                uniinvoker.TryInvoke(start_bttn, () =>
                {
                    start_bttn.Text = startButtonText;
                });
            }
            if (!trdfilecalc.IsAlive && !trdfilecopy.IsAlive && (startButtonText != "Выполнить сейчас"))
            {
                startButtonText = "Выполнить сейчас";
                uniinvoker.TryInvoke(start_bttn, () =>
                {
                    start_bttn.Text = startButtonText;
                    ProgressValue = 0;
                });
            }
        }
        #region асинхронные методы
        private void updateDirLabel()
        {
            DirLabel.Text = TotalDirs.ToString();
            DirLabel.Update();
        }
        private void updateFileLabel()
        {
            FileLabel.Text = TotalFiles.ToString();
            FileLabel.Update();
        }
        private void updateSizeLabel()
        {
            double displ_size = TotalSize;
            string bytes = " Байт";
            if (displ_size > 1000000)
            {
                displ_size /= 1024;
                bytes = " Кб";
            }
            if (displ_size > 1000000)
            {
                displ_size /= 1024;
                bytes = " Мб";
            }
            if (displ_size > 1000000)
            {
                displ_size /= 1024;
                bytes = " Гб";
            }
            if (displ_size > 1000000)
            {
                displ_size /= 1024;
                bytes = " Тб";
            }
            SizeLabel.Text = String.Format("{0,2:N2}{1}", displ_size, bytes);
            SizeLabel.Update();
        }
        private void updateSpeedLabel()
        {
            SpeedLabel.Text = String.Format("{0:N2} Мб/с, {1:N2} Ф/с", speedMbs, speedFiles);
            SpeedLabel.Update();
        }
        private void updatePathTxtBx()
        {
            Path_txtBx.Text = current_path;
            Path_txtBx.Update();
        }
        private void updateProgressView()
        {
            if (log_rows != blistlog.Count) //dtLog.Rows.Count)
            {
                /*if (dtLog.Rows.Count > 200)
                {
                    int rws2del = (dtLog.Rows.Count - 200);
                    for (int i = 0; i < rws2del; i++)
                    {
                        dtLog.Rows[0].Delete();
                    }
                }*/
                if (blistlog.Count > 2000)
                {
                    int rws2del = (blistlog.Count - 2000);
                    for (int i = 0; i < rws2del; i++)
                    {
                        blistlog.RemoveAt(0);
                    }
                }

                //dtLog.EndLoadData();
                try
                {
                    /* bs.RaiseListChangedEvents = true;
                     bs.ResetBindings(false);
                     bs.RaiseListChangedEvents = false;*/
                    blistlog.RaiseListChangedEvents = true;
                    blistlog.ResetBindings();
                    blistlog.RaiseListChangedEvents = false;
                }
                catch (Exception ex)
                {
                    if (!ex.Message.Equals("Заданный аргумент находится вне диапазона допустимых значений.\r\nИмя параметра: rowIndex"))
                        logg("Error", "226.MainForm. " + ex.Message,true);
                    //dtLog.Rows.Add(DateTime.Now, "408.Ошибка." + ex.Message);
                    logg("Error", "433.updateProgressView. : " + ex.Message);
                }
                int firstRow = dataGridViewprogress.FirstDisplayedScrollingRowIndex;
                log_rows = blistlog.Count;//dtLog.Rows.Count;
                if (dataGridViewprogress.Rows.Count > 0)
                {
                    if (firstRow >= 0) dataGridViewprogress.FirstDisplayedScrollingRowIndex = firstRow;
                    if (Properties.Settings.Default.AutoScroolLog)
                    {
                        int lastvisrow = dataGridViewprogress.Rows.GetLastRow(DataGridViewElementStates.Visible);
                        int lastdisprow = dataGridViewprogress.Rows.GetLastRow(DataGridViewElementStates.Displayed);
                        if ((lastvisrow != lastdisprow) && (lastdisprow > 0))
                        {
                            firstRow += (lastvisrow - lastdisprow);
                            if (firstRow >= 0) dataGridViewprogress.FirstDisplayedScrollingRowIndex = firstRow;
                        }
                    }
                }
                dataGridViewprogress.Update();
                //dtLog.BeginLoadData();
            }

        }
        private void updateProgressBar()
        {

            if (ProgressValue <= 0 || ProgressValue >= 100)
            {
                if (progressBar.Visible == true)
                    progressBar.Visible = false;
            }
            else
            {
                if (ProgressValue > progressBar.Maximum) ProgressValue = progressBar.Maximum;
                if (ProgressValue < progressBar.Minimum) ProgressValue = progressBar.Minimum;
                progressBar.Visible = true;
                progressBar.Value = ProgressValue;
                progressBar.Update();
            }
        }

        #endregion

        private void dataGridViewprogress_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            logg("Error", "876.dataGridViewprogress_DataError. " + e.ToString(),true);
        }

        private void CheckPaths()
        {
            //dtLog.Rows.Add(DateTime.Now, "229.Перепроверю пути сохранения файлов");
            logg("Info", "813.CheckPaths.Перепроверю пути сохранения файлов");
            //InterfaceUpdateTimer_Tick();
            DateTime dt1 = DateTime.Now;
            string CreateDiffDay = dt1.Year + "\\" + dt1.Month + "\\" + dt1.Day + "\\" + dt1.Hour + "." + dt1.Minute;
            GregorianCalendar cal = new GregorianCalendar();
            string CreateFullPriodicName = "";
            string FullWriteMode = Properties.Settings.Default.FullCopyPeriodic;

            switch (FullWriteMode)
            {
                case "Ежедневно":
                    CreateFullPriodicName = dt1.Year + "\\" + dt1.Month + "\\d" + dt1.Day;
                    break;
                case "Еженедельно":
                    CreateFullPriodicName = dt1.Year + "\\w" + cal.GetWeekOfYear(dt1, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                    break;
                case "Ежемесячно":
                    CreateFullPriodicName = dt1.Year + "\\m" + dt1.Month;
                    break;
                case "Ежегодно":
                    CreateFullPriodicName = dt1.Year.ToString();
                    break;
            }
            if (workMode == 0) CreateFullPriodicName = dt1.Year + "\\" + dt1.Month + "\\" + dt1.Day + "\\" + dt1.Hour;
            MainFilePath = Properties.Settings.Default.OutputPath + "\\" + CreateFullPriodicName + "\\";
            if (workMode == 3) MainFilePath = Properties.Settings.Default.OutputPath + "\\";
            MainFileName = MainFilePath + "MAINFULL.txt";
            DiffFilePath = Properties.Settings.Default.OutputPath + "\\" + CreateDiffDay + "\\";
            DiffFileName = DiffFilePath + "DIFFILE.txt";
            //dtLog.Rows.Add(DateTime.Now, MainFileName);
            //dtLog.Rows.Add(DateTime.Now, DiffFileName);
            logg("Info", MainFileName);
            logg("Info", DiffFileName);
            //InterfaceUpdateTimer_Tick();

        }

        private void WriteIndexFiles(int mode)
        {
            //writingindexes = true;
            currstep = 2;
            logg("Info", "822.currstep = 2");
            string[] currlines = new string[currFileData.Count];
            currFileData.ToStringArray(ref currlines);
            if (!Directory.Exists(MainFilePath)) Directory.CreateDirectory(MainFilePath);
            if (File.Exists(MainFileName) || workMode == 3)
            {
                // создаём полный файл полного копирования
                if (mode == 0 || mode == 3)
                {
                    //dtLog.Rows.Add(DateTime.Now, "337.Записываю основной файл поверх старого." + currlines.Length + " записей.");
                    logg("Info", "534.Записываю основной файл поверх старого." + currlines.Length + " записей.");
                    //InterfaceUpdateTimer_Tick();
                    File.Delete(MainFileName);
                    File.WriteAllLines(MainFileName, currlines);
                }
                // если нет полного файла то создаём , если есть то создаём новый разностный DIFFILE не изменяя MAINFULL
                else if (mode != 0 && mode!=3)
                {
                    #region заливаем предыдущий ДТ для сравнения
                    //dtLog.Rows.Add(DateTime.Now, "499.Читаю основной файл для последующего сравнения.");
                    logg("Info", "544.Читаю основной файл индексов для последующего сравнения.");
                    //InterfaceUpdateTimer_Tick();
                    mainFiledata.Clear();
                    string[] mainlines = File.ReadAllLines(MainFileName);
                    mainFiledata.InsertFromStrArr(mainlines, "");
                    //dtLog.Rows.Add(DateTime.Now, "504.Прочитан основной файл. Найдено " + mainFiledata.Count + " строк");
                    logg("Info", "550.Прочитан основной файл индексов. Найдено " + mainFiledata.Count + " строк");
                    #endregion
                    #region сравниваем и создаём ДТ разности для этого в разностный льём обе таблицы и вычленяем оттуда одинаковые строки
                    diffFiledata.Clear();
                    //dtLog.Rows.Add(DateTime.Now, "508.Заполняю кэш сравнения данными основного файла.");
                    logg("Info", "555.Заполняю кэш сравнения данными основного файла индексов.");
                    diffFiledata.InsertFromFD(mainFiledata, "d");
                    //dtLog.Rows.Add(DateTime.Now, "510.Заполняю кэш сравнения данными текущих файлов.");
                    logg("Info", "558.Заполняю кэш сравнения данными текущих файлов.");
                    diffFiledata.InsertFromFD(currFileData, "i");
                    //dtLog.Rows.Add(DateTime.Now, "512.Кэш сравнения заполнен на " + diffFiledata.Count + " строк.");
                    logg("Info", "561.Кэш сравнения заполнен на " + diffFiledata.Count + " строк.");
                    //dtLog.Rows.Add(DateTime.Now, "513.Приступаю к поиску и удалению дубликатов");
                    logg("Info", "563.Приступаю к поиску и удалению дубликатов");
                    diffFiledata.FindAndClearDuplicates();
                    //dtLog.Rows.Add(DateTime.Now, "515.Дубликаты удалены. Получилось " + diffFiledata.Count + " отличий.");
                    logg("Info", "566.Дубликаты удалены. Получилось " + diffFiledata.Count + " отличий.");
                    string[] difflines = new string[0];
                    diffFiledata.ToStringArray(ref difflines);
                    //dtLog.Rows.Add(DateTime.Now, "518.Записываю файл отличий.");
                    logg("Info", "570.Записываю файл индексов отличий.");
                    //InterfaceUpdateTimer_Tick();
                    if (difflines.Count() > 0)
                    {
                        if (!Directory.Exists(DiffFilePath)) Directory.CreateDirectory(DiffFilePath);
                        File.WriteAllLines(DiffFileName, difflines);
                        Properties.Settings.Default.LastDiffPath = DiffFilePath;
                    }
                    else
                    {
                        logg("Info", "931.Различий не найдено! Файл разностей записан не будет!");
                    }
                    if (mode == 2)
                    {
                        // и перезапишем основной файл
                        // если нет полного файла то создаём , если есть то создаём новый разностный DIFFILE после заменяя MAINFULL
                        File.Delete(MainFileName);
                        currFileData.ToStringArray(ref currlines);
                        //dtLog.Rows.Add(DateTime.Now, "514.Перезаписываю основной файл новыми данными." + currFileData.Count + " записей.");
                        logg("Info", "580.Перезаписываю основной файл индексов новыми данными." + currFileData.Count + " записей.");
                        // InterfaceUpdateTimer_Tick();
                        File.WriteAllLines(MainFileName, currlines);
                    }
                    Properties.Settings.Default.LastDiffTime = DateTime.Now;
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();
                    #endregion
                }
            }
            else
            {
                //dtLog.Rows.Add(DateTime.Now, "499.Записываю основной файл.");
                logg("Info", "595.Записываю основной файл индексов.");
                //InterfaceUpdateTimer_Tick();
                File.WriteAllLines(MainFileName, currlines);
                Properties.Settings.Default.LastFullTime = DateTime.MinValue;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }
            step = 2;
            logg("Info", "901.step = 2");
        }

        private void CopyFiles(object mode)
        {
            TotalFiles = 0;
            TotalDirs = 0;
            //copying = true;
            int modeint = (int)mode;
            // делаем полную копию
            if (modeint == 0 || modeint == 3)
            {
                if (File.Exists(MainFileName))
                {
                    mainFiledata.Clear();
                    mainFiledata.InsertFromStrArr(File.ReadAllLines(MainFileName));
                    TotalSize = mainFiledata.GetTotalSize();

                    CopyFromDataFileToDisk(mainFiledata, true, modeint,workReplaceOldFiles);

                    Properties.Settings.Default.LastFullTime = DateTime.Now;
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();
                }
                else
                {
                    //dtLog.Rows.Add(DateTime.Now, "381.Ошибка : Не найден основной файл-список.");
                    logg("Error", "673.CopyFiles. : Не найден основной файл-список.");
                    //InterfaceUpdateTimer_Tick();
                }
            }
            // делаем разностную 
            if (modeint != 0 && modeint != 3)
            {
                DateTime lastfulldateTime = Properties.Settings.Default.LastFullTime;
                bool need2fulldate = false;
                string FullWriteMode = Properties.Settings.Default.FullCopyPeriodic;
                switch (FullWriteMode)
                {
                    case "Ежедневно":
                        if (DateTime.Now > lastfulldateTime.AddDays(1)) need2fulldate = true;
                        break;
                    case "Еженедельно":
                        if (DateTime.Now > lastfulldateTime.AddDays(7)) need2fulldate = true;
                        break;
                    case "Ежемесячно":
                        if (DateTime.Now > lastfulldateTime.AddMonths(1)) need2fulldate = true;
                        break;
                    case "Ежегодно":
                        if (DateTime.Now > lastfulldateTime.AddYears(1)) need2fulldate = true;
                        break;
                }

                if (File.Exists(MainFileName) && need2fulldate)
                {
                    mainFiledata.Clear();
                    mainFiledata.InsertFromStrArr(File.ReadAllLines(MainFileName));
                    TotalSize = mainFiledata.GetTotalSize();
                    DateTime startCopyTime = DateTime.Now;
                    CopyFromDataFileToDisk(mainFiledata, true, modeint, workReplaceOldFiles);
                    TimeSpan CopyTime = (DateTime.Now - startCopyTime);
                    //dtLog.Rows.Add(DateTime.Now, "595.Скопированы основные файлы." + mainFiledata.Count + " файлов");
                    logg("Info","757.Скопированы основные файлы." + mainFiledata.Count + " файлов за " + CopyTime.TotalSeconds + " сек.");
                    //InterfaceUpdateTimer_Tick();
                    Properties.Settings.Default.LastFullTime = DateTime.Now;
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();
                }
                else if (!File.Exists(MainFileName))
                {
                    //dtLog.Rows.Add(DateTime.Now, "596.Ошибка : Не найден основной файл-список.");
                    logg("Error", "766.CopyFiles. : Не найден основной файл-список.");
                    //InterfaceUpdateTimer_Tick();
                }
                if (File.Exists(DiffFileName))
                {
                    diffFiledata.Clear();
                    diffFiledata.InsertFromStrArr(File.ReadAllLines(DiffFileName));
                    TotalSize = diffFiledata.GetTotalSize();
                    TotalFiles = diffFiledata.Files.Count;
                    logg("Info", "784.Копирую файлы отличия.");

                    CopyFromDataFileToDisk(diffFiledata, false, modeint);
                    long currsize = 0;
                    DateTime starttime = DateTime.Now;
                    int speedfiles = TotalFiles;
                    double speedSize = TotalSize;
                    double lastsize = 0;
                    int lastFiles = TotalFiles;
                    speedMbs = 0;
                    speedFiles = 0;
                    //dtLog.Rows.Add(DateTime.Now, "621.Копирую файлы отличия.");

                    //InterfaceUpdateTimer_Tick();
                    foreach (FileData.FileStruct fs in diffFiledata.Files)
                    {
                        if (File.Exists(fs.FileFullName) && !fs.FileState.Equals("d"))
                        {
                            FileInfo fi = new FileInfo(fs.FileFullName);
                            string filename = fi.Name;
                            string savefilename = DiffFilePath + (fs.FileFullName.Replace(":", ""));
                            string savingpath = savefilename.Replace(filename, "");
                            if (!Directory.Exists(savingpath)) Directory.CreateDirectory(savingpath);
                            try
                            {
                                File.Copy(fs.FileFullName, savefilename, true);
                                current_path = fs.FileFullName;
                            }
                            catch (Exception ex)
                            {
                                //dtLog.Rows.Add(DateTime.Now, "629.Ошибка : " + ex.Message);
                                logg("Error", "803.CopyFiles. : " + ex.Message);
                                //InterfaceUpdateTimer_Tick();
                            }
                            // так же скопируем в главную папку добавленное
                            if (fs.FileState.Equals("i") && modeint == 1)
                            {
                                savefilename = MainFilePath + (fs.FileFullName.Replace(":", ""));
                                savingpath = savefilename.Replace(filename, "");
                                if (!Directory.Exists(savingpath)) Directory.CreateDirectory(savingpath);
                                try
                                {
                                    File.Copy(fs.FileFullName, savefilename, true);
                                    current_path = fs.FileFullName;
                                }
                                catch (Exception ex)
                                {
                                    //dtLog.Rows.Add(DateTime.Now, "645.Ошибка добавления в полную копию : " + ex.Message);
                                    logg("Error", "820.Ошибка добавления в полную копию : " + ex.Message);
                                    //InterfaceUpdateTimer_Tick();
                                }
                            }
                            currsize += fi.Length;

                            ProgressValue = (int)(((currsize / speedSize) * 100) + 0.5);
                            TotalSize = speedSize - currsize;
                            if (TotalSize < 0) TotalSize = 0;
                            //InterfaceUpdateTimer_Tick();
                        }
                        // скопируем удалённое из резерва
                        if (fs.FileState.Equals("d"))
                        {
                            string reservFileName = MainFilePath + (fs.FileFullName.Replace(":", ""));
                            if (File.Exists(reservFileName))
                            {
                                FileInfo fi = new FileInfo(reservFileName);
                                string filename = fi.Name;
                                string savefilename = DiffFilePath + (fs.FileFullName.Replace(":", ""));
                                string savingpath = savefilename.Replace(filename, "");
                                if (!Directory.Exists(savingpath)) Directory.CreateDirectory(savingpath);
                                try
                                {
                                    File.Copy(reservFileName, savefilename, true);
                                    current_path = reservFileName;
                                }
                                catch (Exception ex)
                                {
                                    //dtLog.Rows.Add(DateTime.Now, "629.Ошибка : " + ex.Message);
                                    logg("Error", "851.CopyFiles : " + ex.Message);
                                    //InterfaceUpdateTimer_Tick();
                                }
                                currsize += fi.Length;

                                ProgressValue = (int)(((currsize / speedSize) * 100) + 0.5);
                                TotalSize = speedSize - currsize;
                                if (TotalSize < 0) TotalSize = 0;
                                //InterfaceUpdateTimer_Tick();
                            }
                        }
                        TimeSpan ts = (DateTime.Now - starttime);
                        if (ts.TotalSeconds > 2)
                        {
                            speedMbs = (((currsize - lastsize) / (1024 * 1024)) / ts.TotalMilliseconds) * 1000;
                            speedFiles = (lastFiles - TotalFiles) / ts.TotalSeconds;
                            starttime = DateTime.Now;
                            lastsize = currsize;
                            lastFiles = TotalFiles;
                            //InterfaceUpdateTimer_Tick();
                        }
                    }
                    ProgressValue = 100;
                    TotalSize = 0;
                    //dtLog.Rows.Add(DateTime.Now, "676.Скопированы файлы отличия." + diffFiledata.Count + " файлов");
                    logg("Info", "877.Скопированы файлы отличия." + diffFiledata.Count + " файлов");


                    updateReserves();
                    //InterfaceUpdateTimer_Tick();
                }
                else if (workMode!=3)
                {
                    //dtLog.Rows.Add(DateTime.Now, "783.Ошибка. Не найден файл разности для режима №2.");
                    //dtLog.Rows.Add(DateTime.Now, DiffFileName);
                    logg("Error", "884.Ошибка. Не найден файл разности для режима №2.");
                    logg("Error",DiffFileName);
                    //InterfaceUpdateTimer_Tick();
                }
            }
            //copying = false;
            step = 0;
            currstep = 0;
            logg("Info", "1102.currstep = 0;step = 0");
        }

        private void CopyFromDataFileToDisk(FileData df, bool isMain = true, int modeint = 1, bool replaceOldFile = false)
        {
            DateTime starttime = DateTime.Now;
            TotalFiles = df.Files.Count;
            int speedfiles = TotalFiles;
            double speedSize = TotalSize;
            double previoussize = 0;
            int previousFiles = TotalFiles;
            speedMbs = 0;
            speedFiles = 0;
            int maxThreads = 10;
            logg("Info", "849.Приступаю к копированию файлов. Итого " + speedfiles + " файлов");
            if (Properties.Settings.Default.ParallelCopy)
            {
                logg("Info", "852.режим параллельного копирования");
                //int flscnt = df.Count;
                Parallel.ForEach(df.Files, fs =>
                {
                    //while (currThreads > maxThreads) Thread.Sleep(10);
                    currThreads++;
                    CopyFile(fs, isMain, modeint, workReplaceOldFiles);
                    TimeSpan ts = (DateTime.Now - starttime);
                    if (ts.TotalSeconds > 2)
                    {
                        ProgressValue = (int)((((speedSize - TotalSize) / speedSize) * 100) + 0.5);
                        if (TotalSize < 0) TotalSize = 0;
                        speedMbs = (speedMbs + (((double)(previoussize - TotalSize) / (1024 * 1024)) / ts.TotalMilliseconds) * 1000) / 2;
                        if (speedMbs < 0) speedMbs = 0;
                        speedFiles = (speedFiles + (previousFiles - TotalFiles) / ts.TotalSeconds) / 2;
                        if (speedFiles < 0) speedFiles = 0;
                        starttime = DateTime.Now;
                        previoussize = TotalSize;
                        previousFiles = TotalFiles;
                        //InterfaceUpdateTimer_Tick();
                    }
                    currThreads--;
                });
                //while (currThreads > 0) Thread.Sleep(10);
            }
            else
            {
                logg("Info", "986.режим последовательного копирования");
                foreach (FileData.FileStruct fs in df.Files)
                {
                    while (currThreads > maxThreads) Thread.Sleep(10);
                    currThreads++;
                    CopyFile(fs, isMain, modeint, workReplaceOldFiles);

                    TimeSpan ts = (DateTime.Now - starttime);
                    if (ts.TotalSeconds > 2)
                    {
                        ProgressValue = (int)((((speedSize - TotalSize) / speedSize) * 100) + 0.5);
                        if (TotalSize < 0) TotalSize = 0;
                        speedMbs = (speedMbs + (((double)(previoussize - TotalSize) / (1024 * 1024)) / ts.TotalMilliseconds) * 1000) / 2;
                        if (speedMbs < 0) speedMbs = 0;
                        speedFiles = (speedFiles + (previousFiles - TotalFiles) / ts.TotalSeconds) / 2;
                        if (speedFiles < 0) speedFiles = 0;
                        starttime = DateTime.Now;
                        previoussize = TotalSize;
                        previousFiles = TotalFiles;
                        //InterfaceUpdateTimer_Tick();
                    }
                    currThreads--;
                }
            }
            //currsize = (long)speedSize;
            //previousFiles = TotalFiles;
            TimeSpan endts = (DateTime.Now - starttime);
            ProgressValue = 100;
            if (TotalSize < 0) TotalSize = 0;
            speedMbs = 0;
            speedFiles = 0;
            starttime = DateTime.Now;
        }

        private void CopyFile(FileData.FileStruct fs, bool isMain, int modeint, bool replaceOldFile)
        {
            try
            {
                if (File.Exists(fs.FileFullName) && ((!isMain && !fs.FileState.Equals("d")) || isMain))
                {
                    FileInfo fi = new FileInfo(fs.FileFullName);
                    TotalSize = (TotalSize - fi.Length);
                    string filename = fi.Name;
                    string savefilename = MainFilePath + (fs.FileFullName.Replace(":", ""));
                    string savingpath = savefilename.Substring(0, savefilename.Length - filename.Length);
                    if (!Directory.Exists(savingpath)) Directory.CreateDirectory(savingpath);
                    try
                    {
                        if ((fs.FileFullName.Length < 32767) && (savefilename.Length < 32767))
                        {
                            if(File.Exists(savefilename))
                            {
                                FileInfo fileInfoSave = new FileInfo(savefilename);
                                FileInfo fileInfoFrom = new FileInfo(fs.FileFullName);
                                if (fileInfoSave.LastWriteTime < fileInfoFrom.LastWriteTime)
                                {
                                    File.Delete(savefilename);
                                    File.Copy(fs.FileFullName, savefilename, true);
                                    logg("Info", "1271.Заменён старый файл " + fs.FileFullName);
                                }
                            }
                            else File.Copy(fs.FileFullName, savefilename, true);
                            current_path = fs.FileFullName;
                        }
                        else
                        {
                            logg("Error", "855.CopyFile. : Слишком длинный путь " + ((fs.FileFullName.Length < 32767) ? savefilename : fs.FileFullName));
                        }
                    }
                    catch (Exception ex)
                    {
                        logg("Error", "898.CopyFile. : " + ex.Message);
                    }
                    if (!isMain)
                    {
                        // так же скопируем в главную папку добавленное
                        if (fs.FileState.Equals("i") && modeint == 1)
                        {
                            savefilename = MainFilePath + (fs.FileFullName.Replace(":", ""));
                            savingpath = savefilename.Substring(0, savefilename.Length - filename.Length);
                            if (!Directory.Exists(savingpath)) Directory.CreateDirectory(savingpath);
                            try
                            {
                                if ((fs.FileFullName.Length < 32767) && (savefilename.Length < 32767))
                                {
                                    File.Copy(fs.FileFullName, savefilename, true);
                                    current_path = fs.FileFullName;
                                }
                                else
                                {
                                    logg("Error", "855.CopyFile : Слишком длинный путь " + ((fs.FileFullName.Length < 32767) ? savefilename : fs.FileFullName));
                                }
                            }
                            catch (Exception ex)
                            {
                                //dtLog.Rows.Add(DateTime.Now, "645.Ошибка добавления в полную копию : " + ex.Message);
                                logg("Error", "864.CopyFile. Ошибка добавления в полную копию : " + ex.Message);
                                //InterfaceUpdateTimer_Tick();
                            }
                        }
                        // скопируем удалённое из резерва
                        if (fs.FileState.Equals("d"))
                        {
                            string reservFileName = MainFilePath + (fs.FileFullName.Replace(":", ""));
                            if (File.Exists(reservFileName))
                            {
                                fi = new FileInfo(reservFileName);
                                filename = fi.Name;
                                savefilename = DiffFilePath + (fs.FileFullName.Replace(":", ""));
                                savingpath = savefilename.Replace(filename, "");
                                if (!Directory.Exists(savingpath)) Directory.CreateDirectory(savingpath);
                                try
                                {
                                    if ((reservFileName.Length < 32767) && (savefilename.Length < 32767))
                                    {
                                        File.Copy(reservFileName, savefilename, true);
                                        current_path = reservFileName;
                                    }
                                    else
                                    {
                                        logg("Error", "855.CopyFile. : Слишком длинный путь " + ((reservFileName.Length < 32767) ? savefilename : fs.FileFullName));
                                    }
                                }
                                catch (Exception ex)
                                {
                                    //dtLog.Rows.Add(DateTime.Now, "629.Ошибка : " + ex.Message);
                                    logg("Error", "889.CopyFile. : " + ex.Message);
                                    //InterfaceUpdateTimer_Tick();
                                }


                                //ProgressValue = (int)(((currsize / speedSize) * 100) + 0.5);
                                //TotalSize = speedSize - currsize;
                                //if (TotalSize < 0) TotalSize = 0;
                                //InterfaceUpdateTimer_Tick();
                            }
                        }
                    }
                }
                else if (fs.Type == "DIR")
                {
                    string savedirname = MainFilePath + (fs.FileFullName.Replace(":", ""));
                    if (!Directory.Exists(savedirname)) Directory.CreateDirectory(savedirname);
                }
            }
            catch (Exception ex)
            {
                logg("Error", "1401.CopyFile. : " + ex.Message);
            }
            finally
            {
                TotalFiles--;
            }
        }

        private void autostart_chkbx_CheckedChanged(object sender, EventArgs e)
        {
            //autostart = false;
            if (autostart_chkbx.Checked) AutoCheckTimer.Start();
            else
            {
                AutoCheckTimer.Stop();
                this.autostart_chkbx.BackColor = Color.Transparent;
            }
            Properties.Settings.Default.AutoStartCopy = autostart_chkbx.Checked;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
        }

        private void updateReserves(DateTime? timeTodelete = null)
        {
            logg("Info", "1360.MainForm.updateReserves. Загрузка потока.");
            Thread trd = new Thread(() =>
            //uniinvoker.TryInvoke(reserv_dgv, () =>
            {
                lock (reserveCopyes);
                logg("Info", "1364.MainForm.updateReserves. Запущен " + Thread.CurrentThread.ManagedThreadId + " поток.");
                DriveInfo driveInfo = new DriveInfo(MainFilePath.Split(':')[0]);
                ulong freeSpace = (ulong)driveInfo.AvailableFreeSpace;
                reserveCopyes.Clear();
                DirectoryInfo scanPath = new DirectoryInfo(Properties.Settings.Default.OutputPath);
                GetReserveCopyes(new string[] { "DIFFILE.txt", "MAINFULL.txt" }, scanPath, true);
                if (timeTodelete != null && !deletebytimeinwork)
                {
                    deletebytimeinwork = true;
                    reserveDeleter((DateTime)timeTodelete);
                    deletebytimeinwork = false;
                }
                logg("Info", "1348.MainForm.updateReserves.Доступно всего: " + freeSpace + ". Минимальный размер свободного места: " + delMinSize);
                int attempts = 0;
                ulong prevfreespace = 0;
                while ((freeSpace < delMinSize) && (delForFreeSpace) && attempts < 100 && workMode != 3)
                {
                    if (delForFreeSpace && !deletebytimeinwork)
                    {
                        deletebytimeinwork = true;
                        if (reserveDeleter(oldestReserve))
                        {
                            freeSpace = (ulong)driveInfo.AvailableFreeSpace;
                            logg("Info", "1377.MainForm." + "Доступно всего: " + freeSpace + ". Удаляю файлы для освобождения места по дате: " + oldestReserve.ToShortDateString() + " " + oldestReserve.ToShortTimeString());
                            deletebytimeinwork = false;
                        }
                    }
                    reserveCopyes.Clear();
                    GetReserveCopyes(new string[] { "DIFFILE.txt", "MAINFULL.txt" }, scanPath, true);
                    freeSpace = (ulong)driveInfo.AvailableFreeSpace;
                    if ((prevfreespace == freeSpace) && !deletebytimeinwork)
                    {
                        attempts++;
                        if (attempts % 10 == 0)
                        {
                            logg("Info", "1389.MainForm.updateReserves. Попыток очистки:" + attempts);
                        }
                    }

                    else
                    {
                        prevfreespace = freeSpace;
                        attempts = 0;
                    }
                }
                logg("Info", "1466.MainForm.updateReserves. Поток " + Thread.CurrentThread.ManagedThreadId + " завершён.");
                //})
            });
            trd.Start();
        }


        private void logg(string type, string msg,bool showMessageWindow=false)
        {
            //dtLog.Rows.Add(DateTime.Now, msg);
            if (showMessageWindow) MessageBox.Show(msg);
            LogStr ls = new LogStr();
            ls.dtstr = DateTime.Now;
            ls.type = type;
            ls.mssg = msg;
            loglist.Add(ls);
            //blistlog.Add(ls);
        }

        private void MainReservCopyer_FormClosed(object sender, FormClosedEventArgs e)
        {
            notifyIcon.Visible = false;
            System.Environment.Exit(0);
        }

        #region установка повышенных прав приложения
        static bool RequestSeBackupPrivilege()
        {
            LUID luid;

            if (!LookupPrivilegeValue(null, "SeBackupPrivilege", out luid))
                return false;

            TOKEN_PRIVILEGES_SINGLE tp = new TOKEN_PRIVILEGES_SINGLE
            {
                PrivilegeCount = 1,
                Luid = luid,
                Attributes = SE_PRIVILEGE_ENABLED
            };

            IntPtr hToken;
            return
                OpenProcessToken(
                    GetCurrentProcess(), TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, out hToken) &&
                AdjustTokenPrivileges(
                    hToken, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero) &&
                (Marshal.GetLastWin32Error() != ERROR_NOT_ALL_ASSIGNED);
        }

        const int SE_PRIVILEGE_ENABLED = 0x00000002;
        const int TOKEN_QUERY = 0x00000008;
        const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
        const int ERROR_NOT_ALL_ASSIGNED = 1300;

        [DllImport("kernel32.dll", ExactSpelling = true)]
        static extern IntPtr GetCurrentProcess();

        [StructLayout(LayoutKind.Sequential)]
        struct TOKEN_PRIVILEGES_SINGLE
        {
            public UInt32 PrivilegeCount;
            public LUID Luid;
            public UInt32 Attributes;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct LUID
        {
            public uint LowPart;
            public int HighPart;
        }

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool LookupPrivilegeValue(
            string lpSystemName, string lpName, out LUID lpLuid);

        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool OpenProcessToken(
            IntPtr ProcessHandle, UInt32 DesiredAccess, out IntPtr TokenHandle);

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        static extern bool AdjustTokenPrivileges(
            IntPtr htok, bool disall, ref TOKEN_PRIVILEGES_SINGLE newst,
            int len, IntPtr prev, IntPtr relen);
        #endregion

        private void MainReservCopyer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((e.CloseReason == CloseReason.UserClosing) && MinimizeInTray && !programmClose)
            {
                e.Cancel = true;
                _windowState = this.WindowState;
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
        }

        private void MaximizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.WindowState = _windowState;

        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            programmClose = true;
            this.Close();
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.ShowInTaskbar = true;
                this.WindowState = _windowState;
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(reserv_dgv.SelectedRows[0].Cells["FullName"].Value.ToString());
            reserveDeleter(fi);
            updateReserves();
        }

        private void OpenPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(reserv_dgv.SelectedRows[0].Cells["FullName"].Value.ToString());
            Process.Start(fi.DirectoryName);
        }
    }
}
