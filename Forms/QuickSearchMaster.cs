using QuickSearch.Classes.SubForms;
using System.Text.RegularExpressions;
using WindowsQuickSearch.Classes;
using WindowsQuickSearch.Forms.SubForms;


namespace WindowsQuickSearch.Forms
{
    public partial class QuickSearchMaster : Form
    {
        // Default directory path for the application
        public static string defaultDirectory = AppDomain.CurrentDomain.BaseDirectory;

        private DropDownOptions dropdownOptions;
        private Point mouseLocation;
        private DriveInfo[] _allDrives;
        private List<HardDrive> _driveSubforms;

        // Constructor for initializing the form and drives
        public QuickSearchMaster()
        {
            InitializeComponent();
            InitializeIcons();

            _allDrives = DriveInfo.GetDrives();
            _driveSubforms = new List<HardDrive>(); // Initialize the list

            // Initialize drives and add to the form
            foreach (DriveInfo Drive in _allDrives)
            {
                if (IsDriveNotEmpty(Drive))
                {
                    HardDrive drive = new HardDrive(Drive, this);
                    DriveContent.Controls.Add(drive);
                    _driveSubforms.Add(drive);
                }
            }

            string lauchpath = _allDrives[0].Name.TrimEnd('\\');
            DirctoryBox.Text = lauchpath;
            ShowFolder(lauchpath, false, true);
        }

