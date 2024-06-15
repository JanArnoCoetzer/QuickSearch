namespace WindowsQuickSearch.Forms
{
    partial class Settings
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
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            label3 = new Label();
            label2 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            tableLayoutPanel6 = new TableLayoutPanel();
            label7 = new Label();
            StartWithWindowsCheck = new CheckBox();
            tableLayoutPanel7 = new TableLayoutPanel();
            label8 = new Label();
            IndexOnStartCheck = new CheckBox();
            tableLayoutPanel8 = new TableLayoutPanel();
            label9 = new Label();
            DelayListBox = new ListBox();
            tableLayoutPanel9 = new TableLayoutPanel();
            label10 = new Label();
            SmartIndexCheck = new CheckBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            LastIndexedLabel = new Label();
            StartIndexing = new Button();
            label4 = new Label();
            tableLayoutPanel10 = new TableLayoutPanel();
            label11 = new Label();
            MultiThreadingCheck = new CheckBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            ThreadCountLabel = new Label();
            ThreadCountTickBar = new TrackBar();
            label6 = new Label();
            tableLayoutPanel11 = new TableLayoutPanel();
            label12 = new Label();
            label5 = new Label();
            tableLayoutPanel12 = new TableLayoutPanel();
            label13 = new Label();
            label14 = new Label();
            CloseButton = new Button();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel10.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ThreadCountTickBar).BeginInit();
            tableLayoutPanel11.SuspendLayout();
            tableLayoutPanel12.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(CloseButton, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(384, 584);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Unispace", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(378, 50);
            label1.TabIndex = 0;
            label1.Text = "Settings";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(label3, 0, 2);
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutPanel2.Controls.Add(flowLayoutPanel2, 0, 3);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 50);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 151F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            tableLayoutPanel2.Size = new Size(384, 468);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Unispace", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(3, 181);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.No;
            label3.Size = new Size(378, 30);
            label3.TabIndex = 2;
            label3.Text = "Indexing";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Unispace", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(378, 30);
            label2.TabIndex = 1;
            label2.Text = "General";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(tableLayoutPanel6);
            flowLayoutPanel1.Controls.Add(tableLayoutPanel7);
            flowLayoutPanel1.Controls.Add(tableLayoutPanel8);
            flowLayoutPanel1.Controls.Add(tableLayoutPanel9);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 30);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(384, 151);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel6.ColumnCount = 5;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 131F));
            tableLayoutPanel6.Controls.Add(label7, 1, 0);
            tableLayoutPanel6.Controls.Add(StartWithWindowsCheck, 3, 0);
            tableLayoutPanel6.Location = new Point(3, 3);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tableLayoutPanel6.Size = new Size(381, 30);
            tableLayoutPanel6.TabIndex = 0;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Unispace", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Gray;
            label7.Location = new Point(23, 6);
            label7.Name = "label7";
            label7.Size = new Size(194, 18);
            label7.TabIndex = 2;
            label7.Text = "Start with Windows";
            // 
            // StartWithWindowsCheck
            // 
            StartWithWindowsCheck.Anchor = AnchorStyles.None;
            StartWithWindowsCheck.Appearance = Appearance.Button;
            StartWithWindowsCheck.BackColor = Color.Silver;
            StartWithWindowsCheck.CheckAlign = ContentAlignment.MiddleCenter;
            StartWithWindowsCheck.FlatAppearance.CheckedBackColor = Color.FromArgb(0, 204, 204);
            StartWithWindowsCheck.FlatStyle = FlatStyle.Flat;
            StartWithWindowsCheck.Location = new Point(237, 7);
            StartWithWindowsCheck.Name = "StartWithWindowsCheck";
            StartWithWindowsCheck.Size = new Size(15, 15);
            StartWithWindowsCheck.TabIndex = 3;
            StartWithWindowsCheck.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel7.ColumnCount = 5;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 116F));
            tableLayoutPanel7.Controls.Add(label8, 1, 0);
            tableLayoutPanel7.Controls.Add(IndexOnStartCheck, 3, 0);
            tableLayoutPanel7.Location = new Point(3, 39);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tableLayoutPanel7.Size = new Size(381, 30);
            tableLayoutPanel7.TabIndex = 1;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Unispace", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.Gray;
            label8.Location = new Point(23, 6);
            label8.Name = "label8";
            label8.Size = new Size(194, 18);
            label8.TabIndex = 2;
            label8.Text = "Index on start";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // IndexOnStartCheck
            // 
            IndexOnStartCheck.Anchor = AnchorStyles.None;
            IndexOnStartCheck.Appearance = Appearance.Button;
            IndexOnStartCheck.BackColor = Color.Silver;
            IndexOnStartCheck.CheckAlign = ContentAlignment.MiddleCenter;
            IndexOnStartCheck.FlatAppearance.CheckedBackColor = Color.FromArgb(0, 204, 204);
            IndexOnStartCheck.FlatStyle = FlatStyle.Flat;
            IndexOnStartCheck.Location = new Point(237, 7);
            IndexOnStartCheck.Name = "IndexOnStartCheck";
            IndexOnStartCheck.Size = new Size(15, 15);
            IndexOnStartCheck.TabIndex = 3;
            IndexOnStartCheck.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel8.ColumnCount = 5;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel8.Controls.Add(label9, 1, 0);
            tableLayoutPanel8.Controls.Add(DelayListBox, 3, 0);
            tableLayoutPanel8.Location = new Point(3, 75);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 1;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tableLayoutPanel8.Size = new Size(381, 30);
            tableLayoutPanel8.TabIndex = 2;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Unispace", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.Gray;
            label9.Location = new Point(23, 6);
            label9.Name = "label9";
            label9.Size = new Size(194, 18);
            label9.TabIndex = 2;
            label9.Text = "Delay";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DelayListBox
            // 
            DelayListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DelayListBox.BackColor = Color.FromArgb(34, 34, 34);
            DelayListBox.BorderStyle = BorderStyle.FixedSingle;
            DelayListBox.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point);
            DelayListBox.ForeColor = Color.Silver;
            DelayListBox.FormattingEnabled = true;
            DelayListBox.ItemHeight = 14;
            DelayListBox.Items.AddRange(new object[] { "5s", "10s", "30s", "1 min", "5 mins" });
            DelayListBox.Location = new Point(233, 3);
            DelayListBox.Name = "DelayListBox";
            DelayListBox.Size = new Size(119, 16);
            DelayListBox.TabIndex = 3;
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel9.ColumnCount = 5;
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 115F));
            tableLayoutPanel9.Controls.Add(label10, 1, 0);
            tableLayoutPanel9.Controls.Add(SmartIndexCheck, 3, 0);
            tableLayoutPanel9.Location = new Point(3, 111);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 1;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tableLayoutPanel9.Size = new Size(381, 30);
            tableLayoutPanel9.TabIndex = 3;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Unispace", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.Gray;
            label10.Location = new Point(23, 6);
            label10.Name = "label10";
            label10.Size = new Size(194, 18);
            label10.TabIndex = 2;
            label10.Text = "Smart Indexing";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // SmartIndexCheck
            // 
            SmartIndexCheck.Anchor = AnchorStyles.None;
            SmartIndexCheck.Appearance = Appearance.Button;
            SmartIndexCheck.BackColor = Color.Silver;
            SmartIndexCheck.CheckAlign = ContentAlignment.MiddleCenter;
            SmartIndexCheck.FlatAppearance.CheckedBackColor = Color.FromArgb(0, 204, 204);
            SmartIndexCheck.FlatStyle = FlatStyle.Flat;
            SmartIndexCheck.Location = new Point(237, 7);
            SmartIndexCheck.Name = "SmartIndexCheck";
            SmartIndexCheck.Size = new Size(15, 15);
            SmartIndexCheck.TabIndex = 3;
            SmartIndexCheck.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(tableLayoutPanel5);
            flowLayoutPanel2.Controls.Add(tableLayoutPanel10);
            flowLayoutPanel2.Controls.Add(tableLayoutPanel3);
            flowLayoutPanel2.Controls.Add(tableLayoutPanel11);
            flowLayoutPanel2.Controls.Add(tableLayoutPanel12);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(0, 211);
            flowLayoutPanel2.Margin = new Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(384, 257);
            flowLayoutPanel2.TabIndex = 4;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel5.ColumnCount = 5;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 127F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(LastIndexedLabel, 1, 1);
            tableLayoutPanel5.Controls.Add(StartIndexing, 3, 0);
            tableLayoutPanel5.Controls.Add(label4, 1, 0);
            tableLayoutPanel5.Location = new Point(0, 5);
            tableLayoutPanel5.Margin = new Padding(0, 5, 0, 0);
            tableLayoutPanel5.MinimumSize = new Size(200, 50);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 52.63158F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 47.36842F));
            tableLayoutPanel5.Size = new Size(381, 57);
            tableLayoutPanel5.TabIndex = 1;
            // 
            // LastIndexedLabel
            // 
            LastIndexedLabel.AutoSize = true;
            LastIndexedLabel.Dock = DockStyle.Top;
            LastIndexedLabel.Font = new Font("Unispace", 9.749999F, FontStyle.Bold, GraphicsUnit.Point);
            LastIndexedLabel.ForeColor = Color.Gray;
            LastIndexedLabel.Location = new Point(23, 30);
            LastIndexedLabel.Name = "LastIndexedLabel";
            LastIndexedLabel.Size = new Size(194, 15);
            LastIndexedLabel.TabIndex = 2;
            LastIndexedLabel.Text = "10/10/1010";
            LastIndexedLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // StartIndexing
            // 
            StartIndexing.Anchor = AnchorStyles.Left;
            StartIndexing.AutoSize = true;
            StartIndexing.FlatStyle = FlatStyle.Flat;
            StartIndexing.Font = new Font("Unispace", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            StartIndexing.ForeColor = Color.Silver;
            StartIndexing.Location = new Point(230, 13);
            StartIndexing.Margin = new Padding(0);
            StartIndexing.Name = "StartIndexing";
            tableLayoutPanel5.SetRowSpan(StartIndexing, 2);
            StartIndexing.Size = new Size(71, 31);
            StartIndexing.TabIndex = 0;
            StartIndexing.Text = "Index";
            StartIndexing.UseVisualStyleBackColor = true;
            StartIndexing.Click += StartIndexing_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Bottom;
            label4.Font = new Font("Unispace", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(23, 12);
            label4.Name = "label4";
            label4.Size = new Size(194, 18);
            label4.TabIndex = 1;
            label4.Text = "Last Indexed:";
            // 
            // tableLayoutPanel10
            // 
            tableLayoutPanel10.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel10.ColumnCount = 5;
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 116F));
            tableLayoutPanel10.Controls.Add(label11, 1, 0);
            tableLayoutPanel10.Controls.Add(MultiThreadingCheck, 3, 0);
            tableLayoutPanel10.Location = new Point(0, 62);
            tableLayoutPanel10.Margin = new Padding(0);
            tableLayoutPanel10.Name = "tableLayoutPanel10";
            tableLayoutPanel10.RowCount = 1;
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tableLayoutPanel10.Size = new Size(381, 30);
            tableLayoutPanel10.TabIndex = 4;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new Font("Unispace", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = Color.Gray;
            label11.Location = new Point(23, 6);
            label11.Name = "label11";
            label11.Size = new Size(194, 18);
            label11.TabIndex = 2;
            label11.Text = "MultiThreading";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MultiThreadingCheck
            // 
            MultiThreadingCheck.Anchor = AnchorStyles.None;
            MultiThreadingCheck.Appearance = Appearance.Button;
            MultiThreadingCheck.BackColor = Color.Silver;
            MultiThreadingCheck.CheckAlign = ContentAlignment.MiddleCenter;
            MultiThreadingCheck.FlatAppearance.CheckedBackColor = Color.FromArgb(0, 204, 204);
            MultiThreadingCheck.FlatStyle = FlatStyle.Flat;
            MultiThreadingCheck.Location = new Point(237, 7);
            MultiThreadingCheck.Name = "MultiThreadingCheck";
            MultiThreadingCheck.Size = new Size(15, 15);
            MultiThreadingCheck.TabIndex = 3;
            MultiThreadingCheck.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel3.ColumnCount = 5;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 87F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 209F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 23F));
            tableLayoutPanel3.Controls.Add(ThreadCountLabel, 2, 0);
            tableLayoutPanel3.Controls.Add(ThreadCountTickBar, 3, 0);
            tableLayoutPanel3.Controls.Add(label6, 1, 0);
            tableLayoutPanel3.Location = new Point(0, 97);
            tableLayoutPanel3.Margin = new Padding(0, 5, 0, 0);
            tableLayoutPanel3.MinimumSize = new Size(200, 50);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(381, 57);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // ThreadCountLabel
            // 
            ThreadCountLabel.AutoSize = true;
            ThreadCountLabel.Dock = DockStyle.Left;
            ThreadCountLabel.Font = new Font("Unispace", 9.749999F, FontStyle.Bold, GraphicsUnit.Point);
            ThreadCountLabel.ForeColor = Color.Gray;
            ThreadCountLabel.Location = new Point(110, 0);
            ThreadCountLabel.Name = "ThreadCountLabel";
            ThreadCountLabel.Size = new Size(23, 57);
            ThreadCountLabel.TabIndex = 3;
            ThreadCountLabel.Text = "99";
            ThreadCountLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ThreadCountTickBar
            // 
            ThreadCountTickBar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            ThreadCountTickBar.AutoSize = false;
            ThreadCountTickBar.Location = new Point(150, 8);
            ThreadCountTickBar.Name = "ThreadCountTickBar";
            ThreadCountTickBar.Size = new Size(203, 41);
            ThreadCountTickBar.TabIndex = 2;
            ThreadCountTickBar.TickStyle = TickStyle.Both;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Unispace", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Gray;
            label6.Location = new Point(23, 19);
            label6.Name = "label6";
            label6.Size = new Size(81, 18);
            label6.TabIndex = 1;
            label6.Text = "Threads:";
            // 
            // tableLayoutPanel11
            // 
            tableLayoutPanel11.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel11.ColumnCount = 5;
            tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 126F));
            tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 22F));
            tableLayoutPanel11.Controls.Add(label12, 3, 0);
            tableLayoutPanel11.Controls.Add(label5, 1, 0);
            tableLayoutPanel11.Location = new Point(0, 154);
            tableLayoutPanel11.Margin = new Padding(0);
            tableLayoutPanel11.Name = "tableLayoutPanel11";
            tableLayoutPanel11.RowCount = 1;
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tableLayoutPanel11.Size = new Size(381, 30);
            tableLayoutPanel11.TabIndex = 5;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Font = new Font("Unispace", 9.749999F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = Color.Gray;
            label12.Location = new Point(233, 7);
            label12.Name = "label12";
            label12.Size = new Size(120, 15);
            label12.TabIndex = 3;
            label12.Text = "50s/TB";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Unispace", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.Gray;
            label5.Location = new Point(23, 0);
            label5.Name = "label5";
            label5.Size = new Size(194, 30);
            label5.TabIndex = 2;
            label5.Text = "Expected Indexing Time:";
            label5.TextAlign = ContentAlignment.BottomLeft;
            // 
            // tableLayoutPanel12
            // 
            tableLayoutPanel12.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel12.ColumnCount = 5;
            tableLayoutPanel12.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel12.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel12.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanel12.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 126F));
            tableLayoutPanel12.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanel12.Controls.Add(label13, 3, 0);
            tableLayoutPanel12.Controls.Add(label14, 1, 0);
            tableLayoutPanel12.Location = new Point(0, 184);
            tableLayoutPanel12.Margin = new Padding(0);
            tableLayoutPanel12.Name = "tableLayoutPanel12";
            tableLayoutPanel12.RowCount = 1;
            tableLayoutPanel12.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tableLayoutPanel12.Size = new Size(381, 30);
            tableLayoutPanel12.TabIndex = 6;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Font = new Font("Unispace", 9.749999F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = Color.Gray;
            label13.Location = new Point(233, 7);
            label13.Name = "label13";
            label13.Size = new Size(120, 15);
            label13.TabIndex = 3;
            label13.Text = "1min 30s";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label14.AutoSize = true;
            label14.Font = new Font("Unispace", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label14.ForeColor = Color.Gray;
            label14.Location = new Point(23, 6);
            label14.Name = "label14";
            label14.Size = new Size(194, 18);
            label14.TabIndex = 2;
            label14.Text = "Total Time:";
            // 
            // CloseButton
            // 
            CloseButton.Anchor = AnchorStyles.None;
            CloseButton.FlatStyle = FlatStyle.Flat;
            CloseButton.Font = new Font("Unispace", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            CloseButton.ForeColor = Color.Silver;
            CloseButton.Location = new Point(150, 523);
            CloseButton.Margin = new Padding(0);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(83, 35);
            CloseButton.TabIndex = 2;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Margin = new Padding(0, 10, 0, 10);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 4;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(200, 100);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(36, 36, 36);
            ClientSize = new Size(384, 584);
            ControlBox = false;
            Controls.Add(tableLayoutPanel1);
            MaximizeBox = false;
            MaximumSize = new Size(400, 600);
            MinimizeBox = false;
            MinimumSize = new Size(400, 600);
            Name = "Settings";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            tableLayoutPanel9.ResumeLayout(false);
            tableLayoutPanel9.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            tableLayoutPanel10.ResumeLayout(false);
            tableLayoutPanel10.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ThreadCountTickBar).EndInit();
            tableLayoutPanel11.ResumeLayout(false);
            tableLayoutPanel11.PerformLayout();
            tableLayoutPanel12.ResumeLayout(false);
            tableLayoutPanel12.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label3;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel4;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel5;
        private Button StartIndexing;
        private Label label4;
        private Label LastIndexedLabel;
        private Button CloseButton;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label6;
        private Label ThreadCountLabel;
        private TableLayoutPanel tableLayoutPanel6;
        private Label label7;
        private CheckBox StartWithWindowsCheck;
        private TableLayoutPanel tableLayoutPanel7;
        private Label label8;
        private CheckBox IndexOnStartCheck;
        private TableLayoutPanel tableLayoutPanel8;
        private Label label9;
        private ListBox DelayListBox;
        private TableLayoutPanel tableLayoutPanel9;
        private Label label10;
        private CheckBox SmartIndexCheck;
        private TableLayoutPanel tableLayoutPanel10;
        private Label label11;
        private CheckBox MultiThreadingCheck;
        private TableLayoutPanel tableLayoutPanel11;
        private Label label5;
        private Label label12;
        private TableLayoutPanel tableLayoutPanel12;
        private Label label13;
        private Label label14;
        private TrackBar ThreadCountTickBar;
    }
}