using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReserveCopier
{
    class FileData
    {
        public int Count = 0;
        public struct FileStruct
        {
            public string FileFullName;
            public long FileSize;
            public long FileChangeTime;
            public string FileState; // d удалён , i добавлен , m изменен
        }
        public FileStruct[] Files;

        public FileData()
        {
            Files = new FileStruct[0];
            Count = 0;
        }
        public void InsertFromDT(DataTable dt)
        {
            int rowscnt = dt.Rows.Count;
            Files = new FileStruct[rowscnt];
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    if (dt.Columns.Count > 0) Files[--rowscnt].FileFullName = dr[0].ToString();
                    if (dt.Columns.Count > 1) Files[rowscnt].FileSize = (long)dr[1];
                    if (dt.Columns.Count > 2) Files[rowscnt].FileChangeTime = (long)(dr[2]);
                    if (dt.Columns.Count > 3) Files[rowscnt].FileState = dr[3].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void InsertFromDT(DataTable dt, string state)
        {
            int rowscnt = dt.Rows.Count;
            Files = new FileStruct[rowscnt];
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    if (dt.Columns.Count > 0) Files[--rowscnt].FileFullName = dr[0].ToString();
                    if (dt.Columns.Count > 1) Files[rowscnt].FileSize = (long)dr[1];
                    if (dt.Columns.Count > 2) Files[rowscnt].FileChangeTime = (long)(dr[2]);
                    Files[rowscnt].FileState = state;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public bool InsertFromFD(FileData fd)
        {
            bool result = true;
            long plannedsize = fd.Count + Count;
            try
            {
                Array.Resize(ref Files, fd.Count + Count);
                foreach (FileStruct fs in fd.Files)
                {
                    try
                    {
                        Files[Count].FileFullName = fs.FileFullName;
                        Files[Count].FileSize = fs.FileSize;
                        Files[Count].FileChangeTime = fs.FileChangeTime;
                        Files[Count].FileState = fs.FileState;
                        Count++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
                MessageBox.Show(ex.Message);
            }
            if (Count != plannedsize) result = false;
            return result;
        }

        public bool InsertFromFD(FileData fd, string state)
        {
            bool result = true;
            long plannedsize = fd.Count + Count;
            try
            {
                Array.Resize(ref Files, fd.Count + Count);
                foreach (FileStruct fs in fd.Files)
                //Parallel.ForEach<FileStruct>(fd.Files, fs =>
                 {
                     try
                     {
                         Files[Count].FileFullName = fs.FileFullName;
                         Files[Count].FileSize = fs.FileSize;
                         Files[Count].FileChangeTime = fs.FileChangeTime;
                         Files[Count].FileState = state;
                         Count++;
                     }
                     catch (Exception ex)
                     {
                         result = false;
                         MessageBox.Show(ex.Message);
                     }
                 }//);
            }
            catch (Exception ex)
            {
                result = false;
                MessageBox.Show(ex.Message);
            }
            if (Count != plannedsize) result = false;
            return result;
        }

        public bool InsertFromStrArr(string [] sa, string state)
        {
            bool result = true;
            long plannedsize = sa.Length + Count;
            try
            {
                Array.Resize(ref Files, sa.Length + Count);
                foreach (string s in sa)
                //Parallel.ForEach<string>(sa, s =>
                {
                    try
                    {
                        string[] sr = s.Split('|');
                        Files[Count].FileFullName = sr[0];
                        Files[Count].FileSize = Convert.ToInt64(sr[1]);
                        Files[Count].FileChangeTime = Convert.ToInt64(sr[2]);
                        Count++;
                    }
                    catch (Exception ex)
                    {
                        result = false;
                        MessageBox.Show(ex.Message);
                    }
                }//);
            }
            catch (Exception ex)
            {
                result = false;
                MessageBox.Show(ex.Message);
            }
            if (Count != plannedsize) result = false;
            return result;
        }

        public bool InsertFromStrArr(string[] sa)
        {
            bool result = true;
            long plannedsize = sa.Length + Count;
            try
            {
                Array.Resize(ref Files, sa.Length + Count);
                foreach (string s in sa)
                //Parallel.ForEach<string>(sa, s =>
                {
                    try
                    {
                        string[] sr = s.Split('|');
                        Files[Count].FileFullName = sr[0];
                        Files[Count].FileSize = Convert.ToInt64(sr[1]);
                        Files[Count].FileChangeTime = Convert.ToInt64(sr[2]);
                        Files[Count].FileState = sr[3];
                        Count++;
                    }
                    catch (Exception ex)
                    {
                        result = false;
                        MessageBox.Show(ex.Message);
                    }
                }//);
            }
            catch (Exception ex)
            {
                result = false;
                MessageBox.Show(ex.Message);
            }
            if (Count != plannedsize) result = false;
            return result;
        }
        public string[] ToStringArray(ref string [] inpArray )
        {
            inpArray = new string[Count];
            for(int i = 0; i < Count;i++)
            {
                inpArray[i] = Files[i].FileFullName + "|" + Files[i].FileSize + "|" + Files[i].FileChangeTime + "|" + Files[i].FileState;
            }
            return inpArray;
        }

        public void Clear()
        {
            Files = new FileStruct[0];
            Count = 0;
        }

        public void AddRow(string FileFullName, long FileSize, long FileChangeTime, string FileState = "")
        {
            Count++;
            FileStruct[] _fs = new FileStruct [Count];
            int curs = 0;
            /*foreach (FileStruct fs in Files)
            {
                _fs[curs] = fs;
                curs++;
            }*/
            Files.CopyTo(_fs, 0);
            _fs[Count - 1].FileFullName = FileFullName;
            _fs[Count - 1].FileSize = FileSize;
            _fs[Count - 1].FileChangeTime = FileChangeTime;
            _fs[Count - 1].FileState = FileState;
            Files = new FileStruct[Count];

            curs = 0;
            /*foreach (FileStruct fs in _fs)
            {
                Files[curs] = fs;
                curs++;
            }*/
            _fs.CopyTo(Files, 0);
            _fs = null;
        }

        public void FindAndClearDuplicates ()
        {
            int _delcnt = 0;
            for (int fs1 = 0; fs1 < Count; fs1++)
            {
                for (int fs2 = (Count-1); fs2 > fs1 ; fs2--)
                {
                    if (Files[fs1].FileFullName.Equals(Files[fs2].FileFullName))
                    {
                        if ((Files[fs1].FileSize == Files[fs2].FileSize) && (Files[fs1].FileChangeTime.Equals(Files[fs2].FileChangeTime)))
                        {
                            Files[fs1].FileState = "0";
                            Files[fs2].FileState = "0";
                            _delcnt += 2;
                        }
                        else
                        {
                            Files[fs1].FileState = "m";
                            Files[fs2].FileState = "0";
                            _delcnt++;
                        }
                    }
                }
            }
            
            if ((Count - _delcnt) > 0)
            {
                FileStruct[] _fs = new FileStruct[Count - _delcnt];
                int tempcnt = 0;
                for (int i = 0; i <Count; i++)
                {
                    if (!Files[i].FileState.Equals("0"))
                    {
                        _fs[tempcnt] = Files[i];
                        tempcnt++;
                    }
                }
                Count = tempcnt;
                Files = new FileStruct[Count];
                _fs.CopyTo(Files, 0);
                _fs = null;
            }
            else
            {
                Clear();
            }
        }

        public long GetTotalSize()
        {
            long result = 0;
            foreach (FileStruct fs in Files)
            {
                result += fs.FileSize;
            }
            return result;
        }
    }
}
