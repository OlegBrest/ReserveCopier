﻿namespace ReserveCopier
{
    partial class MainReservCopyer
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainReservCopyer));
            this.MainPanel = new System.Windows.Forms.Panel();
            this.Path_txtBx = new System.Windows.Forms.TextBox();
            this.autostart_chkbx = new System.Windows.Forms.CheckBox();
            this.dataGridViewprogress = new System.Windows.Forms.DataGridView();
            this.SpeedLabel = new System.Windows.Forms.Label();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.FileLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelSize = new System.Windows.Forms.Label();
            this.labelFiles = new System.Windows.Forms.Label();
            this.DirLabel = new System.Windows.Forms.Label();
            this.labelDirs = new System.Windows.Forms.Label();
            this.start_bttn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.main_toolstrip_panel = new System.Windows.Forms.ToolStrip();
            this.fileMenuBttn = new System.Windows.Forms.ToolStripDropDownButton();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.main_tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.reserv_dgv = new System.Windows.Forms.DataGridView();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MaximizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReserveContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewprogress)).BeginInit();
            this.main_toolstrip_panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.main_tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reserv_dgv)).BeginInit();
            this.NotifyContextMenuStrip.SuspendLayout();
            this.ReserveContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.Path_txtBx);
            this.MainPanel.Controls.Add(this.autostart_chkbx);
            this.MainPanel.Controls.Add(this.dataGridViewprogress);
            this.MainPanel.Controls.Add(this.SpeedLabel);
            this.MainPanel.Controls.Add(this.SizeLabel);
            this.MainPanel.Controls.Add(this.FileLabel);
            this.MainPanel.Controls.Add(this.label2);
            this.MainPanel.Controls.Add(this.labelSize);
            this.MainPanel.Controls.Add(this.labelFiles);
            this.MainPanel.Controls.Add(this.DirLabel);
            this.MainPanel.Controls.Add(this.labelDirs);
            this.MainPanel.Controls.Add(this.start_bttn);
            this.MainPanel.Controls.Add(this.label1);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(3, 3);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(999, 498);
            this.MainPanel.TabIndex = 0;
            // 
            // Path_txtBx
            // 
            this.Path_txtBx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Path_txtBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Path_txtBx.Location = new System.Drawing.Point(240, 3);
            this.Path_txtBx.Multiline = true;
            this.Path_txtBx.Name = "Path_txtBx";
            this.Path_txtBx.Size = new System.Drawing.Size(749, 37);
            this.Path_txtBx.TabIndex = 10;
            // 
            // autostart_chkbx
            // 
            this.autostart_chkbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.autostart_chkbx.AutoSize = true;
            this.autostart_chkbx.Checked = global::ReserveCopier.Properties.Settings.Default.AutoStartCopy;
            this.autostart_chkbx.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ReserveCopier.Properties.Settings.Default, "AutoStartCopy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.autostart_chkbx.Location = new System.Drawing.Point(780, 417);
            this.autostart_chkbx.Name = "autostart_chkbx";
            this.autostart_chkbx.Size = new System.Drawing.Size(209, 24);
            this.autostart_chkbx.TabIndex = 9;
            this.autostart_chkbx.Text = "Автоматический режим";
            this.autostart_chkbx.UseVisualStyleBackColor = true;
            this.autostart_chkbx.CheckedChanged += new System.EventHandler(this.autostart_chkbx_CheckedChanged);
            // 
            // dataGridViewprogress
            // 
            this.dataGridViewprogress.AllowUserToAddRows = false;
            this.dataGridViewprogress.AllowUserToDeleteRows = false;
            this.dataGridViewprogress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewprogress.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewprogress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewprogress.Location = new System.Drawing.Point(5, 44);
            this.dataGridViewprogress.Name = "dataGridViewprogress";
            this.dataGridViewprogress.ReadOnly = true;
            this.dataGridViewprogress.Size = new System.Drawing.Size(984, 367);
            this.dataGridViewprogress.TabIndex = 5;
            this.dataGridViewprogress.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewprogress_DataError);
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SpeedLabel.AutoSize = true;
            this.SpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SpeedLabel.Location = new System.Drawing.Point(86, 471);
            this.SpeedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(18, 20);
            this.SpeedLabel.TabIndex = 4;
            this.SpeedLabel.Text = "0";
            // 
            // SizeLabel
            // 
            this.SizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SizeLabel.Location = new System.Drawing.Point(86, 451);
            this.SizeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(18, 20);
            this.SizeLabel.TabIndex = 4;
            this.SizeLabel.Text = "0";
            // 
            // FileLabel
            // 
            this.FileLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FileLabel.AutoSize = true;
            this.FileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FileLabel.Location = new System.Drawing.Point(86, 431);
            this.FileLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FileLabel.Name = "FileLabel";
            this.FileLabel.Size = new System.Drawing.Size(18, 20);
            this.FileLabel.TabIndex = 4;
            this.FileLabel.Text = "0";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(4, 471);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Скорость :";
            // 
            // labelSize
            // 
            this.labelSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSize.AutoSize = true;
            this.labelSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSize.Location = new System.Drawing.Point(4, 451);
            this.labelSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(69, 20);
            this.labelSize.TabIndex = 4;
            this.labelSize.Text = "Размер:";
            // 
            // labelFiles
            // 
            this.labelFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelFiles.AutoSize = true;
            this.labelFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFiles.Location = new System.Drawing.Point(4, 431);
            this.labelFiles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFiles.Name = "labelFiles";
            this.labelFiles.Size = new System.Drawing.Size(74, 20);
            this.labelFiles.TabIndex = 4;
            this.labelFiles.Text = "Файлов:";
            // 
            // DirLabel
            // 
            this.DirLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DirLabel.AutoSize = true;
            this.DirLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DirLabel.Location = new System.Drawing.Point(62, 411);
            this.DirLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DirLabel.Name = "DirLabel";
            this.DirLabel.Size = new System.Drawing.Size(18, 20);
            this.DirLabel.TabIndex = 4;
            this.DirLabel.Text = "0";
            // 
            // labelDirs
            // 
            this.labelDirs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDirs.AutoSize = true;
            this.labelDirs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDirs.Location = new System.Drawing.Point(4, 411);
            this.labelDirs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDirs.Name = "labelDirs";
            this.labelDirs.Size = new System.Drawing.Size(60, 20);
            this.labelDirs.TabIndex = 4;
            this.labelDirs.Text = "Папок:";
            // 
            // start_bttn
            // 
            this.start_bttn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.start_bttn.Location = new System.Drawing.Point(780, 453);
            this.start_bttn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.start_bttn.Name = "start_bttn";
            this.start_bttn.Size = new System.Drawing.Size(209, 35);
            this.start_bttn.TabIndex = 3;
            this.start_bttn.Text = "Выполнить сейчас";
            this.start_bttn.UseVisualStyleBackColor = true;
            this.start_bttn.Click += new System.EventHandler(this.start_bttn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(4, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Прогресс выполнения";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(230, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(766, 25);
            this.progressBar.TabIndex = 7;
            this.progressBar.Visible = false;
            // 
            // main_toolstrip_panel
            // 
            this.main_toolstrip_panel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.main_toolstrip_panel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuBttn});
            this.main_toolstrip_panel.Location = new System.Drawing.Point(0, 0);
            this.main_toolstrip_panel.Name = "main_toolstrip_panel";
            this.main_toolstrip_panel.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.main_toolstrip_panel.Size = new System.Drawing.Size(1013, 28);
            this.main_toolstrip_panel.TabIndex = 0;
            this.main_toolstrip_panel.Text = "toolStrip1";
            // 
            // fileMenuBttn
            // 
            this.fileMenuBttn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileMenuBttn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsToolStripMenuItem});
            this.fileMenuBttn.Image = ((System.Drawing.Image)(resources.GetObject("fileMenuBttn.Image")));
            this.fileMenuBttn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fileMenuBttn.Name = "fileMenuBttn";
            this.fileMenuBttn.Size = new System.Drawing.Size(60, 25);
            this.fileMenuBttn.Text = "Файл";
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.SettingsToolStripMenuItem.Text = "Настройки";
            this.SettingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.main_tabControl);
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Controls.Add(this.main_toolstrip_panel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1013, 565);
            this.panel1.TabIndex = 1;
            // 
            // main_tabControl
            // 
            this.main_tabControl.Controls.Add(this.tabPage1);
            this.main_tabControl.Controls.Add(this.tabPage2);
            this.main_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_tabControl.Location = new System.Drawing.Point(0, 28);
            this.main_tabControl.Name = "main_tabControl";
            this.main_tabControl.SelectedIndex = 0;
            this.main_tabControl.Size = new System.Drawing.Size(1013, 537);
            this.main_tabControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.MainPanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1005, 504);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Главная";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.reserv_dgv);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1005, 504);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Обзор резервных копий";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // test_dgv
            // 
            this.reserv_dgv.AllowUserToAddRows = false;
            this.reserv_dgv.AllowUserToDeleteRows = false;
            this.reserv_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reserv_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.reserv_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reserv_dgv.ContextMenuStrip = this.ReserveContextMenuStrip;
            this.reserv_dgv.Location = new System.Drawing.Point(3, 3);
            this.reserv_dgv.MultiSelect = false;
            this.reserv_dgv.Name = "test_dgv";
            this.reserv_dgv.ReadOnly = true;
            this.reserv_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.reserv_dgv.Size = new System.Drawing.Size(1002, 493);
            this.reserv_dgv.TabIndex = 0;
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.ContextMenuStrip = this.NotifyContextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Резервное копирование";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // NotifyContextMenuStrip
            // 
            this.NotifyContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MaximizeToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.NotifyContextMenuStrip.Name = "NotifyContextMenuStrip";
            this.NotifyContextMenuStrip.Size = new System.Drawing.Size(194, 48);
            // 
            // MaximizeToolStripMenuItem
            // 
            this.MaximizeToolStripMenuItem.Name = "MaximizeToolStripMenuItem";
            this.MaximizeToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.MaximizeToolStripMenuItem.Text = "Развернуть";
            this.MaximizeToolStripMenuItem.Click += new System.EventHandler(this.MaximizeToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.ExitToolStripMenuItem.Text = "Выйти из программы";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // ReserveContextMenuStrip
            // 
            this.ReserveContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenPathToolStripMenuItem,
            this.DeleteToolStripMenuItem});
            this.ReserveContextMenuStrip.Name = "ReserveContextMenuStrip";
            this.ReserveContextMenuStrip.Size = new System.Drawing.Size(213, 48);
            // 
            // OpenPathToolStripMenuItem
            // 
            this.OpenPathToolStripMenuItem.Name = "OpenPathToolStripMenuItem";
            this.OpenPathToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.OpenPathToolStripMenuItem.Text = "Открыть место хранения";
            this.OpenPathToolStripMenuItem.Click += new System.EventHandler(this.OpenPathToolStripMenuItem_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.DeleteToolStripMenuItem.Text = "Удалить";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // MainReservCopyer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 565);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(816, 532);
            this.Name = "MainReservCopyer";
            this.Text = "Резервное копирование";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainReservCopyer_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainReservCopyer_FormClosed);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewprogress)).EndInit();
            this.main_toolstrip_panel.ResumeLayout(false);
            this.main_toolstrip_panel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.main_tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reserv_dgv)).EndInit();
            this.NotifyContextMenuStrip.ResumeLayout(false);
            this.ReserveContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.ToolStrip main_toolstrip_panel;
        private System.Windows.Forms.ToolStripDropDownButton fileMenuBttn;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.Button start_bttn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label FileLabel;
        private System.Windows.Forms.Label labelFiles;
        private System.Windows.Forms.Label DirLabel;
        private System.Windows.Forms.Label labelDirs;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.DataGridView dataGridViewprogress;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label SpeedLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl main_tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox autostart_chkbx;
        private System.Windows.Forms.TextBox Path_txtBx;
        private System.Windows.Forms.DataGridView reserv_dgv;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip NotifyContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MaximizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ReserveContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem OpenPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
    }
}

