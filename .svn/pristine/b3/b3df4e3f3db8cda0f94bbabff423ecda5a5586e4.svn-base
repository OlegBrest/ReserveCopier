using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReserveCopier
{
    public partial class MainReservCopyer : Form
    {
        int TotalDirs = 0;
        int TotalFiles = 0;
        double TotalSize = 0;
        int progress_rows = 0;
        DataTable dtLog = new DataTable();
        BindingSource bs = new BindingSource();
        //DataTable dtfiles = new DataTable();
        bool fullFileWrite = false; // индикатор записи полного файла
        Thread trdfilecalc; // поток подсчёта файлов
        Thread trdfilecopy; // поток копирования файлов
        double speedMbs = 0; // Скорость метров в сек
        double speedFils = 0; // Скорость файлов в сек

        int ProgressValue = 0;
        string MainFileName = "";
        string MainFilePath = "";
        string DiffFileName = "";
        string DiffFilePath = "";

        FileData mainFiledata = new FileData();
        FileData diffFiledata = new FileData();
        FileData currFileData = new FileData();

        System.Timers.Timer InterfaceUpdateTimer = new System.Timers.Timer();
        public MainReservCopyer()
        {
            InitializeComponent();
            SetDoubleBuffered(dataGridViewprogress);
            dtLog.Columns.Add("Время", typeof(DateTime));
            dtLog.Columns.Add("Cообщение", typeof(string));
            bs.DataSource = dtLog;
            dataGridViewprogress.DataSource = bs;
            InterfaceUpdateTimer.Elapsed += InterfaceUpdateTimer_Elapsed;
            InterfaceUpdateTimer.AutoReset = true;
            InterfaceUpdateTimer.Interval = 100;
            InterfaceUpdateTimer.Enabled = true;
            trdfilecalc = new Thread(CalcTotalFileDirsCount);
            trdfilecopy = new Thread(CopyFiles);
            dtLog.Rows.Add(DateTime.Now, "52.Программа прошла инициализацию.");
            CheckPaths();
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
        }

        private void start_bttn_Click(object sender, EventArgs e)
        {
            CheckPaths();
            TotalDirs = 0;
            TotalFiles = 0;
            TotalSize = 0;
            //dtfiles.Rows.Clear();
            mainFiledata.Clear();
            currFileData.Clear();
            diffFiledata.Clear();
            string[] Paths = Properties.Settings.Default.InputPaths.Split('\n');
            fullFileWrite = true;
            trdfilecalc = new Thread(CalcTotalFileDirsCount);
            trdfilecalc.Start(Paths);
            InterfaceUpdateTimer_Tick();
        }

        private void CalcTotalFileDirsCount(object _Paths)
        {
            string[] Paths = (string[])_Paths;
            //Parallel.ForEach(Paths,path=>
            foreach (string path in Paths)
            {
                checkForDirFile(path);
            }//);
        }

        private void checkForDirFile(string path)
        {
            if (File.Exists(path))
            {
                TotalFiles++;
                FileInfo fi = new FileInfo(path);
                long length = fi.Length;
                long chgtime = fi.LastWriteTime.Ticks;
                TotalSize += length;
                currFileData.AddRow(path, length, chgtime);
            }
            else
            {
                if (Directory.Exists(path))
                {
                    TotalDirs++;
                    try
                    {
                        string[] dirs = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);
                        CalcTotalFileDirsCount(dirs);
                        try
                        {
                            string[] files = Directory.GetFiles(path);
                            CalcTotalFileDirsCount(files);
                        }
                        catch (Exception ex)
                        {
                            //progressList.Add(DateTime.Now.ToLongTimeString() + " . Ошибка : " + ex.Message);
                            dtLog.Rows.Add(DateTime.Now, "134.Ошибка : " + ex.Message);
                            InterfaceUpdateTimer_Tick();
                        }
                    }
                    catch (Exception ex)
                    {
                        //progressList.Add(DateTime.Now.ToLongTimeString() + " . Ошибка : " + ex.Message);
                        dtLog.Rows.Add(DateTime.Now, "141.Ошибка : " + ex.Message);
                        InterfaceUpdateTimer_Tick();
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
            if ((!trdfilecalc.IsAlive) && (fullFileWrite))
            {
                fullFileWrite = false;
                string Mode = Properties.Settings.Default.CopyModeValue;
                int modeint = 0;
                switch (Mode)
                {
                    case "Полное":
                        modeint = 0;
                        break;
                    case "Разностное относительно первой копии":
                        modeint = 1;
                        break;
                    case "Разностное относительно последней копии":
                        modeint = 2;
                        break;
                }
                WriteFileDiff(modeint);
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
            SpeedLabel.Text = String.Format("{0:N2} Мб/с, {1:N2} Ф/с", speedMbs, speedFils);
            SpeedLabel.Update();
        }
        private void updateProgressView()
        {
            if (progress_rows != dtLog.Rows.Count)
            {
                if (dtLog.Rows.Count > 200) dtLog.Rows.RemoveAt(0);
                int firstRow = dataGridViewprogress.FirstDisplayedScrollingRowIndex;
                try
                {
                    bs.ResetBindings(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("226.MainForm.", ex.Message);
                }
                progress_rows = dtLog.Rows.Count;
                if (firstRow >= 0) dataGridViewprogress.FirstDisplayedScrollingRowIndex = firstRow;
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
                progressBar.Visible = true;
                progressBar.Value = ProgressValue;
                progressBar.Update();
            }
        }

        #endregion

        private void dataGridViewprogress_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.ToString());
        }

        private void CheckPaths()
        {
            dtLog.Rows.Add(DateTime.Now, "229.Перепроверю пути сохранения файлов");
            InterfaceUpdateTimer_Tick();
            DateTime dt1 = DateTime.Now;
            string CreateDiffDay = dt1.Year + "\\" + dt1.Month + "\\" + dt1.Day + "\\" + dt1.Hour + "." + dt1.Minute;
            GregorianCalendar cal = new GregorianCalendar();
            string CreateFullPriodicName = "";
            string FullWriteMode = Properties.Settings.Default.FullCopyPeriodic;

            switch (FullWriteMode)
            {
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
            string Mode = Properties.Settings.Default.CopyModeValue;
            if (Mode.Equals("Полное")) CreateFullPriodicName = dt1.Year + "\\" + dt1.Month + "\\" + dt1.Day + "\\" + dt1.Hour;
            MainFilePath = Properties.Settings.Default.OutputPath + "\\" + CreateFullPriodicName + "\\";
            Directory.CreateDirectory(MainFilePath);
            MainFileName = MainFilePath + "MAINFULL.txt";
            DiffFilePath = Properties.Settings.Default.OutputPath + "\\" + CreateDiffDay + "\\";
            Directory.CreateDirectory(DiffFilePath);
            DiffFileName = DiffFilePath + "DIFFILE.txt";
            dtLog.Rows.Add(DateTime.Now, MainFileName);
            dtLog.Rows.Add(DateTime.Now, DiffFileName);
            InterfaceUpdateTimer_Tick();

        }

        private void WriteFileDiff(int mode)
        {
            string[] currlines = new string[currFileData.Count];
            if (File.Exists(MainFileName))
            {
                // создаём полный файл полного копирования
                if (mode == 0)
                {
                    dtLog.Rows.Add(DateTime.Now, "337.Записываю главный файл поверх старого.");
                    InterfaceUpdateTimer_Tick();
                    File.Delete(MainFileName);
                    File.WriteAllLines(MainFileName, currlines);
                }
                // если нет полного файла то создаём , если есть то создаём новый разностный DIFFILE не изменяя MAINFULL
                if (mode == 1)
                {
                    #region заливаем предыдущий ДТ для сравнения
                    dtLog.Rows.Add(DateTime.Now, "346.Читаю главный файл для последующего сравнения.");
                    InterfaceUpdateTimer_Tick();
                    string[] mainlines = File.ReadAllLines(MainFileName);
                    mainFiledata.InsertFromStrArr(mainlines, "");
                    #endregion
                    #region сравниваем и создаём ДТ разности для этого в разностный льём обе таблицы и вычленяем оттуда одинаковые строки
                    diffFiledata.InsertFromFD(mainFiledata, "d");
                    diffFiledata.InsertFromFD(currFileData, "i");
                    diffFiledata.FindAndClearDuplicates();
                    string[] difflines = new string[0];
                    diffFiledata.ToStringArray(ref difflines);
                    dtLog.Rows.Add(DateTime.Now, "357.Записываю файл отличий.");
                    InterfaceUpdateTimer_Tick();
                    File.WriteAllLines(DiffFileName, difflines);
                    Properties.Settings.Default.LastDiffPath = DiffFilePath;
                    Properties.Settings.Default.LastDiffTime = DateTime.Now;
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();
                    #endregion
                }
                // если нет полного файла то создаём , если есть то создаём новый разностный DIFFILE после заменяя MAINFULL
                if (mode == 2)
                {
                    #region заливаем предыдущий ДТ для сравнения
                    dtLog.Rows.Add(DateTime.Now, "370.Читаю главный файл для последующего сравнения.");
                    InterfaceUpdateTimer_Tick();
                    string[] mainlines = File.ReadAllLines(MainFileName);
                    mainFiledata.InsertFromStrArr(mainlines, "");
                    #endregion
                    #region сравниваем и создаём ДТ разности для этого в разностный льём обе таблицы и вычленяем оттуда одинаковые строки
                    diffFiledata.InsertFromFD(mainFiledata, "d");
                    diffFiledata.InsertFromFD(currFileData, "i");
                    diffFiledata.FindAndClearDuplicates();
                    string[] difflines = new string[0];
                    diffFiledata.ToStringArray(ref difflines);
                    dtLog.Rows.Add(DateTime.Now, "381.Записываю файл отличий.");
                    InterfaceUpdateTimer_Tick();
                    File.WriteAllLines(DiffFileName, difflines);
                    // и перезапишем главный файл
                    File.Delete(MainFileName);
                    currFileData.ToStringArray(ref currlines);
                    dtLog.Rows.Add(DateTime.Now, "387.Презаписываю главный файл новыми данными.");
                    InterfaceUpdateTimer_Tick();
                    File.WriteAllLines(MainFileName, currlines);
                    Properties.Settings.Default.LastDiffPath = DiffFilePath;
                    Properties.Settings.Default.LastDiffTime = DateTime.Now;
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();
                    #endregion
                }
            }
            else
            {
                currFileData.ToStringArray(ref currlines);
                dtLog.Rows.Add(DateTime.Now, "400.Записываю главный файл.");
                InterfaceUpdateTimer_Tick();
                File.WriteAllLines(MainFileName, currlines);
                Properties.Settings.Default.LastFullTime = DateTime.MinValue;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }
        }

        private void SaveFullFileBttn_Click(object sender, EventArgs e)
        {
            string Mode = Properties.Settings.Default.CopyModeValue;
            int modeint = 0;
            switch (Mode)
            {
                case "Полное":
                    modeint = 0;
                    break;
                case "Разностное относительно первой копии":
                    modeint = 1;
                    break;
                case "Разностное относительно последней копии":
                    modeint = 2;
                    break;
            }
            WriteFileDiff(modeint);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Mode = Properties.Settings.Default.CopyModeValue;
            int modeint = 0;
            switch (Mode)
            {
                case "Полное":
                    modeint = 0;
                    break;
                case "Разностное относительно первой копии":
                    modeint = 1;
                    break;
                case "Разностное относительно последней копии":
                    modeint = 2;
                    break;
            }
            trdfilecopy = new Thread(CopyFiles);
            trdfilecopy.Start(modeint);
        }

        private void CopyFiles(object mode)
        {
            int modeint = (int)mode;
            // делаем полную копию
            if (modeint == 0)
            {
                if (File.Exists(MainFileName))
                {
                    mainFiledata.Clear();
                    mainFiledata.InsertFromStrArr(File.ReadAllLines(MainFileName));
                    TotalSize = mainFiledata.GetTotalSize();

                    long currsize = 0;
                    DateTime starttime = DateTime.Now;
                    int speedfiles = TotalFiles;
                    double speedSize = TotalSize;
                    double lastsize = 0;
                    int lastFiles = TotalFiles;
                    speedMbs = 0;
                    speedFils = 0;
                    foreach (FileData.FileStruct fs in mainFiledata.Files)
                    {

                        if (File.Exists(fs.FileFullName))
                        {
                            FileInfo fi = new FileInfo(fs.FileFullName);
                            string filename = fi.Name;
                            string savefilename = MainFilePath + (fs.FileFullName.Replace(":", ""));
                            string savingpath = savefilename.Replace(filename, "");
                            if (!Directory.Exists(savingpath)) Directory.CreateDirectory(savingpath);
                            try
                            {
                                File.Copy(fs.FileFullName, savefilename, true);
                            }
                            catch (Exception ex)
                            {
                                dtLog.Rows.Add(DateTime.Now, "356.Ошибка : " + ex.Message);
                                InterfaceUpdateTimer_Tick();
                            }
                            TotalFiles--;
                            currsize += fi.Length;

                            ProgressValue = (int)(((currsize / speedSize) * 100) + 0.5);
                            TotalSize = speedSize - currsize;
                            if (TotalSize < 0) TotalSize = 0;
                            InterfaceUpdateTimer_Tick();
                        }
                        TimeSpan ts = (DateTime.Now - starttime);
                        if (ts.TotalSeconds > 2)
                        {
                            speedMbs = (((currsize - lastsize) / (1024 * 1024)) / ts.TotalMilliseconds) * 1000;
                            speedFils = (lastFiles - TotalFiles) / ts.TotalSeconds;
                            starttime = DateTime.Now;
                            lastsize = currsize;
                            lastFiles = TotalFiles;
                            InterfaceUpdateTimer_Tick();
                        }
                    }
                    Properties.Settings.Default.LastFullTime = DateTime.Now;
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();
                }
                else
                {
                    dtLog.Rows.Add(DateTime.Now, "381.Ошибка : Не найден главный файл-список.");
                    InterfaceUpdateTimer_Tick();
                }
            }
            // делаем разностную 
            if (modeint != 0)
            {
                DateTime lastfulldateTime = Properties.Settings.Default.LastFullTime;
                bool need2fulldate = false;
                string FullWriteMode = Properties.Settings.Default.FullCopyPeriodic;
                switch (FullWriteMode)
                {
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

                    long currsize = 0;
                    DateTime starttime = DateTime.Now;
                    int speedfiles = TotalFiles;
                    double speedSize = TotalSize;
                    double lastsize = 0;
                    int lastFiles = TotalFiles;
                    speedMbs = 0;
                    speedFils = 0;
                    dtLog.Rows.Add(DateTime.Now, "555. Копирую основные файлы.");
                    InterfaceUpdateTimer_Tick();
                    foreach (FileData.FileStruct fs in mainFiledata.Files)
                    {

                        if (File.Exists(fs.FileFullName))
                        {
                            FileInfo fi = new FileInfo(fs.FileFullName);
                            string filename = fi.Name;
                            string savefilename = MainFilePath + (fs.FileFullName.Replace(":", ""));
                            string savingpath = savefilename.Replace(filename, "");
                            if (!Directory.Exists(savingpath)) Directory.CreateDirectory(savingpath);
                            try
                            {
                                File.Copy(fs.FileFullName, savefilename, true);
                            }
                            catch (Exception ex)
                            {
                                dtLog.Rows.Add(DateTime.Now, "356.Ошибка : " + ex.Message);
                                InterfaceUpdateTimer_Tick();
                            }
                            TotalFiles--;
                            currsize += fi.Length;

                            ProgressValue = (int)(((currsize / speedSize) * 100) + 0.5);
                            TotalSize = speedSize - currsize;
                            if (TotalSize < 0) TotalSize = 0;
                            InterfaceUpdateTimer_Tick();
                        }
                        TimeSpan ts = (DateTime.Now - starttime);
                        if (ts.TotalSeconds > 2)
                        {
                            speedMbs = (((currsize - lastsize) / (1024 * 1024)) / ts.TotalMilliseconds) * 1000;
                            speedFils = (lastFiles - TotalFiles) / ts.TotalSeconds;
                            starttime = DateTime.Now;
                            lastsize = currsize;
                            lastFiles = TotalFiles;
                            InterfaceUpdateTimer_Tick();
                        }
                    }
                    dtLog.Rows.Add(DateTime.Now, "595. Скопированы основные файлы.");
                    InterfaceUpdateTimer_Tick();
                    Properties.Settings.Default.LastFullTime = DateTime.Now;
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();
                }
                else if (!File.Exists(MainFileName))
                {
                    dtLog.Rows.Add(DateTime.Now, "596.Ошибка : Не найден главный файл-список.");
                    InterfaceUpdateTimer_Tick();
                }
                if (File.Exists(DiffFileName))
                {
                    diffFiledata.Clear();
                    diffFiledata.InsertFromStrArr(File.ReadAllLines(DiffFileName));

                    TotalSize = diffFiledata.GetTotalSize();
                    TotalFiles = diffFiledata.Count;
                    long currsize = 0;
                    DateTime starttime = DateTime.Now;
                    int speedfiles = TotalFiles;
                    double speedSize = TotalSize;
                    double lastsize = 0;
                    int lastFiles = TotalFiles;
                    speedMbs = 0;
                    speedFils = 0;
                    dtLog.Rows.Add(DateTime.Now, "621. Копирую файлы отличия.");
                    InterfaceUpdateTimer_Tick();
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
                            }
                            catch (Exception ex)
                            {
                                dtLog.Rows.Add(DateTime.Now, "629.Ошибка : " + ex.Message);
                                InterfaceUpdateTimer_Tick();
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
                                }
                                catch (Exception ex)
                                {
                                    dtLog.Rows.Add(DateTime.Now, "645.Ошибка добавления в полную копию : " + ex.Message);
                                    InterfaceUpdateTimer_Tick();
                                }
                            }
                            TotalFiles--;
                            currsize += fi.Length;

                            ProgressValue = (int)(((currsize / speedSize) * 100) + 0.5);
                            TotalSize = speedSize - currsize;
                            if (TotalSize < 0) TotalSize = 0;
                            InterfaceUpdateTimer_Tick();
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
                                }
                                catch (Exception ex)
                                {
                                    dtLog.Rows.Add(DateTime.Now, "629.Ошибка : " + ex.Message);
                                    InterfaceUpdateTimer_Tick();
                                }
                                TotalFiles--;
                                currsize += fi.Length;

                                ProgressValue = (int)(((currsize / speedSize) * 100) + 0.5);
                                TotalSize = speedSize - currsize;
                                if (TotalSize < 0) TotalSize = 0;
                                InterfaceUpdateTimer_Tick();
                            }
                        }
                            TimeSpan ts = (DateTime.Now - starttime);
                        if (ts.TotalSeconds > 2)
                        {
                            speedMbs = (((currsize - lastsize) / (1024 * 1024)) / ts.TotalMilliseconds) * 1000;
                            speedFils = (lastFiles - TotalFiles) / ts.TotalSeconds;
                            starttime = DateTime.Now;
                            lastsize = currsize;
                            lastFiles = TotalFiles;
                            InterfaceUpdateTimer_Tick();
                        }
                    }
                    dtLog.Rows.Add(DateTime.Now, "676. Скопированы файлы отличия.");
                    InterfaceUpdateTimer_Tick();
                }
                else
                {
                    dtLog.Rows.Add(DateTime.Now, "533.Ошибка.Не найден файл разности для режима №2.");
                    dtLog.Rows.Add(DiffFileName);
                    InterfaceUpdateTimer_Tick();
                }
            }
        }
    }
}
