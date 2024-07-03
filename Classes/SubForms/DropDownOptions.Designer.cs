namespace QuickSearch.Classes.SubForms
{
    partial class DropDownOptions
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
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            OpenInExplorerButton = new Button();
            CopyAsPathButton = new Button();
            PinToHotbarButton = new Button();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 2F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 2F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 2F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 2F));
            tableLayoutPanel1.Size = new Size(188, 74);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.MouseLeave += DropDownOptions_MouseLeave;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(OpenInExplorerButton);
            flowLayoutPanel1.Controls.Add(CopyAsPathButton);
            flowLayoutPanel1.Controls.Add(PinToHotbarButton);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(2, 2);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(184, 70);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // OpenInExplorerButton
            // 
            OpenInExplorerButton.FlatStyle = FlatStyle.Flat;
            OpenInExplorerButton.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point);
            OpenInExplorerButton.ForeColor = Color.DarkGray;
            OpenInExplorerButton.Location = new Point(0, 0);
            OpenInExplorerButton.Margin = new Padding(0);
            OpenInExplorerButton.Name = "OpenInExplorerButton";
            OpenInExplorerButton.Size = new Size(183, 23);
            OpenInExplorerButton.TabIndex = 1;
            OpenInExplorerButton.Text = "Open in FileExplorer";
            OpenInExplorerButton.UseVisualStyleBackColor = true;
            OpenInExplorerButton.MouseClick += OpenInExplorerButton_MouseClick;
            OpenInExplorerButton.MouseEnter += OpenInExplorerButton_MouseEnter;
            // 
            // CopyAsPathButton
            // 
            CopyAsPathButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CopyAsPathButton.FlatStyle = FlatStyle.Flat;
            CopyAsPathButton.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point);
            CopyAsPathButton.ForeColor = Color.DarkGray;
            CopyAsPathButton.Location = new Point(0, 23);
            CopyAsPathButton.Margin = new Padding(0);
            CopyAsPathButton.Name = "CopyAsPathButton";
            CopyAsPathButton.Size = new Size(183, 23);
            CopyAsPathButton.TabIndex = 2;
            CopyAsPathButton.Text = "Copy As Path";
            CopyAsPathButton.UseVisualStyleBackColor = true;
            CopyAsPathButton.Click += CopyAsPathButton_Click;
            CopyAsPathButton.MouseEnter += CopyAsPathButton_MouseEnter;
            // 
            // PinToHotbarButton
            // 
            PinToHotbarButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            PinToHotbarButton.FlatStyle = FlatStyle.Flat;
            PinToHotbarButton.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point);
            PinToHotbarButton.ForeColor = Color.DarkGray;
            PinToHotbarButton.Location = new Point(0, 46);
            PinToHotbarButton.Margin = new Padding(0);
            PinToHotbarButton.Name = "PinToHotbarButton";
            PinToHotbarButton.Size = new Size(183, 23);
            PinToHotbarButton.TabIndex = 3;
            PinToHotbarButton.Text = "Pin To Hotbar";
            PinToHotbarButton.UseVisualStyleBackColor = true;
            PinToHotbarButton.Click += PinToHotbarButton_Click;
            // 
            // DropDownOptions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(23, 23, 23);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(0);
            Name = "DropDownOptions";
            Size = new Size(188, 74);
            MouseLeave += DropDownOptions_MouseLeave;
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button OpenInExplorerButton;
        private Button CopyAsPathButton;
        private Button PinToHotbarButton;
    }
}
