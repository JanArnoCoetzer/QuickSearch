namespace WindowsQuickSearch.Forms.SubForms
{
    partial class BasicFolder
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Layout = new TableLayoutPanel();
            FolderPath = new Label();
            FolderIcon = new PictureBox();
            Layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FolderIcon).BeginInit();
            SuspendLayout();
            // 
            // Layout
            // 
            Layout.BackColor = Color.FromArgb(29, 29, 29);
            Layout.ColumnCount = 4;
            Layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            Layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 25F));
            Layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            Layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            Layout.Controls.Add(FolderPath, 2, 1);
            Layout.Controls.Add(FolderIcon, 1, 1);
            Layout.Dock = DockStyle.Fill;
            Layout.Location = new Point(0, 0);
            Layout.Name = "Layout";
            Layout.RowCount = 2;
            Layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            Layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            Layout.Size = new Size(1000, 26);
            Layout.TabIndex = 1;
            // 
            // FolderPath
            // 
            FolderPath.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            FolderPath.AutoSize = true;
            FolderPath.BackColor = Color.Transparent;
            FolderPath.Font = new Font("Unispace", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            FolderPath.ForeColor = Color.Gray;
            FolderPath.Location = new Point(38, 4);
            FolderPath.Name = "FolderPath";
            FolderPath.Size = new Size(909, 19);
            FolderPath.TabIndex = 5;
            FolderPath.Text = "Path";
            FolderPath.Click += DirectoryLabel_Click;
            // 
            // FolderIcon
            // 
            FolderIcon.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            FolderIcon.BackColor = Color.Transparent;
            FolderIcon.BackgroundImageLayout = ImageLayout.Zoom;
            FolderIcon.Location = new Point(10, 1);
            FolderIcon.Margin = new Padding(0);
            FolderIcon.Name = "FolderIcon";
            FolderIcon.Size = new Size(25, 25);
            FolderIcon.SizeMode = PictureBoxSizeMode.Zoom;
            FolderIcon.TabIndex = 2;
            FolderIcon.TabStop = false;
            FolderIcon.MouseClick += FolderIcon_MouseClick;
            FolderIcon.MouseEnter += FolderIcon_MouseEnter;
            FolderIcon.MouseLeave += FolderIcon_MouseLeave;
            // 
            // BasicFolder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(Layout);
            Margin = new Padding(0);
            MaximumSize = new Size(1000, 26);
            MinimumSize = new Size(1000, 26);
            Name = "BasicFolder";
            Size = new Size(1000, 26);
            Layout.ResumeLayout(false);
            Layout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)FolderIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel Layout;
        private PictureBox FolderIcon;
        private Label FolderPath;
    }
}
