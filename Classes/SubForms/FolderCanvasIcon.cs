using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsQuickSearch.Forms;

namespace QuickSearch.Classes.SubForms
{
    public partial class FolderCanvasIcon : UserControl
    {
        private string _folderName;
        private string _path;
        private QuickSearchMaster _master;
        public FolderCanvasIcon(QuickSearchMaster master, string folderName = "", string path = "")
        {
            InitializeComponent();
            _folderName = folderName;
            _path = path;
            _master = master;

            FolderName.Text = _folderName;
        }

        private void Click(object sender, EventArgs e)
        {
            _master.ShowFolder(_path,true);
        }
    }
}
