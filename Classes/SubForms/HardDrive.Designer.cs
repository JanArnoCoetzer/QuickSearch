namespace QuickSearch.Classes.SubForms
{
    partial class HardDrive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HardDrive));
            layout = new TableLayoutPanel();
            DriveImg = new PictureBox();
            DriveName = new Label();
            Spacer = new PictureBox();
            layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DriveImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Spacer).BeginInit();
            SuspendLayout();
            // 
            // layout
            // 
            layout.BackColor = Color.FromArgb(29, 29, 29);
            layout.ColumnCount = 4;
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 2F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 33F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 0F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.Controls.Add(DriveImg, 1, 0);
            layout.Controls.Add(DriveName, 3, 0);
            layout.Controls.Add(Spacer, 0, 0);
            layout.Dock = DockStyle.Fill;
            layout.Location = new Point(0, 0);
            layout.Margin = new Padding(0);
            layout.Name = "layout";
            layout.RowCount = 1;
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.Size = new Size(189, 25);
            layout.TabIndex = 1;
            layout.Click += Click;
            layout.MouseEnter += MouseEnter;
            layout.MouseLeave += MouseLeave;
            // 
            // DriveImg
            // 
            DriveImg.Dock = DockStyle.Fill;
            DriveImg.Image = (Image)resources.GetObject("DriveImg.Image");
            DriveImg.Location = new Point(2, 0);
            DriveImg.Margin = new Padding(0);
            DriveImg.Name = "DriveImg";
            DriveImg.Size = new Size(33, 25);
            DriveImg.SizeMode = PictureBoxSizeMode.Zoom;
            DriveImg.TabIndex = 0;
            DriveImg.TabStop = false;
            DriveImg.Click += Click;
            DriveImg.MouseEnter += MouseEnter;
            DriveImg.MouseLeave += MouseLeave;
            // 
            // DriveName
            // 
            DriveName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            DriveName.AutoSize = true;
            DriveName.FlatStyle = FlatStyle.Flat;
            DriveName.Font = new Font("Unispace", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            DriveName.ForeColor = Color.DarkGray;
            DriveName.Location = new Point(38, 3);
            DriveName.Name = "DriveName";
            DriveName.Size = new Size(148, 19);
            DriveName.TabIndex = 1;
            DriveName.Text = "Drive";
            DriveName.TextAlign = ContentAlignment.MiddleLeft;
            DriveName.Click += Click;
            DriveName.MouseEnter += MouseEnter;
            DriveName.MouseLeave += MouseLeave;
            // 
            // Spacer
            // 
            Spacer.Dock = DockStyle.Fill;
            Spacer.Location = new Point(0, 0);
            Spacer.Margin = new Padding(0);
            Spacer.Name = "Spacer";
            Spacer.Size = new Size(2, 25);
            Spacer.TabIndex = 2;
            Spacer.TabStop = false;
            // 
            // HardDrive
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(layout);
            Margin = new Padding(0);
            Name = "HardDrive";
            Size = new Size(189, 25);
            layout.ResumeLayout(false);
            layout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DriveImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)Spacer).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel layout;
        private PictureBox DriveImg;
        private Label DriveName;
        private PictureBox Spacer;
    }
}
