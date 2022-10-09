using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReserveCopier
{
    class FileData 
    {
        public int Count = 0;
        public bool _isBusy = false;
        public string NameMethod = "";

        public struct FileStruct : IComparable<FileStruct> 
        {
            public string Type; // FILE , DIR
            public string FileFullName;
            public long FileSize;
            public long FileChangeTime;
            public string FileState; // d удалён , i добавлен , m изменен

            int IComparable<FileStruct>.CompareTo(FileStruct x)
            {
                int retval = 0;
                retval = StringComparer.Ordinal.Compare(x.FileFullName, FileFullName);
                if (retval == 0) retval = (int) (x.FileSize - FileSize);
                if (retval == 0) retval = (int)(x.FileChangeTime - FileChangeTime);
                return retval;
            }
        }

        //public FileStruct[] Files;
        public List<FileStruct> Files;

        public FileData()
        {
            //Files = new FileStruct[0];
            Files = new List<FileStruct>();
            Count = 0;
        }


        public void InsertFromDT(DataTable dt)
        {
            isBusy();
            if (!_isBusy)
            {
                _isBusy = true;
                NameMethod = "35.InsertFromDT";
                //int rowscnt = dt.Rows.Count;
                //Files = new FileStruct[rowscnt];
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        /*
                        if (dt.Columns.Count > 0) Files[--rowscnt].FileFullName = dr[0].ToString();
                        if (dt.Columns.Count > 1) Files[rowscnt].FileSize = (long)dr[1];
                        if (dt.Columns.Count > 2) Files[rowscnt].FileChangeTime = (long)(dr[2]);
                        if (dt.Columns.Count > 3) Files[rowscnt].FileState = dr[3].ToString();
                        */
                        FileStruct fs = new FileStruct();
                        if (dt.Columns.Count > 0) fs.Type = dr[0].ToString();
                        if (dt.Columns.Count > 1) fs.FileFullName = dr[1].ToString();
                        if (dt.Columns.Count > 2) fs.FileSize = (long)dr[2];
                        if (dt.Columns.Count > 3) fs.FileChangeTime = (long)(dr[3]);
                        if (dt.Columns.Count > 4) fs.FileState = dr[4].ToString();

                        Files.Add(fs);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                _isBusy = false;
            }
            Count = Files.Count;
        }

        public void InsertFromDT(DataTable dt, string state)
        {
            isBusy();
            if (!_isBusy)
            {
                _isBusy = true;
                NameMethod = "62.InsertFromDT";
                int rowscnt = dt.Rows.Count;
                //Files = new FileStruct[rowscnt];
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        /*if (dt.Columns.Count > 0) Files[--rowscnt].FileFullName = dr[0].ToString();
                        if (dt.Columns.Count > 1) Files[rowscnt].FileSize = (long)dr[1];
                        if (dt.Columns.Count > 2) Files[rowscnt].FileChangeTime = (long)(dr[2]);
                        Files[rowscnt].FileState = state;*/
                        FileStruct fs = new FileStruct();
                        if (dt.Columns.Count > 0) fs.Type = dr[0].ToString();
                        if (dt.Columns.Count > 1) fs.FileFullName = dr[1].ToString();
                        if (dt.Columns.Count > 2) fs.FileSize = (long)dr[2];
                        if (dt.Columns.Count > 3) fs.FileChangeTime = (long)(dr[3]);
                        if (dt.Columns.Count > 4) fs.FileState = dr[4].ToString();
                        Files.Add(fs);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                _isBusy = false;
            }
            Count = Files.Count;
        }

        public bool InsertFromFD(FileData fd)
        {
            isBusy();
            bool result = true;
            if (!_isBusy)
            {
                _isBusy = true;
                NameMethod = "90.InsertFromFD";
                long plannedsize = fd.Count + Count;
                Files.AddRange(fd.Files);
                /*try
                {
                    //Array.Resize(ref Files, fd.Count + Count);
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
                */
                Count = Files.Count;
                if (Count != plannedsize) result = false;
                _isBusy = false;
            }
            return result;
        }

        public bool InsertFromFD(FileData fd, string state)
        {
            isBusy();
            bool result = true;
            if (Files.Count > 0) Files.Sort();
            if (fd.Files.Count>0) fd.Files.Sort();
            if (!_isBusy)
            {
                _isBusy = true;
                NameMethod = "129.InsertFromFD";
                long plannedsize = fd.Count + Count;
                try
                {
                    //Array.Resize(ref Files, fd.Count + Count);
                    foreach (FileStruct fs in fd.Files)
                    //Parallel.ForEach<FileStruct>(fd.Files, fs =>
                    {
                        try
                        {
                            FileStruct fss = new FileStruct();
                            fss.Type = fs.Type;
                            fss.FileFullName = fs.FileFullName;
                            fss.FileSize = fs.FileSize;
                            fss.FileChangeTime = fs.FileChangeTime;
                            fss.FileState = "d";
                            int finder = -1;
                            if (state == "i")
                            {
                                try
                                {
                                    finder = Files.BinarySearch(fss);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            if (finder > -1)
                            {
                                Files.RemoveAt(finder);
                            }
                            else
                            {
                                fss.FileState = state;
                                Files.Add(fss);
                            }
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
                Count = Files.Count;
                if (Count != plannedsize) result = false;
                _isBusy = false;
            }
            return result;
        }

        public bool InsertFromStrArr(string[] sa, string state)
        {
            isBusy();
            bool result = true;
            if (!_isBusy)
            {
                _isBusy = true;
                NameMethod = "170.InsertFromStrArr";
                long plannedsize = sa.Length + Count;
                try
                {
                    //Array.Resize(ref Files, sa.Length + Count);
                    foreach (string s in sa)
                    //Parallel.ForEach<string>(sa, s =>
                    {
                        if (!s.Equals(""))
                        {
                            try
                            {
                                string[] sr = s.Split('|');
                                /*Files[Count].FileFullName = sr[0];
                                Files[Count].FileSize = Convert.ToInt64(sr[1]);
                                Files[Count].FileChangeTime = Convert.ToInt64(sr[2]);
                                Count++;
                                */
                                FileStruct fss = new FileStruct();
                                fss.Type = sr[0];
                                fss.FileFullName = sr[1];
                                fss.FileSize = Convert.ToInt64(sr[2]);
                                fss.FileChangeTime = Convert.ToInt64(sr[3]);
                                fss.FileState = state;
                                Files.Add(fss);
                            }
                            catch (Exception ex)
                            {
                                result = false;
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }//);
                }
                catch (Exception ex)
                {
                    result = false;
                    MessageBox.Show(ex.Message);
                }
                Count = Files.Count;
                if (Count != plannedsize) result = false;
                _isBusy = false;
            }
            return result;
        }

        public bool InsertFromStrArr(string[] sa)
        {
            isBusy();
            bool result = true;
            if (!_isBusy)
            {
                _isBusy = true;
                NameMethod = "214.InsertFromStrArr";
                long plannedsize = sa.Length + Count;
                try
                {
                    //Array.Resize(ref Files, sa.Length + Count);
                    foreach (string s in sa)
                    //Parallel.ForEach<string>(sa, s =>
                    {
                        try
                        {
                            string[] sr = s.Split('|');
                            /*Files[Count].FileFullName = sr[0];
                            Files[Count].FileSize = Convert.ToInt64(sr[1]);
                            Files[Count].FileChangeTime = Convert.ToInt64(sr[2]);
                            Files[Count].FileState = sr[3];
                            Count++;*/
                            FileStruct fss = new FileStruct();
                            fss.Type = sr[0];
                            fss.FileFullName = sr[1];
                            fss.FileSize = Convert.ToInt64(sr[2]);
                            fss.FileChangeTime = Convert.ToInt64(sr[3]);
                            fss.FileState = sr[4];
                            Files.Add(fss);
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
                Count = Files.Count;
                if (Count != plannedsize) result = false;
                _isBusy = false;
            }
            return result;
        }

        public string[] ToStringArray(ref string[] inpArray)
        {
            isBusy();
            if (!_isBusy)
            {
                _isBusy = true;
                NameMethod = "255.ToStringArray";
                inpArray = new string[Count];
                for (int i = 0; i < Count; i++)
                {
                    try
                    {
                        inpArray[i] = Files[i].Type + "|" + Files[i].FileFullName + "|" + Files[i].FileSize + "|" + Files[i].FileChangeTime + "|" + Files[i].FileState;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("210.Filedata", ex.Message);
                    }
                }
                _isBusy = false;
            }
            return inpArray;
        }

        public void Clear()
        {
            isBusy();
            if (!_isBusy)
            {
                _isBusy = true;
                NameMethod = "279.Clear";
                //Files = new FileStruct[0];
                Files.Clear();
                Count = 0;
                _isBusy = false;
            }
        }

        public void AddRow(string Type, string FileFullName, long FileSize, long FileChangeTime, string FileState = "")
        {
            isBusy();
            if (!_isBusy)
            {
                _isBusy = true;
                NameMethod = "292.AddRow";
                /*Count++;
                FileStruct[] _fs = new FileStruct[Count];
                int curs = 0;
                /*foreach (FileStruct fs in Files)
                {
                    _fs[curs] = fs;
                    curs++;
                }
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
                }
                _fs.CopyTo(Files, 0);
                _fs = null;
                */
                FileStruct fs = new FileStruct();
                fs.Type = Type;
                fs.FileFullName = FileFullName;
                fs.FileSize = FileSize;
                fs.FileChangeTime = FileChangeTime;
                fs.FileState = FileState;
                Files.Add(fs);
                Count = Files.Count;
                _isBusy = false;
            }
        }

        public void FindAndClearDuplicates()
        {
            isBusy();
            if (!_isBusy)
            {
                _isBusy = true;
                NameMethod = "320.FindAndClearDuplicates";
                int _delcnt = 0;
                Count = Files.Count;
                //for (int fs1 = 0; fs1 < Count; fs1++)
                Parallel.For(0, Count, fs1 =>
                {
                    if ((Files[fs1].FileState != "m") && (Files[fs1].FileState != "0"))
                    {
                        //for (int fs2 = (Count - 1); fs2 > fs1; fs2--)
                        for (int fs2 = fs1+1; fs2 < Count; fs2++)
                        {
                            if ((Files[fs1].FileFullName != null) && (Files[fs2].FileFullName != null) && ((Files[fs2].FileState != "m") && (Files[fs2].FileState != "0")))
                            {
                                if (Files[fs1].FileFullName == Files[fs2].FileFullName)
                                {
                                    FileStruct fss = new FileStruct();
                                    fss.Type = Files[fs1].Type;
                                    fss.FileFullName = Files[fs1].FileFullName;
                                    fss.FileSize = Files[fs1].FileSize;
                                    fss.FileChangeTime = Files[fs1].FileChangeTime;
                                    fss.FileState = Files[fs1].FileState;
                                    if ((Files[fs1].FileSize == Files[fs2].FileSize) && (Files[fs1].FileChangeTime == Files[fs2].FileChangeTime))
                                    {
                                        fss.FileState = "0";
                                        Files[fs1] = fss;
                                        Files[fs2] = fss;
                                        _delcnt += 2;
                                        fs2 = fs1;
                                        
                                    }
                                    else
                                    {
                                        fss.FileState = "m";
                                        Files[fs1] = fss;
                                        fss.FileState = "0";
                                        Files[fs2] = fss;
                                        _delcnt++;
                                        fs2 = fs1;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                });

                if ((Count - _delcnt) > 0)
                {
                    /* FileStruct[] _fs = new FileStruct[Count - _delcnt];
                     int tempcnt = 0;
                     for (int i = 0; i < Count; i++)
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
                     _fs = null;*/
                    //foreach (FileStruct fs in Files)
                    for (int i = (Count - 1); i >= 0; i--)
                    {
                        FileStruct fs = Files[i];

                        if (fs.FileState.Equals("0"))
                        {
                            Files.RemoveAt(i);
                        }
                    }
                    Count = Files.Count;
                }
                else
                {
                    _isBusy = false;
                    Clear();
                }
                _isBusy = false;
            }
        }

        public long GetTotalSize()
        {
            isBusy();
            long result = 0;
            if (!_isBusy)
            {
                _isBusy = true;
                NameMethod = "382.GetTotalSize";
                foreach (FileStruct fs in Files)
                {
                    result += fs.FileSize;
                }
                _isBusy = false;
            }
            return result;
        }

        private void isBusy()
        {
            /* while (_isBusy)
             {
                 Thread.Sleep(1);
                 //if (NameMethod == "320.FindAndClearDuplicates") Thread.Sleep(20); ;
             }*/
            return;
        }

    }
}
