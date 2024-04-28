using System;
using System.Windows.Forms;

namespace ReserveCopier
{
    static class uniinvoker
    {
        public static void TryInvoke(Control obj, Action action)
        {
            try
            {
                if (obj.InvokeRequired)
                {
                    obj.Invoke((MethodInvoker)delegate
                    {
                        action();
                    });
                }
                else
                {
                    action();
                }
            }
            catch { }
        }
    }
}
