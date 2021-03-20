﻿using System;
using System.Data;
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
            isBusy();
            if (!_isBusy)
            {
                _isBusy = true;
                NameMethod = "35.InsertFromDT";
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
                _isBusy = false;
            }
        }

        public void InsertFromDT(DataTable dt, string state)
        {
            isBusy();
            if (!_isBusy)
            {
                _isBusy = true;
                NameMethod = "62.InsertFromDT";
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
                _isBusy = false;
            }
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
                _isBusy = false;
            }
            return result;
        }

        public bool InsertFromFD(FileData fd, string state)
        {
            isBusy();
            bool result = true;
            if (!_isBusy)
            {
                _isBusy = true;
                NameMethod = "129.InsertFromFD";
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
                    Array.Resize(ref Files, sa.Length + Count);
                    foreach (string s in sa)
                    //Parallel.ForEach<string>(sa, s =>
                    {
                        if (!s.Equals(""))
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
                        }
                    }//);
                }
                catch (Exception ex)
                {
                    result = false;
                    MessageBox.Show(ex.Message);
                }
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
                        inpArray[i] = Files[i].FileFullName + "|" + Files[i].FileSize + "|" + Files[i].FileChangeTime + "|" + Files[i].FileState;
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
                Files = new FileStruct[0];
                Count = 0;
                _isBusy = false;
            }
        }

        public void AddRow(string FileFullName, long FileSize, long FileChangeTime, string FileState = "")
        {
            isBusy();
            if (!_isBusy)
            {
                _isBusy = true;
                NameMethod = "292.AddRow";
                Count++;
                FileStruct[] _fs = new FileStruct[Count];
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
                for (int fs1 = 0; fs1 < Count; fs1++)
                //Parallel.For(0, Count, fs1 =>
                  {
                    if ((!Files[fs1].FileState.Equals("m")) && (!Files[fs1].FileState.Equals("0")))
                    {
                        for (int fs2 = (Count - 1); fs2 > fs1; fs2--)
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
                                break;
                            }
                        }
                    }
                  }//);

                if ((Count - _delcnt) > 0)
                {
                    FileStruct[] _fs = new FileStruct[Count - _delcnt];
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
                    _fs = null;
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
