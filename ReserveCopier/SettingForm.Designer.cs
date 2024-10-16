﻿namespace ReserveCopier
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainSettingPanel = new System.Windows.Forms.Panel();
            this.lowCapacityPeriodComboBox = new System.Windows.Forms.ComboBox();
            this.DeleteOldPeriodComboBox = new System.Windows.Forms.ComboBox();
            this.ParallelCopy_Checkbox = new System.Windows.Forms.CheckBox();
            this.lowCapacityCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteOldCheckBox = new System.Windows.Forms.CheckBox();
            this.MinimizeInTrayCheckBox = new System.Windows.Forms.CheckBox();
            this.autoscroll_logDGV = new System.Windows.Forms.CheckBox();
            this.lowCapacityOldNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.minuts_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.deleteOldNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.hours_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Days_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.fullcopy_Combobox = new System.Windows.Forms.ComboBox();
            this.Mode_Combobox = new System.Windows.Forms.ComboBox();
            this.cancel_bttn = new System.Windows.Forms.Button();
            this.ok_bttn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OutPathBttn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.outpathTxtbx = new System.Windows.Forms.TextBox();
            this.DeletePathBttn = new System.Windows.Forms.Button();
            this.EditPathBttn = new System.Windows.Forms.Button();
            this.InputPathLstBX = new System.Windows.Forms.CheckedListBox();
            this.AddPathBttn = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.MainSettingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lowCapacityOldNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minuts_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteOldNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hours_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // MainSettingPanel
            // 
            this.MainSettingPanel.Controls.Add(this.lowCapacityPeriodComboBox);
            this.MainSettingPanel.Controls.Add(this.DeleteOldPeriodComboBox);
            this.MainSettingPanel.Controls.Add(this.ParallelCopy_Checkbox);
            this.MainSettingPanel.Controls.Add(this.lowCapacityCheckBox);
            this.MainSettingPanel.Controls.Add(this.deleteOldCheckBox);
            this.MainSettingPanel.Controls.Add(this.MinimizeInTrayCheckBox);
            this.MainSettingPanel.Controls.Add(this.autoscroll_logDGV);
            this.MainSettingPanel.Controls.Add(this.lowCapacityOldNumericUpDown);
            this.MainSettingPanel.Controls.Add(this.minuts_numericUpDown);
            this.MainSettingPanel.Controls.Add(this.deleteOldNumericUpDown);
            this.MainSettingPanel.Controls.Add(this.hours_numericUpDown);
            this.MainSettingPanel.Controls.Add(this.Days_checkedListBox);
            this.MainSettingPanel.Controls.Add(this.fullcopy_Combobox);
            this.MainSettingPanel.Controls.Add(this.Mode_Combobox);
            this.MainSettingPanel.Controls.Add(this.cancel_bttn);
            this.MainSettingPanel.Controls.Add(this.ok_bttn);
            this.MainSettingPanel.Controls.Add(this.label8);
            this.MainSettingPanel.Controls.Add(this.label7);
            this.MainSettingPanel.Controls.Add(this.label6);
            this.MainSettingPanel.Controls.Add(this.label5);
            this.MainSettingPanel.Controls.Add(this.label4);
            this.MainSettingPanel.Controls.Add(this.label3);
            this.MainSettingPanel.Controls.Add(this.label2);
            this.MainSettingPanel.Controls.Add(this.OutPathBttn);
            this.MainSettingPanel.Controls.Add(this.label1);
            this.MainSettingPanel.Controls.Add(this.outpathTxtbx);
            this.MainSettingPanel.Controls.Add(this.DeletePathBttn);
            this.MainSettingPanel.Controls.Add(this.EditPathBttn);
            this.MainSettingPanel.Controls.Add(this.InputPathLstBX);
            this.MainSettingPanel.Controls.Add(this.AddPathBttn);
            this.MainSettingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSettingPanel.Location = new System.Drawing.Point(0, 0);
            this.MainSettingPanel.Margin = new System.Windows.Forms.Padding(4);
            this.MainSettingPanel.Name = "MainSettingPanel";
            this.MainSettingPanel.Size = new System.Drawing.Size(1083, 690);
            this.MainSettingPanel.TabIndex = 0;
            // 
            // lowCapacityPeriodComboBox
            // 
            this.lowCapacityPeriodComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReserveCopier.Properties.Settings.Default, "ClearForFreeSpaceSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lowCapacityPeriodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lowCapacityPeriodComboBox.FormattingEnabled = true;
            this.lowCapacityPeriodComboBox.Items.AddRange(new object[] {
            "Минут",
            "Часов",
            "Дней",
            "Недель",
            "Месяцев"});
            this.lowCapacityPeriodComboBox.Location = new System.Drawing.Point(919, 533);
            this.lowCapacityPeriodComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.lowCapacityPeriodComboBox.Name = "lowCapacityPeriodComboBox";
            this.lowCapacityPeriodComboBox.Size = new System.Drawing.Size(119, 24);
            this.lowCapacityPeriodComboBox.TabIndex = 14;
            this.lowCapacityPeriodComboBox.Text = global::ReserveCopier.Properties.Settings.Default.ClearForFreeSpaceSize;
            // 
            // DeleteOldPeriodComboBox
            // 
            this.DeleteOldPeriodComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReserveCopier.Properties.Settings.Default, "DelPeriodStr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DeleteOldPeriodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeleteOldPeriodComboBox.FormattingEnabled = true;
            this.DeleteOldPeriodComboBox.Items.AddRange(new object[] {
            "Минут",
            "Часов",
            "Дней",
            "Недель",
            "Месяцев"});
            this.DeleteOldPeriodComboBox.Location = new System.Drawing.Point(853, 566);
            this.DeleteOldPeriodComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteOldPeriodComboBox.Name = "DeleteOldPeriodComboBox";
            this.DeleteOldPeriodComboBox.Size = new System.Drawing.Size(160, 24);
            this.DeleteOldPeriodComboBox.TabIndex = 14;
            this.DeleteOldPeriodComboBox.Text = global::ReserveCopier.Properties.Settings.Default.DelPeriodStr;
            // 
            // ParallelCopy_Checkbox
            // 
            this.ParallelCopy_Checkbox.AutoSize = true;
            this.ParallelCopy_Checkbox.Checked = global::ReserveCopier.Properties.Settings.Default.ParallelCopy;
            this.ParallelCopy_Checkbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ReserveCopier.Properties.Settings.Default, "ParallelCopy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ParallelCopy_Checkbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ParallelCopy_Checkbox.Location = new System.Drawing.Point(543, 471);
            this.ParallelCopy_Checkbox.Margin = new System.Windows.Forms.Padding(4);
            this.ParallelCopy_Checkbox.Name = "ParallelCopy_Checkbox";
            this.ParallelCopy_Checkbox.Size = new System.Drawing.Size(391, 24);
            this.ParallelCopy_Checkbox.TabIndex = 13;
            this.ParallelCopy_Checkbox.Text = "Параллельное копирование (высокая нагрузка)";
            this.ParallelCopy_Checkbox.UseVisualStyleBackColor = true;
            // 
            // lowCapacityCheckBox
            // 
            this.lowCapacityCheckBox.AutoSize = true;
            this.lowCapacityCheckBox.Checked = global::ReserveCopier.Properties.Settings.Default.ClearForFreeSpaceCheck;
            this.lowCapacityCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lowCapacityCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ReserveCopier.Properties.Settings.Default, "ClearForFreeSpaceCheck", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lowCapacityCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lowCapacityCheckBox.Location = new System.Drawing.Point(540, 532);
            this.lowCapacityCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.lowCapacityCheckBox.Name = "lowCapacityCheckBox";
            this.lowCapacityCheckBox.Size = new System.Drawing.Size(294, 24);
            this.lowCapacityCheckBox.TabIndex = 13;
            this.lowCapacityCheckBox.Text = "Удерживать место на диске более";
            this.lowCapacityCheckBox.UseVisualStyleBackColor = true;
            // 
            // deleteOldCheckBox
            // 
            this.deleteOldCheckBox.AutoSize = true;
            this.deleteOldCheckBox.Checked = global::ReserveCopier.Properties.Settings.Default.DeleteOld;
            this.deleteOldCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ReserveCopier.Properties.Settings.Default, "DeleteOld", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.deleteOldCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteOldCheckBox.Location = new System.Drawing.Point(540, 566);
            this.deleteOldCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.deleteOldCheckBox.Name = "deleteOldCheckBox";
            this.deleteOldCheckBox.Size = new System.Drawing.Size(225, 24);
            this.deleteOldCheckBox.TabIndex = 13;
            this.deleteOldCheckBox.Text = "Удалить резерв старше...";
            this.deleteOldCheckBox.UseVisualStyleBackColor = true;
            // 
            // MinimizeInTrayCheckBox
            // 
            this.MinimizeInTrayCheckBox.AutoSize = true;
            this.MinimizeInTrayCheckBox.Checked = global::ReserveCopier.Properties.Settings.Default.MinimizeInTray;
            this.MinimizeInTrayCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MinimizeInTrayCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ReserveCopier.Properties.Settings.Default, "MinimizeInTray", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.MinimizeInTrayCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinimizeInTrayCheckBox.Location = new System.Drawing.Point(540, 597);
            this.MinimizeInTrayCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeInTrayCheckBox.Name = "MinimizeInTrayCheckBox";
            this.MinimizeInTrayCheckBox.Size = new System.Drawing.Size(289, 24);
            this.MinimizeInTrayCheckBox.TabIndex = 13;
            this.MinimizeInTrayCheckBox.Text = "Сворачивать в трей при закрытии";
            this.MinimizeInTrayCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoscroll_logDGV
            // 
            this.autoscroll_logDGV.AutoSize = true;
            this.autoscroll_logDGV.Checked = global::ReserveCopier.Properties.Settings.Default.AutoScroolLog;
            this.autoscroll_logDGV.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ReserveCopier.Properties.Settings.Default, "AutoScroolLog", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.autoscroll_logDGV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.autoscroll_logDGV.Location = new System.Drawing.Point(543, 445);
            this.autoscroll_logDGV.Margin = new System.Windows.Forms.Padding(4);
            this.autoscroll_logDGV.Name = "autoscroll_logDGV";
            this.autoscroll_logDGV.Size = new System.Drawing.Size(180, 24);
            this.autoscroll_logDGV.TabIndex = 13;
            this.autoscroll_logDGV.Text = "автопрокрутка лога";
            this.autoscroll_logDGV.UseVisualStyleBackColor = true;
            // 
            // lowCapacityOldNumericUpDown
            // 
            this.lowCapacityOldNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ReserveCopier.Properties.Settings.Default, "ClearForFreeSpaceValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lowCapacityOldNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lowCapacityOldNumericUpDown.Location = new System.Drawing.Point(842, 532);
            this.lowCapacityOldNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.lowCapacityOldNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.lowCapacityOldNumericUpDown.Name = "lowCapacityOldNumericUpDown";
            this.lowCapacityOldNumericUpDown.Size = new System.Drawing.Size(71, 26);
            this.lowCapacityOldNumericUpDown.TabIndex = 11;
            this.lowCapacityOldNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lowCapacityOldNumericUpDown.Value = global::ReserveCopier.Properties.Settings.Default.ClearForFreeSpaceValue;
            // 
            // minuts_numericUpDown
            // 
            this.minuts_numericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ReserveCopier.Properties.Settings.Default, "PeriodicMinutes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.minuts_numericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minuts_numericUpDown.Location = new System.Drawing.Point(804, 359);
            this.minuts_numericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.minuts_numericUpDown.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.minuts_numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minuts_numericUpDown.Name = "minuts_numericUpDown";
            this.minuts_numericUpDown.Size = new System.Drawing.Size(71, 26);
            this.minuts_numericUpDown.TabIndex = 11;
            this.minuts_numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.minuts_numericUpDown.Value = global::ReserveCopier.Properties.Settings.Default.PeriodicMinutes;
            // 
            // deleteOldNumericUpDown
            // 
            this.deleteOldNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ReserveCopier.Properties.Settings.Default, "DelPeriodNum", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.deleteOldNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteOldNumericUpDown.Location = new System.Drawing.Point(774, 564);
            this.deleteOldNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.deleteOldNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.deleteOldNumericUpDown.Name = "deleteOldNumericUpDown";
            this.deleteOldNumericUpDown.Size = new System.Drawing.Size(71, 26);
            this.deleteOldNumericUpDown.TabIndex = 11;
            this.deleteOldNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.deleteOldNumericUpDown.Value = global::ReserveCopier.Properties.Settings.Default.DelPeriodNum;
            // 
            // hours_numericUpDown
            // 
            this.hours_numericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ReserveCopier.Properties.Settings.Default, "periodicHours", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.hours_numericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hours_numericUpDown.Location = new System.Drawing.Point(804, 320);
            this.hours_numericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.hours_numericUpDown.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.hours_numericUpDown.Name = "hours_numericUpDown";
            this.hours_numericUpDown.Size = new System.Drawing.Size(71, 26);
            this.hours_numericUpDown.TabIndex = 11;
            this.hours_numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.hours_numericUpDown.Value = global::ReserveCopier.Properties.Settings.Default.periodicHours;
            // 
            // Days_checkedListBox
            // 
            this.Days_checkedListBox.CheckOnClick = true;
            this.Days_checkedListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Days_checkedListBox.FormattingEnabled = true;
            this.Days_checkedListBox.Items.AddRange(new object[] {
            "Понедельник",
            "Вторник",
            "Среда",
            "Четверг",
            "Пятница",
            "Суббота",
            "Воскресенье"});
            this.Days_checkedListBox.Location = new System.Drawing.Point(543, 286);
            this.Days_checkedListBox.Margin = new System.Windows.Forms.Padding(4);
            this.Days_checkedListBox.Name = "Days_checkedListBox";
            this.Days_checkedListBox.Size = new System.Drawing.Size(244, 151);
            this.Days_checkedListBox.TabIndex = 10;
            // 
            // fullcopy_Combobox
            // 
            this.fullcopy_Combobox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReserveCopier.Properties.Settings.Default, "FullCopyPeriodic", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fullcopy_Combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fullcopy_Combobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fullcopy_Combobox.FormattingEnabled = true;
            this.fullcopy_Combobox.Items.AddRange(new object[] {
            "Ежедневно",
            "Еженедельно",
            "Ежемесячно",
            "Ежегодно"});
            this.fullcopy_Combobox.Location = new System.Drawing.Point(540, 210);
            this.fullcopy_Combobox.Margin = new System.Windows.Forms.Padding(4);
            this.fullcopy_Combobox.Name = "fullcopy_Combobox";
            this.fullcopy_Combobox.Size = new System.Drawing.Size(530, 28);
            this.fullcopy_Combobox.TabIndex = 9;
            this.fullcopy_Combobox.Text = global::ReserveCopier.Properties.Settings.Default.FullCopyPeriodic;
            // 
            // Mode_Combobox
            // 
            this.Mode_Combobox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReserveCopier.Properties.Settings.Default, "CopyModeValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Mode_Combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Mode_Combobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Mode_Combobox.FormattingEnabled = true;
            this.Mode_Combobox.Items.AddRange(new object[] {
            "Полное",
            "Разностное относительно первой копии",
            "Разностное относительно последней копии"});
            this.Mode_Combobox.Location = new System.Drawing.Point(542, 136);
            this.Mode_Combobox.Margin = new System.Windows.Forms.Padding(4);
            this.Mode_Combobox.Name = "Mode_Combobox";
            this.Mode_Combobox.Size = new System.Drawing.Size(530, 28);
            this.Mode_Combobox.TabIndex = 9;
            this.Mode_Combobox.Text = global::ReserveCopier.Properties.Settings.Default.CopyModeValue;
            this.Mode_Combobox.TextChanged += new System.EventHandler(this.Mode_Combobox_TextChanged);
            // 
            // cancel_bttn
            // 
            this.cancel_bttn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel_bttn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_bttn.Location = new System.Drawing.Point(721, 645);
            this.cancel_bttn.Margin = new System.Windows.Forms.Padding(4);
            this.cancel_bttn.Name = "cancel_bttn";
            this.cancel_bttn.Size = new System.Drawing.Size(176, 37);
            this.cancel_bttn.TabIndex = 8;
            this.cancel_bttn.Text = "Отменить";
            this.cancel_bttn.UseVisualStyleBackColor = true;
            // 
            // ok_bttn
            // 
            this.ok_bttn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ok_bttn.Location = new System.Drawing.Point(906, 645);
            this.ok_bttn.Margin = new System.Windows.Forms.Padding(4);
            this.ok_bttn.Name = "ok_bttn";
            this.ok_bttn.Size = new System.Drawing.Size(169, 37);
            this.ok_bttn.TabIndex = 7;
            this.ok_bttn.Text = "OK";
            this.ok_bttn.UseVisualStyleBackColor = true;
            this.ok_bttn.Click += new System.EventHandler(this.ok_bttn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(874, 357);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 25);
            this.label8.TabIndex = 5;
            this.label8.Text = "минут";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(882, 357);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 25);
            this.label7.TabIndex = 5;
            this.label7.Text = "часов";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(874, 322);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "часов";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(797, 286);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Периодичность";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(537, 251);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(297, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Создание разностной копии";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(537, 181);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Создание полной копии";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(536, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Режим копирования";
            // 
            // OutPathBttn
            // 
            this.OutPathBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OutPathBttn.Location = new System.Drawing.Point(876, 78);
            this.OutPathBttn.Margin = new System.Windows.Forms.Padding(4);
            this.OutPathBttn.Name = "OutPathBttn";
            this.OutPathBttn.Size = new System.Drawing.Size(195, 36);
            this.OutPathBttn.TabIndex = 6;
            this.OutPathBttn.Text = "Указать путь";
            this.OutPathBttn.UseVisualStyleBackColor = true;
            this.OutPathBttn.Click += new System.EventHandler(this.OutPathBttn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(535, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Путь для сохранения";
            // 
            // outpathTxtbx
            // 
            this.outpathTxtbx.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReserveCopier.Properties.Settings.Default, "OutputPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.outpathTxtbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outpathTxtbx.Location = new System.Drawing.Point(541, 50);
            this.outpathTxtbx.Margin = new System.Windows.Forms.Padding(4);
            this.outpathTxtbx.Name = "outpathTxtbx";
            this.outpathTxtbx.Size = new System.Drawing.Size(530, 26);
            this.outpathTxtbx.TabIndex = 4;
            this.outpathTxtbx.Text = global::ReserveCopier.Properties.Settings.Default.OutputPath;
            // 
            // DeletePathBttn
            // 
            this.DeletePathBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeletePathBttn.Location = new System.Drawing.Point(384, 4);
            this.DeletePathBttn.Margin = new System.Windows.Forms.Padding(4);
            this.DeletePathBttn.Name = "DeletePathBttn";
            this.DeletePathBttn.Size = new System.Drawing.Size(137, 42);
            this.DeletePathBttn.TabIndex = 3;
            this.DeletePathBttn.Text = "Удалить";
            this.DeletePathBttn.UseVisualStyleBackColor = true;
            this.DeletePathBttn.Click += new System.EventHandler(this.DeletePathBttn_Click);
            // 
            // EditPathBttn
            // 
            this.EditPathBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditPathBttn.Location = new System.Drawing.Point(180, 4);
            this.EditPathBttn.Margin = new System.Windows.Forms.Padding(4);
            this.EditPathBttn.Name = "EditPathBttn";
            this.EditPathBttn.Size = new System.Drawing.Size(137, 42);
            this.EditPathBttn.TabIndex = 3;
            this.EditPathBttn.Text = "Изменить";
            this.EditPathBttn.UseVisualStyleBackColor = true;
            this.EditPathBttn.Click += new System.EventHandler(this.EditPathBttn_Click);
            // 
            // InputPathLstBX
            // 
            this.InputPathLstBX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.InputPathLstBX.CheckOnClick = true;
            this.InputPathLstBX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputPathLstBX.HorizontalScrollbar = true;
            this.InputPathLstBX.Location = new System.Drawing.Point(0, 50);
            this.InputPathLstBX.Margin = new System.Windows.Forms.Padding(4);
            this.InputPathLstBX.Name = "InputPathLstBX";
            this.InputPathLstBX.Size = new System.Drawing.Size(520, 633);
            this.InputPathLstBX.TabIndex = 2;
            // 
            // AddPathBttn
            // 
            this.AddPathBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddPathBttn.Location = new System.Drawing.Point(4, 4);
            this.AddPathBttn.Margin = new System.Windows.Forms.Padding(4);
            this.AddPathBttn.Name = "AddPathBttn";
            this.AddPathBttn.Size = new System.Drawing.Size(131, 42);
            this.AddPathBttn.TabIndex = 1;
            this.AddPathBttn.Text = "Добавить";
            this.AddPathBttn.UseVisualStyleBackColor = true;
            this.AddPathBttn.Click += new System.EventHandler(this.AddPathBttn_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel_bttn;
            this.ClientSize = new System.Drawing.Size(1083, 690);
            this.Controls.Add(this.MainSettingPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.Text = "Настройки";
            this.MainSettingPanel.ResumeLayout(false);
            this.MainSettingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lowCapacityOldNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minuts_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteOldNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hours_numericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainSettingPanel;
        private System.Windows.Forms.CheckedListBox InputPathLstBX;
        private System.Windows.Forms.Button AddPathBttn;
        private System.Windows.Forms.Button DeletePathBttn;
        private System.Windows.Forms.Button EditPathBttn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button cancel_bttn;
        private System.Windows.Forms.Button ok_bttn;
        private System.Windows.Forms.Button OutPathBttn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox outpathTxtbx;
        private System.Windows.Forms.ComboBox Mode_Combobox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox fullcopy_Combobox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox Days_checkedListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown hours_numericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown minuts_numericUpDown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox autoscroll_logDGV;
        private System.Windows.Forms.CheckBox ParallelCopy_Checkbox;
        private System.Windows.Forms.ComboBox DeleteOldPeriodComboBox;
        private System.Windows.Forms.CheckBox deleteOldCheckBox;
        private System.Windows.Forms.NumericUpDown deleteOldNumericUpDown;
        private System.Windows.Forms.CheckBox MinimizeInTrayCheckBox;
        private System.Windows.Forms.ComboBox lowCapacityPeriodComboBox;
        private System.Windows.Forms.CheckBox lowCapacityCheckBox;
        private System.Windows.Forms.NumericUpDown lowCapacityOldNumericUpDown;
    }
}