using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WindowsQuickSearch.Forms;

namespace QuickSearch.Classes.SubForms
{
    public partial class HardDrive : UserControl
    {
        private DriveInfo _drive;
        private string _driveName;
        private string _drivePath;
        private bool _active = false;
        private QuickSearchMaster _master;

        // Constructor to initialize the HardDrive control
        public HardDrive(DriveInfo drive, QuickSearchMaster master)
        {
            InitializeComponent();

            _master = master;
            _drive = drive;
            _drivePath = _drive.Name;
            _driveName = _drive.Name.TrimEnd('\\');

            DriveName.Text = _driveName;
        }

        // Deactivate the drive highlighting
        public void Deactivate()
        {
            _active = false;
            layout.BackColor = Color.FromArgb(29, 29, 29);
            Spacer.BackColor = Color.FromArgb(29, 29, 29);
        }

        // Handle mouse enter event to highlight the drive
        private void MouseEnter(object sender, EventArgs e)
        {
            if (!_active)
            {
                layout.BackColor = Color.FromArgb(34, 34, 34);
                Spacer.BackColor = Color.FromArgb(64, 64, 64);
            }
        }

        // Handle mouse leave event to remove the highlight
        private void MouseLeave(object sender, EventArgs e)
        {
            if (!_active)
            {
                layout.BackColor = Color.FromArgb(29, 29, 29);
                Spacer.BackColor = Color.FromArgb(29, 29, 29);
            }
        }

        // Handle click event to activate the drive and change its highlight
        private void Click(object sender, EventArgs e)
        {
            _master.CheckDrivesAndActivate(_driveName);
            _active = true;
            Spacer.BackColor = Color.FromArgb(64, 64, 64);
        }
    }
}
