namespace WindowsQuickSearch.Forms.SubForms
{
    partial class BasicFile
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
            FileIcon = new PictureBox();
            FileName = new Label();
            Layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FileIcon).BeginInit();
            SuspendLayout();
            // 
            // Layout
            // 
            Layout.BackColor = Color.FromArgb(29, 29, 29);
            Layout.ColumnCount = 4;
            Layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            Layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            Layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            Layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 77F));
            Layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            Layout.Controls.Add(FileIcon, 0, 1);
            Layout.Controls.Add(FileName, 2, 1);
            Layout.Dock = DockStyle.Fill;
            Layout.Location = new Point(0, 0);
            Layout.Name = "Layout";
            Layout.RowCount = 2;
            Layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            Layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            Layout.Size = new Size(625, 26);
            Layout.TabIndex = 2;
            // 
            // FileIcon
            // 
            FileIcon.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            FileIcon.BackColor = Color.Transparent;
            FileIcon.BackgroundImageLayout = ImageLayout.Zoom;
            Layout.SetColumnSpan(FileIcon, 2);
            FileIcon.Location = new Point(0, 1);
            FileIcon.Margin = new Padding(0);
            FileIcon.Name = "FileIcon";
            FileIcon.Size = new Size(60, 25);
            FileIcon.SizeMode = PictureBoxSizeMode.Zoom;
            FileIcon.TabIndex = 2;
            FileIcon.TabStop = false;
            // 
            // FileName
            // 
            FileName.BackColor = Color.Transparent;
            FileName.Dock = DockStyle.Fill;
            FileName.Font = new Font("Unispace", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            FileName.ForeColor = Color.Gray;
            FileName.Location = new Point(60, 1);
            FileName.Margin = new Padding(0);
            FileName.Name = "FileName";
            FileName.Size = new Size(488, 25);
            FileName.TabIndex = 5;
            FileName.Text = "Text.Txt";
            FileName.TextAlign = ContentAlignment.MiddleLeft;
            FileName.Click += DirectoryLabel_Click;
            // 
            // BasicFile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Layout);
            Margin = new Padding(0);
            Name = "BasicFile";
            Size = new Size(625, 26);
            Layout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)FileIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel Layout;
        private PictureBox FileIcon;
        private Label FileName;
    }
}
