using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using WindowsQuickSearch.Forms;

namespace QuickSearch.Classes.SubForms
{
    public partial class DropDownOptions : UserControl
    {
        private bool allowDelete = false;
        private string path;
        private QuickSearchMaster _master;
        // Constructor to initialize DropDownOptions with a path
        public DropDownOptions(QuickSearchMaster master,string path = "")
        {
            InitializeComponent();
            this.Load += DropDownOptions_Load;
            this.path = path;
            _master = master;
        }

        // Event handler to set the initial location of the dropdown
        private void DropDownOptions_Load(object sender, EventArgs e)
        {
            Point mousePosition = Control.MousePosition;
            Point clientPosition = this.Parent.PointToClient(mousePosition);
            clientPosition.Offset(2, 2);
            this.Location = clientPosition;
        }

        // Event handler to remove the dropdown when the mouse leaves
        private void DropDownOptions_MouseLeave(object sender, EventArgs e)
        {
            if (allowDelete)
            {
                this.Parent.Controls.Remove(this);
                this.Dispose();
            }
        }

        // Event handler to enable dropdown removal when the mouse enters the button
        private void OpenInExplorerButton_MouseEnter(object sender, EventArgs e)
        {
            allowDelete = true;
        }

        // Event handler to enable dropdown removal when the mouse enters the button
        private void CopyAsPathButton_MouseEnter(object sender, EventArgs e)
        {
            allowDelete = true;
        }

        // Open the specified path in Windows Explorer
        private void OpenInExplorer(string path)
        {
            if (System.IO.Directory.Exists(path))
            {
                Process.Start("explorer.exe", path);
            }
            else
            {
                MessageBox.Show("The specified path does not exist.");
            }
        }

        // Event handler to open the path in Explorer and remove the dropdown
        private void OpenInExplorerButton_MouseClick(object sender, MouseEventArgs e)
        {
            OpenInExplorer(path);
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }

        // Event handler to copy the path to the clipboard and remove the dropdown
        private void CopyAsPathButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(path);
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }

        private void PinToHotbarButton_Click(object sender, EventArgs e)
        {
            _master.PinFolderToHotbar(ExtractLastThreeParts(path), path);
        }

        static string ExtractLastThreeParts(string path)
        {
            string[] parts = path.Split('\\');
            int partCount = parts.Length;
            string[] lastThreeParts = parts.Length >= 1 ? parts[(partCount - 1)..partCount] : parts;
            return string.Join("\\", lastThreeParts);
        }
    }
}