        // Check if a drive is not empty
        private bool IsDriveNotEmpty(DriveInfo drive)
        {
            try
            {
                if (drive.IsReady)
                {
                    if (Directory.GetFiles(drive.RootDirectory.FullName).Length > 0 ||
                        Directory.GetDirectories(drive.RootDirectory.FullName).Length > 0)
                    {
                        return true;
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Handle the exception as needed
            }
            return false;
        }

        // Deactivate all drive subforms and show folder contents
        public void CheckDrivesAndActivate(string path)
        {
            foreach (HardDrive driveSubform in _driveSubforms)
            {
                driveSubform.Deactivate();
            }
            ShowFolder(path, true, true);
        }

        // Show the contents of a folder
        public void ShowFolder(string path, bool fromSearch, bool historyAction = false)
        {
            if (historyAction)
            {
                UpdateExplorer(path, fromSearch);
                RightArrow.Enabled = _currentHistoryIndex < _history.Count - 1;
            }
            else
            {
                OverwriteHistory(DirctoryBox.Text + @"\" + path);
                UpdateExplorer(path, fromSearch);
                RightArrow.Enabled = false;
            }
        }

        // Update the explorer with the contents of the current path
        private bool UpdateExplorer(string currentPath, bool fromSearch)
        {
            ExplorerContent.Controls.Clear();
            DirctoryBox.Text = fromSearch ? currentPath : _currentPath + currentPath;
            _currentPath = DirctoryBox.Text + @"\";

            string pathsInDirectory = FileManager.GetFoldersInDirectory(_currentPath, this);
            string[] lines = pathsInDirectory.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            int foldersFound = 0;
            int filesFound = 0;

            // Add folders to the explorer content
            foreach (string line in lines)
            {
                if (line.Length > 0)
                {
                    foldersFound++;
                    FoldersFoundLabel.Text = "FoldersFound: " + foldersFound;
                    BasicFolder currentFile = new BasicFolder();
                    currentFile.InitializeValues(line, DirctoryBox.Text, fromSearch, this, ExplorerContent);
                    ExplorerContent.Controls.Add(currentFile);
                }
            }

            string contentInDirectory = FileManager.GetContentInDirectory(_currentPath);
            string[] contentLines = contentInDirectory.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            // Add files to the explorer content
            foreach (string line in contentLines)
            {
                if (line.Length > 0)
                {
                    filesFound++;
                    FilesFoundLabel.Text = "FilesFound: " + filesFound;
                    BasicFile currentContent = new BasicFile();
                    currentContent.InitializeValues(line, true, DirctoryBox.Text, this);
                    ExplorerContent.Controls.Add(currentContent);
                }
            }

            return true;
        }

        // Update the explorer content based on search results
        private bool UpdateExplorerFromSearch(string paths)
        {
            DirctoryBox.Text = "";
            ExplorerContent.Controls.Clear();
            string[] lines = paths.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            int foldersFound = 0;
            int filesFound = 0;

            // Add folders and files to the explorer content based on search results
            foreach (string line in lines)
            {
                if (line.Length > 0)
                {
                    if (!CheckIfHasExtension(line))
                    {
                        foldersFound++;
                        BasicFolder currentFolder = new BasicFolder();
                        currentFolder.InitializeValues(line, "", true, this, ExplorerContent);
                        ExplorerContent.Controls.Add(currentFolder);
                    }
                    else
                    {
                        filesFound++;
                        BasicFile currentFile = new BasicFile();
                        currentFile.InitializeValues(line, false, line, this);
                        ExplorerContent.Controls.Add(currentFile);
                    }
                }

                FoldersFoundLabel.Text = "FoldersFound: " + foldersFound;
                FilesFoundLabel.Text = "FilesFound: " + filesFound;
            }

            return true;
        }

        // Check if the path has a file extension
        static bool CheckIfHasExtension(string path)
        {
            string lastPart = path.Split('\\')[^1];
            Regex regex = new Regex(@"\.(?=.*[A-Za-z])[A-Za-z0-9]+[^_]*$");
            return regex.IsMatch(lastPart);
        }

        private static List<string> _history = new List<string>();
        private static int _currentHistoryIndex = -1;

        // Overwrite the navigation history with a new path
        public void OverwriteHistory(string path)
        {
            if (_currentHistoryIndex < _history.Count - 1)
            {
                _history.RemoveRange(_currentHistoryIndex + 1, _history.Count - _currentHistoryIndex - 1);
            }

            _history.Add(path);
            _currentHistoryIndex = _history.Count - 1;
        }

        // Navigate back in history
        public static string StepBackHistory()
        {
            if (_currentHistoryIndex - 1 >= 0)
            {
                _currentHistoryIndex--;
                return _history[_currentHistoryIndex];
            }
            return "";
        }

        // Navigate forward in history
        public static string StepForwardHistory()
        {
            if (_currentHistoryIndex < _history.Count - 1)
            {
                _currentHistoryIndex++;
                return _history[_currentHistoryIndex];
            }
            return "";
        }

        //---Images---
        private Image? _closeNormal;
        private Image? _closeHover;
        private Image? _closeClick;

        private Image? _maximiseNormal;
        private Image? _maximiseHover;
        private Image? _maximiseClick;

        private Image? _minimiseNormal;
        private Image? _minimiseHover;
        private Image? _minimiseClick;

        private Image? _leftArrowNormal;
        private Image? _leftArrowHover;
        private Image? _leftArrowClick;

        private Image? _rightArrowNormal;
        private Image? _rightArrowHover;
        private Image? _rightArrowClick;

        private Image? _ontopDisabled;
        private Image? _ontopEnabled;
        private Image? _ontopFromDisabled;
        private Image? _ontopFromEnabled;

        private Image? _settingsNormal;
        private Image? _settingsHover;
        private Image? _settingsClick;

        private string? _currentPath;

        // Initialize icons for the application
        private void InitializeIcons()
        {
            string basePath = defaultDirectory + @"AppDependancies\UiIcons\";

            _closeNormal = Image.FromFile(basePath + @"Normal\close-button.png");
            _closeHover = Image.FromFile(basePath + @"Hover\close-button.png");
            _closeClick = Image.FromFile(basePath + @"Pressed\close-button.png");

            _maximiseNormal = Image.FromFile(basePath + @"Normal\maximize-size.png");
            _maximiseHover = Image.FromFile(basePath + @"Hover\maximize-size.png");
            _maximiseClick = Image.FromFile(basePath + @"Pressed\maximize-size.png");

            _minimiseNormal = Image.FromFile(basePath + @"Normal\minus.png");
            _minimiseHover = Image.FromFile(basePath + @"Hover\minus.png");
            _minimiseClick = Image.FromFile(basePath + @"Pressed\minus.png");

            _leftArrowNormal = Image.FromFile(basePath + @"Normal\left.png");
            _leftArrowHover = Image.FromFile(basePath + @"Hover\left.png");
            _leftArrowClick = Image.FromFile(basePath + @"Pressed\left.png");

            _rightArrowNormal = Image.FromFile(basePath + @"Normal\right.png");
            _rightArrowHover = Image.FromFile(basePath + @"Hover\right.png");
            _rightArrowClick = Image.FromFile(basePath + @"Pressed\right.png");

            _ontopDisabled = Image.FromFile(basePath + @"Icon States\keep-ontop-disabled.png");
            _ontopEnabled = Image.FromFile(basePath + @"Icon States\keep-ontop-enabled.png");
            _ontopFromDisabled = Image.FromFile(basePath + @"Hover\keep-ontop-from-dissabled.png");
            _ontopFromEnabled = Image.FromFile(basePath + @"Hover\keep-ontop-from-enabled.png");

            _settingsNormal = Image.FromFile(basePath + @"Normal\settings-gear-icon.png");
            _settingsHover = Image.FromFile(basePath + @"Hover\settings-gear-icon.png");
            _settingsClick = Image.FromFile(basePath + @"Pressed\settings-gear-icon.png");
        }

        //---ButtonManager---

        // Handle key press event in Directory Box
        private void DirctoryBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                UpdateExplorer(DirctoryBox.Text, true);
            }
        }

        // Settings box mouse enter event
        private void SettingsBox_MouseEnter(object sender, EventArgs e)
        {
            SettingsBox.Image = _settingsHover;
        }

        // Settings box mouse leave event
        private void SettingsBox_MouseLeave(object sender, EventArgs e)
        {
            SettingsBox.Image = _settingsNormal;
        }

        // Settings box click event
        private void SettingsBox_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }

