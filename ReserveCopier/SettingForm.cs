using System;
using System.Windows.Forms;

namespace ReserveCopier
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
            string[] inputPaths = Properties.Settings.Default.InputPaths.Split('\n');
            if ((inputPaths.Length > 1) || ((inputPaths.Length == 1) && (!inputPaths[0].Equals(String.Empty))))
                InputPathLstBX.Items.AddRange(inputPaths);
            Mode_Combobox_TextChanged(Mode_Combobox, new EventArgs());
            string daysOfWeek = Properties.Settings.Default.DayOfWeekCheck;
            int[] DaysArray = (int[])Enum.GetValues(typeof(Day));
            foreach (int intday in DaysArray)
            {
                if (daysOfWeek.Contains(Enum.GetName(typeof(Day), intday)))
                {
                    Days_checkedListBox.SetItemChecked(intday, true);
                }
            }
        }

        private void AddPathBttn_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                InputPathLstBX.Items.Add(folderBrowserDialog.SelectedPath);
            }
        }

        private void EditPathBttn_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                InputPathLstBX.Items[InputPathLstBX.Items.IndexOf(InputPathLstBX.CheckedItems[0])] = folderBrowserDialog.SelectedPath;
            }
        }

        private void DeletePathBttn_Click(object sender, EventArgs e)
        {
            int selected = InputPathLstBX.CheckedItems.Count - 1;
            for (int i = selected; i >= 0; i--)
            {
                InputPathLstBX.Items.Remove(InputPathLstBX.CheckedItems[i]);
            }
        }

        private void OutPathBttn_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                outpathTxtbx.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void ok_bttn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.OutputPath = outpathTxtbx.Text;
            string inputPaths = "";
            foreach (string item in InputPathLstBX.Items)
            {
                if (!inputPaths.Equals("")) inputPaths += '\n';
                inputPaths += item;
            }
            Properties.Settings.Default.InputPaths = inputPaths;
            Properties.Settings.Default.CopyModeValue = Mode_Combobox.Text;
            Properties.Settings.Default.FullCopyPeriodic = fullcopy_Combobox.Text;
            Properties.Settings.Default.DeleteOld = deleteOldCheckBox.Checked;
            Properties.Settings.Default.DelPeriodNum = deleteOldNumericUpDown.Value;
            Properties.Settings.Default.DelPeriodStr = DeleteOldPeriodComboBox.Text;
            Properties.Settings.Default.MinimizeInTray = MinimizeInTrayCheckBox.Checked;
            string daysofweek = "";
            for (int i = 0; i < Days_checkedListBox.Items.Count; i++)
            {
                if (Days_checkedListBox.GetItemChecked(i))
                {
                    if (!daysofweek.Equals("")) daysofweek += "|";
                    daysofweek += Enum.GetName(typeof(Day), i);
                }
            }
            Properties.Settings.Default.DayOfWeekCheck = daysofweek;
            Properties.Settings.Default.periodicHours = hours_numericUpDown.Value;
            Properties.Settings.Default.PeriodicMinutes = minuts_numericUpDown.Value;
            Properties.Settings.Default.AutoScroolLog = autoscroll_logDGV.Checked;
            Properties.Settings.Default.ParallelCopy = ParallelCopy_Checkbox.Checked;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            this.DialogResult = DialogResult.OK;
        }

        private void Mode_Combobox_TextChanged(object sender, EventArgs e)
        {
            if (Mode_Combobox.Text.Equals("Полное"))
            {
                //fullcopy_Combobox.Enabled = false;
                label3.Enabled = false;
                Days_checkedListBox.Enabled = false;
                label4.Enabled = false;
                label5.Enabled = false;
                hours_numericUpDown.Enabled = false;
                label6.Enabled = false;
                minuts_numericUpDown.Enabled = false;
                label7.Enabled = false;
            }
            else
            {
                //fullcopy_Combobox.Enabled = true;
                label3.Enabled = true;
                Days_checkedListBox.Enabled = true;
                label4.Enabled = true;
                label5.Enabled = true;
                hours_numericUpDown.Enabled = true;
                label6.Enabled = true;
                minuts_numericUpDown.Enabled = true;
                label7.Enabled = true;
            }
        }

        private void hours_numericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
