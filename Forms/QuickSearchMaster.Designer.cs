namespace WindowsQuickSearch.Forms
{
    partial class QuickSearchMaster
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickSearchMaster));
            tableLayoutPanel1 = new TableLayoutPanel();
            SearchBox = new TextBox();
            RightArrow = new PictureBox();
            LeftArrow = new PictureBox();
            DirctoryBox = new TextBox();
            MainLayout = new TableLayoutPanel();
            MainBarTable = new TableLayoutPanel();
            CloseBox = new PictureBox();
            MaximiseBox = new PictureBox();
            MinimiseBox = new PictureBox();
            Logo = new PictureBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            SettingsBox = new PictureBox();
            WindowontopBox = new PictureBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            FilesFoundLabel = new Label();
            FoldersFoundLabel = new Label();
            FoldersSearchedLabel = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            ExplorerContent = new FlowLayoutPanel();
            DriveContent = new FlowLayoutPanel();
            HotbarFlowLayout = new FlowLayoutPanel();
            notifyIcon = new NotifyIcon(components);
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RightArrow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LeftArrow).BeginInit();
            MainLayout.SuspendLayout();
            MainBarTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CloseBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MaximiseBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinimiseBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Logo).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SettingsBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WindowontopBox).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 8;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(SearchBox, 6, 0);
            tableLayoutPanel1.Controls.Add(RightArrow, 2, 0);
            tableLayoutPanel1.Controls.Add(LeftArrow, 1, 0);
            tableLayoutPanel1.Controls.Add(DirctoryBox, 4, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 30);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1374, 50);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // SearchBox
            // 
            SearchBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            SearchBox.BackColor = Color.FromArgb(64, 64, 64);
            SearchBox.BorderStyle = BorderStyle.None;
            SearchBox.Font = new Font("Unispace", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            SearchBox.Location = new Point(1109, 15);
            SearchBox.Margin = new Padding(0);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(244, 20);
            SearchBox.TabIndex = 3;
            SearchBox.Text = "Search...";
            SearchBox.KeyPress += SearchBox_KeyPress;
            // 
            // RightArrow
            // 
            RightArrow.BackgroundImageLayout = ImageLayout.None;
            RightArrow.Cursor = Cursors.Hand;
            RightArrow.Dock = DockStyle.Fill;
            RightArrow.Image = (Image)resources.GetObject("RightArrow.Image");
            RightArrow.Location = new Point(60, 5);
            RightArrow.Margin = new Padding(0, 5, 5, 5);
            RightArrow.Name = "RightArrow";
            RightArrow.Size = new Size(45, 40);
            RightArrow.SizeMode = PictureBoxSizeMode.Zoom;
            RightArrow.TabIndex = 1;
            RightArrow.TabStop = false;
            RightArrow.Click += RightArrow_Click;
            RightArrow.MouseDown += RightArrow_MouseDown;
            RightArrow.MouseEnter += RightArrow_MouseEnter;
            RightArrow.MouseLeave += RightArrow_MouseLeave;
            RightArrow.MouseUp += RightArrow_MouseUp;
            // 
            // LeftArrow
            // 
            LeftArrow.BackgroundImageLayout = ImageLayout.None;
            LeftArrow.Cursor = Cursors.Hand;
            LeftArrow.Dock = DockStyle.Fill;
            LeftArrow.Image = (Image)resources.GetObject("LeftArrow.Image");
            LeftArrow.Location = new Point(15, 5);
            LeftArrow.Margin = new Padding(5, 5, 0, 5);
            LeftArrow.Name = "LeftArrow";
            LeftArrow.Size = new Size(45, 40);
            LeftArrow.SizeMode = PictureBoxSizeMode.Zoom;
            LeftArrow.TabIndex = 0;
            LeftArrow.TabStop = false;
            LeftArrow.Click += LeftArrow_Click;
            LeftArrow.MouseDown += LeftArrow_MouseDown;
            LeftArrow.MouseEnter += LeftArrow_MouseEnter;
            LeftArrow.MouseLeave += LeftArrow_MouseLeave;
            LeftArrow.MouseUp += LeftArrow_MouseUp;
            // 
            // DirctoryBox
            // 
            DirctoryBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            DirctoryBox.BackColor = Color.FromArgb(64, 64, 64);
            DirctoryBox.BorderStyle = BorderStyle.None;
            DirctoryBox.Font = new Font("Unispace", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            DirctoryBox.Location = new Point(120, 15);
            DirctoryBox.Margin = new Padding(0);
            DirctoryBox.Name = "DirctoryBox";
            DirctoryBox.Size = new Size(979, 20);
            DirctoryBox.TabIndex = 2;
            DirctoryBox.WordWrap = false;
            DirctoryBox.KeyPress += DirctoryBox_KeyPress;
            // 
            // MainLayout
            // 
            MainLayout.BackColor = Color.FromArgb(34, 34, 34);
            MainLayout.ColumnCount = 1;
            MainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            MainLayout.Controls.Add(tableLayoutPanel1, 0, 1);
            MainLayout.Controls.Add(MainBarTable, 0, 0);
            MainLayout.Controls.Add(tableLayoutPanel2, 0, 3);
            MainLayout.Controls.Add(tableLayoutPanel4, 0, 2);
            MainLayout.Dock = DockStyle.Fill;
            MainLayout.Location = new Point(0, 0);
            MainLayout.Margin = new Padding(0);
            MainLayout.Name = "MainLayout";
            MainLayout.RowCount = 4;
            MainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            MainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            MainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            MainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            MainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            MainLayout.Size = new Size(1374, 648);
            MainLayout.TabIndex = 1;
            // 
            // MainBarTable
            // 
            MainBarTable.BackColor = Color.FromArgb(42, 42, 42);
            MainBarTable.ColumnCount = 6;
            MainBarTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            MainBarTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            MainBarTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            MainBarTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            MainBarTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            MainBarTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            MainBarTable.Controls.Add(CloseBox, 5, 0);
            MainBarTable.Controls.Add(MaximiseBox, 4, 0);
            MainBarTable.Controls.Add(MinimiseBox, 3, 0);
            MainBarTable.Controls.Add(Logo, 0, 0);
            MainBarTable.Dock = DockStyle.Fill;
            MainBarTable.Location = new Point(0, 0);
            MainBarTable.Margin = new Padding(0);
            MainBarTable.Name = "MainBarTable";
            MainBarTable.RowCount = 1;
            MainBarTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            MainBarTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            MainBarTable.Size = new Size(1374, 30);
            MainBarTable.TabIndex = 2;
            MainBarTable.MouseDown += MainBarTable_MouseDown;
            MainBarTable.MouseMove += MainBarTable_MouseMove;
            MainBarTable.MouseUp += MainBarTable_MouseUp;
            // 
            // CloseBox
            // 
            CloseBox.Dock = DockStyle.Fill;
            CloseBox.Image = (Image)resources.GetObject("CloseBox.Image");
            CloseBox.Location = new Point(1324, 0);
            CloseBox.Margin = new Padding(0);
            CloseBox.Name = "CloseBox";
            CloseBox.Size = new Size(50, 30);
            CloseBox.SizeMode = PictureBoxSizeMode.Zoom;
            CloseBox.TabIndex = 6;
            CloseBox.TabStop = false;
            CloseBox.MouseClick += CloseBox_MouseClick;
            CloseBox.MouseDown += CloseBox_MouseDown;
            CloseBox.MouseEnter += Close_MouseEnter;
            CloseBox.MouseLeave += Close_MouseLeave;
            // 
            // MaximiseBox
            // 
            MaximiseBox.Dock = DockStyle.Fill;
            MaximiseBox.Image = (Image)resources.GetObject("MaximiseBox.Image");
            MaximiseBox.Location = new Point(1274, 0);
            MaximiseBox.Margin = new Padding(0);
            MaximiseBox.Name = "MaximiseBox";
            MaximiseBox.Size = new Size(50, 30);
            MaximiseBox.SizeMode = PictureBoxSizeMode.Zoom;
            MaximiseBox.TabIndex = 5;
            MaximiseBox.TabStop = false;
            MaximiseBox.MouseDown += MaximiseBox_MouseDown;
            MaximiseBox.MouseEnter += MaximiseBox_MouseEnter;
            MaximiseBox.MouseLeave += MaximiseBox_MouseLeave;
            MaximiseBox.MouseUp += MaximiseBox_MouseUp;
            // 
            // MinimiseBox
            // 
            MinimiseBox.Dock = DockStyle.Fill;
            MinimiseBox.Image = (Image)resources.GetObject("MinimiseBox.Image");
            MinimiseBox.Location = new Point(1224, 0);
            MinimiseBox.Margin = new Padding(0);
            MinimiseBox.Name = "MinimiseBox";
            MinimiseBox.Size = new Size(50, 30);
            MinimiseBox.SizeMode = PictureBoxSizeMode.Zoom;
            MinimiseBox.TabIndex = 4;
            MinimiseBox.TabStop = false;
            MinimiseBox.MouseDown += MinimiseBox_MouseDown;
            MinimiseBox.MouseEnter += MinimiseBox_MouseEnter;
            MinimiseBox.MouseLeave += MinimiseBox_MouseLeave;
            MinimiseBox.MouseUp += MinimiseBox_MouseUp;
            // 
            // Logo
            // 
            Logo.Dock = DockStyle.Fill;
            Logo.Image = (Image)resources.GetObject("Logo.Image");
            Logo.Location = new Point(3, 3);
            Logo.Name = "Logo";
            Logo.Size = new Size(24, 24);
            Logo.SizeMode = PictureBoxSizeMode.Zoom;
            Logo.TabIndex = 1;
            Logo.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            tableLayoutPanel2.Controls.Add(SettingsBox, 2, 0);
            tableLayoutPanel2.Controls.Add(WindowontopBox, 1, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 618);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1374, 30);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // SettingsBox
            // 
            SettingsBox.BackColor = Color.FromArgb(42, 42, 42);
            SettingsBox.Dock = DockStyle.Fill;
            SettingsBox.Image = (Image)resources.GetObject("SettingsBox.Image");
            SettingsBox.Location = new Point(1344, 1);
            SettingsBox.Margin = new Padding(0, 1, 0, 0);
            SettingsBox.Name = "SettingsBox";
            SettingsBox.Size = new Size(30, 29);
            SettingsBox.SizeMode = PictureBoxSizeMode.Zoom;
            SettingsBox.TabIndex = 8;
            SettingsBox.TabStop = false;
            SettingsBox.Click += SettingsBox_Click;
            SettingsBox.MouseEnter += SettingsBox_MouseEnter;
            SettingsBox.MouseLeave += SettingsBox_MouseLeave;
            // 
            // WindowontopBox
            // 
            WindowontopBox.BackgroundImage = (Image)resources.GetObject("WindowontopBox.BackgroundImage");
            WindowontopBox.BackgroundImageLayout = ImageLayout.Zoom;
            WindowontopBox.Image = (Image)resources.GetObject("WindowontopBox.Image");
            WindowontopBox.Location = new Point(1284, 0);
            WindowontopBox.Margin = new Padding(0);
            WindowontopBox.Name = "WindowontopBox";
            WindowontopBox.Size = new Size(60, 30);
            WindowontopBox.SizeMode = PictureBoxSizeMode.Zoom;
            WindowontopBox.TabIndex = 0;
            WindowontopBox.TabStop = false;
            WindowontopBox.Click += WindowontopBox_Click;
            WindowontopBox.MouseEnter += WindowontopBox_MouseEnter;
            WindowontopBox.MouseLeave += WindowontopBox_MouseLeave;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.Controls.Add(FilesFoundLabel, 2, 0);
            tableLayoutPanel3.Controls.Add(FoldersFoundLabel, 1, 0);
            tableLayoutPanel3.Controls.Add(FoldersSearchedLabel, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Margin = new Padding(0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(1284, 30);
            tableLayoutPanel3.TabIndex = 9;
            // 
            // FilesFoundLabel
            // 
            FilesFoundLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            FilesFoundLabel.AutoSize = true;
            FilesFoundLabel.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point);
            FilesFoundLabel.ForeColor = Color.FromArgb(64, 64, 64);
            FilesFoundLabel.Location = new Point(859, 8);
            FilesFoundLabel.Name = "FilesFoundLabel";
            FilesFoundLabel.Size = new Size(422, 14);
            FilesFoundLabel.TabIndex = 16;
            FilesFoundLabel.Text = "Files found:";
            // 
            // FoldersFoundLabel
            // 
            FoldersFoundLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            FoldersFoundLabel.AutoSize = true;
            FoldersFoundLabel.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point);
            FoldersFoundLabel.ForeColor = Color.FromArgb(64, 64, 64);
            FoldersFoundLabel.Location = new Point(431, 8);
            FoldersFoundLabel.Name = "FoldersFoundLabel";
            FoldersFoundLabel.Size = new Size(422, 14);
            FoldersFoundLabel.TabIndex = 15;
            FoldersFoundLabel.Text = "Folders Found 0";
            // 
            // FoldersSearchedLabel
            // 
            FoldersSearchedLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            FoldersSearchedLabel.AutoSize = true;
            FoldersSearchedLabel.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point);
            FoldersSearchedLabel.ForeColor = Color.FromArgb(64, 64, 64);
            FoldersSearchedLabel.Location = new Point(3, 8);
            FoldersSearchedLabel.Name = "FoldersSearchedLabel";
            FoldersSearchedLabel.Size = new Size(422, 14);
            FoldersSearchedLabel.TabIndex = 14;
            FoldersSearchedLabel.Text = "Folders/Files Searched:";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 8;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Controls.Add(ExplorerContent, 1, 0);
            tableLayoutPanel4.Controls.Add(DriveContent, 6, 0);
            tableLayoutPanel4.Controls.Add(HotbarFlowLayout, 6, 2);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 80);
            tableLayoutPanel4.Margin = new Padding(0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(1374, 538);
            tableLayoutPanel4.TabIndex = 4;
            // 
            // ExplorerContent
            // 
            ExplorerContent.AutoScroll = true;
            ExplorerContent.BackColor = Color.FromArgb(29, 29, 29);
            tableLayoutPanel4.SetColumnSpan(ExplorerContent, 4);
            ExplorerContent.Dock = DockStyle.Fill;
            ExplorerContent.Location = new Point(10, 0);
            ExplorerContent.Margin = new Padding(0);
            ExplorerContent.Name = "ExplorerContent";
            tableLayoutPanel4.SetRowSpan(ExplorerContent, 3);
            ExplorerContent.Size = new Size(1089, 538);
            ExplorerContent.TabIndex = 7;
            // 
            // DriveContent
            // 
            DriveContent.AutoScroll = true;
            DriveContent.BackColor = Color.FromArgb(29, 29, 29);
            DriveContent.Dock = DockStyle.Fill;
            DriveContent.Location = new Point(1109, 0);
            DriveContent.Margin = new Padding(0);
            DriveContent.Name = "DriveContent";
            DriveContent.Size = new Size(244, 100);
            DriveContent.TabIndex = 8;
            // 
            // HotbarFlowLayout
            // 
            HotbarFlowLayout.AutoScroll = true;
            HotbarFlowLayout.BackColor = Color.FromArgb(29, 29, 29);
            HotbarFlowLayout.Dock = DockStyle.Fill;
            HotbarFlowLayout.Location = new Point(1109, 110);
            HotbarFlowLayout.Margin = new Padding(0);
            HotbarFlowLayout.Name = "HotbarFlowLayout";
            HotbarFlowLayout.Size = new Size(244, 428);
            HotbarFlowLayout.TabIndex = 9;
            // 
            // notifyIcon
            // 
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "QuickSearch";
            notifyIcon.MouseClick += notifyIcon_MouseClick;
            // 
            // QuickSearchMaster
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1374, 648);
            ControlBox = false;
            Controls.Add(MainLayout);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(540, 500);
            Name = "QuickSearchMaster";
            StartPosition = FormStartPosition.CenterScreen;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)RightArrow).EndInit();
            ((System.ComponentModel.ISupportInitialize)LeftArrow).EndInit();
            MainLayout.ResumeLayout(false);
            MainBarTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)CloseBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)MaximiseBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)MinimiseBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)Logo).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SettingsBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)WindowontopBox).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TextBox SearchBox;
        private PictureBox RightArrow;
        private PictureBox LeftArrow;
        private TextBox DirctoryBox;
        private TableLayoutPanel MainLayout;
        private TableLayoutPanel MainBarTable;
        private PictureBox CloseBox;
        private PictureBox MaximiseBox;
        private PictureBox MinimiseBox;
        private PictureBox Logo;
        private TableLayoutPanel tableLayoutPanel2;
        private PictureBox WindowontopBox;
        private NotifyIcon notifyIcon;
        private PictureBox SettingsBox;
        private TableLayoutPanel tableLayoutPanel3;
        public Label FoldersSearchedLabel;
        private Label FoldersFoundLabel;
        private Label FilesFoundLabel;
        private MenuStrip DriveSelectMenuStrip;       
        private TableLayoutPanel tableLayoutPanel4;
        private FlowLayoutPanel ExplorerContent;
        private FlowLayoutPanel DriveContent;
        private FlowLayoutPanel HotbarFlowLayout;
        private QuickSearch.Classes.SubForms.HardDrive hardDrive1;
        private QuickSearch.Classes.SubForms.HardDrive hardDrive2;
        private QuickSearch.Classes.SubForms.HardDrive hardDrive3;
    }
}