        // Search box key press event
        private void SearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    UpdateExplorerFromSearch(FileManager.SearchIndexed(SearchBox.Text, this));
                }
                catch (FileNotFoundException ex)
                {
                    ShowErrorMessage(ex.ToString());
                }
            }
        }

        // Show error message
        private static void ShowErrorMessage(string err)
        {
            string message = "Before you are able to search, the drives need to be indexed.\n\nGo to settings > Indexing > Index";
            string caption = "Drives Not Indexed";
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Left arrow mouse leave event
        private void LeftArrow_MouseLeave(object sender, EventArgs e)
        {
            LeftArrow.Image = _leftArrowNormal;
        }

        // Left arrow mouse enter event
        private void LeftArrow_MouseEnter(object sender, EventArgs e)
        {
            LeftArrow.Image = _leftArrowHover;
        }

        // Left arrow mouse down event
        private void LeftArrow_MouseDown(object sender, MouseEventArgs e)
        {
            LeftArrow.Image = _leftArrowClick;
        }

        // Left arrow mouse up event
        private void LeftArrow_MouseUp(object sender, MouseEventArgs e)
        {
            LeftArrow.Image = _leftArrowHover;
        }

        // Right arrow mouse leave event
        private void RightArrow_MouseLeave(object sender, EventArgs e)
        {
            RightArrow.Image = _rightArrowNormal;
        }

        // Right arrow mouse enter event
        private void RightArrow_MouseEnter(object sender, EventArgs e)
        {
            RightArrow.Image = _rightArrowHover;
        }

        // Right arrow mouse down event
        private void RightArrow_MouseDown(object sender, MouseEventArgs e)
        {
            RightArrow.Image = _rightArrowClick;
        }

        // Right arrow mouse up event
        private void RightArrow_MouseUp(object sender, MouseEventArgs e)
        {
            RightArrow.Image = _rightArrowHover;
        }

        // Close box mouse enter event
        private void Close_MouseEnter(object sender, EventArgs e)
        {
            CloseBox.Image = _closeHover;
        }

        // Close box mouse leave event
        private void Close_MouseLeave(object sender, EventArgs e)
        {
            CloseBox.Image = _closeNormal;
        }

        // Close box mouse down event
        private void CloseBox_MouseDown(object sender, MouseEventArgs e)
        {
            CloseBox.Image = _closeClick;
        }

        // Close box mouse click event
        private void CloseBox_MouseClick(object sender, MouseEventArgs e)
        {
            CloseBox.Image = _closeNormal;
            if (e.Button == MouseButtons.Right)
            {
                Application.Exit();
            }
            else
            {
                notifyIcon.Visible = true;
                this.Hide();
            }
        }

        // Notify icon mouse click event
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Application.Exit();
            }
            else if (e.Button == MouseButtons.Left)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                notifyIcon.Visible = false;
            }
        }

        // Maximise box mouse enter event
        private void MaximiseBox_MouseEnter(object sender, EventArgs e)
        {
            MaximiseBox.Image = _maximiseHover;
        }

        // Maximise box mouse leave event
        private void MaximiseBox_MouseLeave(object sender, EventArgs e)
        {
            MaximiseBox.Image = _maximiseNormal;
        }

        // Maximise box mouse down event
        private void MaximiseBox_MouseDown(object sender, MouseEventArgs e)
        {
            MaximiseBox.Image = _maximiseClick;
        }

        // Maximise box mouse up event
        private void MaximiseBox_MouseUp(object sender, MouseEventArgs e)
        {
            MaximiseBox.Image = _maximiseNormal;
            this.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        // Minimise box mouse enter event
        private void MinimiseBox_MouseEnter(object sender, EventArgs e)
        {
            MinimiseBox.Image = _minimiseHover;
        }

        // Minimise box mouse leave event
        private void MinimiseBox_MouseLeave(object sender, EventArgs e)
        {
            MinimiseBox.Image = _minimiseNormal;
        }

        // Minimise box mouse down event
        private void MinimiseBox_MouseDown(object sender, MouseEventArgs e)
        {
            MinimiseBox.Image = _minimiseClick;
        }

        // Minimise box mouse up event
        private void MinimiseBox_MouseUp(object sender, MouseEventArgs e)
        {
            MinimiseBox.Image = _minimiseNormal;
            if (e.Button == MouseButtons.Left)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private bool _keepOntop = false;

        // Toggle the window's topmost property
        private void WindowontopBox_Click(object sender, EventArgs e)
        {
            _keepOntop = !_keepOntop;
            WindowontopBox.Image = _keepOntop ? _ontopEnabled : _ontopDisabled;
            this.TopMost = _keepOntop;
        }

        // Window ontop box mouse enter event
        private void WindowontopBox_MouseEnter(object sender, EventArgs e)
        {
            WindowontopBox.Image = _keepOntop ? _ontopFromEnabled : _ontopFromDisabled;
        }

        // Window ontop box mouse leave event
        private void WindowontopBox_MouseLeave(object sender, EventArgs e)
        {
            WindowontopBox.Image = _keepOntop ? _ontopEnabled : _ontopDisabled;
        }

        //---DRAG FORM---
        private bool isDragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        // Handle mouse down event for dragging the form
        private void MainBarTable_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }

        // Handle mouse up event for dragging the form
        private void MainBarTable_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        // Handle mouse move event for dragging the form
        private void MainBarTable_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                }
                Point currentCursorPoint = Cursor.Position;
                int dx = currentCursorPoint.X - dragCursorPoint.X;
                int dy = currentCursorPoint.Y - dragCursorPoint.Y;
                this.Location = new Point(dragFormPoint.X + dx, dragFormPoint.Y + dy);
            }
        }

        // Navigate back in history
        private void LeftArrow_Click(object sender, EventArgs e)
        {
            ShowFolder(StepBackHistory(), true, true);
        }

        // Navigate forward in history
        private void RightArrow_Click(object sender, EventArgs e)
        {
            ShowFolder(StepForwardHistory(), true, true);
        }

        // Show dropdown options
        public void ShowDropdown(string path)
        {
            dropdownOptions = new DropDownOptions(this, path);
            this.Controls.Add(dropdownOptions);
            dropdownOptions.BringToFront();
        }

        public void PinFolderToHotbar(string name,string path) 
        {
            FolderCanvasIcon folderCanvasIcon = new FolderCanvasIcon(this,name, path);
            HotbarFlowLayout.Controls.Add(folderCanvasIcon);           
        }
    }
}
