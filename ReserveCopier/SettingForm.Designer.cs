namespace ReserveCopier
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
            this.hours_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Days_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.fullcopy_Combobox = new System.Windows.Forms.ComboBox();
            this.Mode_Combobox = new System.Windows.Forms.ComboBox();
            this.cancel_bttn = new System.Windows.Forms.Button();
            this.ok_bttn = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.hours_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // MainSettingPanel
            // 
            this.MainSettingPanel.Controls.Add(this.hours_numericUpDown);
            this.MainSettingPanel.Controls.Add(this.Days_checkedListBox);
            this.MainSettingPanel.Controls.Add(this.fullcopy_Combobox);
            this.MainSettingPanel.Controls.Add(this.Mode_Combobox);
            this.MainSettingPanel.Controls.Add(this.cancel_bttn);
            this.MainSettingPanel.Controls.Add(this.ok_bttn);
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
            this.MainSettingPanel.Name = "MainSettingPanel";
            this.MainSettingPanel.Size = new System.Drawing.Size(832, 566);
            this.MainSettingPanel.TabIndex = 0;
            // 
            // hours_numericUpDown
            // 
            this.hours_numericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ReserveCopier.Properties.Settings.Default, "periodicHours", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.hours_numericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hours_numericUpDown.Location = new System.Drawing.Point(601, 305);
            this.hours_numericUpDown.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.hours_numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hours_numericUpDown.Name = "hours_numericUpDown";
            this.hours_numericUpDown.Size = new System.Drawing.Size(53, 26);
            this.hours_numericUpDown.TabIndex = 11;
            this.hours_numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.hours_numericUpDown.Value = global::ReserveCopier.Properties.Settings.Default.periodicHours;
            this.hours_numericUpDown.ValueChanged += new System.EventHandler(this.hours_numericUpDown_ValueChanged);
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
            this.Days_checkedListBox.Location = new System.Drawing.Point(406, 277);
            this.Days_checkedListBox.Name = "Days_checkedListBox";
            this.Days_checkedListBox.Size = new System.Drawing.Size(184, 151);
            this.Days_checkedListBox.TabIndex = 10;
            // 
            // fullcopy_Combobox
            // 
            this.fullcopy_Combobox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReserveCopier.Properties.Settings.Default, "FullCopyPeriodic", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fullcopy_Combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fullcopy_Combobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fullcopy_Combobox.FormattingEnabled = true;
            this.fullcopy_Combobox.Items.AddRange(new object[] {
            "Еженедельно",
            "Ежемесячно",
            "Ежегодно"});
            this.fullcopy_Combobox.Location = new System.Drawing.Point(406, 205);
            this.fullcopy_Combobox.Name = "fullcopy_Combobox";
            this.fullcopy_Combobox.Size = new System.Drawing.Size(414, 28);
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
            this.Mode_Combobox.Location = new System.Drawing.Point(406, 128);
            this.Mode_Combobox.Name = "Mode_Combobox";
            this.Mode_Combobox.Size = new System.Drawing.Size(414, 28);
            this.Mode_Combobox.TabIndex = 9;
            this.Mode_Combobox.Text = global::ReserveCopier.Properties.Settings.Default.CopyModeValue;
            this.Mode_Combobox.TextChanged += new System.EventHandler(this.Mode_Combobox_TextChanged);
            // 
            // cancel_bttn
            // 
            this.cancel_bttn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_bttn.Location = new System.Drawing.Point(555, 534);
            this.cancel_bttn.Name = "cancel_bttn";
            this.cancel_bttn.Size = new System.Drawing.Size(132, 30);
            this.cancel_bttn.TabIndex = 8;
            this.cancel_bttn.Text = "Отменить";
            this.cancel_bttn.UseVisualStyleBackColor = true;
            // 
            // ok_bttn
            // 
            this.ok_bttn.Location = new System.Drawing.Point(693, 534);
            this.ok_bttn.Name = "ok_bttn";
            this.ok_bttn.Size = new System.Drawing.Size(127, 30);
            this.ok_bttn.TabIndex = 7;
            this.ok_bttn.Text = "OK";
            this.ok_bttn.UseVisualStyleBackColor = true;
            this.ok_bttn.Click += new System.EventHandler(this.ok_bttn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(654, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "часов";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(596, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Периодичность";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(401, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(297, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Создание разностной копии";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(401, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Создание полной копии";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(401, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Режим копирования";
            // 
            // OutPathBttn
            // 
            this.OutPathBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OutPathBttn.Location = new System.Drawing.Point(674, 70);
            this.OutPathBttn.Name = "OutPathBttn";
            this.OutPathBttn.Size = new System.Drawing.Size(146, 29);
            this.OutPathBttn.TabIndex = 6;
            this.OutPathBttn.Text = "Указать путь";
            this.OutPathBttn.UseVisualStyleBackColor = true;
            this.OutPathBttn.Click += new System.EventHandler(this.OutPathBttn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(401, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Путь для сохранения";
            // 
            // outpathTxtbx
            // 
            this.outpathTxtbx.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReserveCopier.Properties.Settings.Default, "OutputPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.outpathTxtbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outpathTxtbx.Location = new System.Drawing.Point(406, 40);
            this.outpathTxtbx.Name = "outpathTxtbx";
            this.outpathTxtbx.Size = new System.Drawing.Size(414, 26);
            this.outpathTxtbx.TabIndex = 4;
            this.outpathTxtbx.Text = global::ReserveCopier.Properties.Settings.Default.OutputPath;
            // 
            // DeletePathBttn
            // 
            this.DeletePathBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeletePathBttn.Location = new System.Drawing.Point(288, 3);
            this.DeletePathBttn.Name = "DeletePathBttn";
            this.DeletePathBttn.Size = new System.Drawing.Size(103, 34);
            this.DeletePathBttn.TabIndex = 3;
            this.DeletePathBttn.Text = "Удалить";
            this.DeletePathBttn.UseVisualStyleBackColor = true;
            this.DeletePathBttn.Click += new System.EventHandler(this.DeletePathBttn_Click);
            // 
            // EditPathBttn
            // 
            this.EditPathBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditPathBttn.Location = new System.Drawing.Point(135, 3);
            this.EditPathBttn.Name = "EditPathBttn";
            this.EditPathBttn.Size = new System.Drawing.Size(103, 34);
            this.EditPathBttn.TabIndex = 3;
            this.EditPathBttn.Text = "Изменить";
            this.EditPathBttn.UseVisualStyleBackColor = true;
            this.EditPathBttn.Click += new System.EventHandler(this.EditPathBttn_Click);
            // 
            // InputPathLstBX
            // 
            this.InputPathLstBX.CheckOnClick = true;
            this.InputPathLstBX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputPathLstBX.HorizontalScrollbar = true;
            this.InputPathLstBX.Location = new System.Drawing.Point(0, 40);
            this.InputPathLstBX.Name = "InputPathLstBX";
            this.InputPathLstBX.Size = new System.Drawing.Size(391, 514);
            this.InputPathLstBX.TabIndex = 2;
            // 
            // AddPathBttn
            // 
            this.AddPathBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddPathBttn.Location = new System.Drawing.Point(3, 3);
            this.AddPathBttn.Name = "AddPathBttn";
            this.AddPathBttn.Size = new System.Drawing.Size(98, 34);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel_bttn;
            this.ClientSize = new System.Drawing.Size(832, 566);
            this.Controls.Add(this.MainSettingPanel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(848, 605);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(848, 605);
            this.Name = "SettingForm";
            this.Text = "Настройки";
            this.MainSettingPanel.ResumeLayout(false);
            this.MainSettingPanel.PerformLayout();
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
    }
}