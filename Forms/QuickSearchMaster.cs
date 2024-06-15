using System.Diagnostics;
using System.Text.RegularExpressions;
using WindowsQuickSearch.Classes;
using WindowsQuickSearch.Forms.SubForms;
namespace WindowsQuickSearch.Forms
{
    public partial class QuickSearchMaster : Form
    {

        
        public static string defaultDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public QuickSearchMaster()
        {
            InitializeComponent();
            InitializeIcons();

            DriveInfo[] allDrives = DriveInfo.GetDrives();
            string lauchpath = allDrives[0].Name.TrimEnd('\\');
            DirctoryBox.Text = lauchpath;
            ShowFolder(lauchpath, false, true);
            
        }
        
        public void ShowFolder(string path, bool fromSearch,bool historyAction = false)
        {
            if (historyAction) 
            {
                UpdateExplorer(path, fromSearch);
                if (_currentHistoryIndex >= _history.Count-1)
                {
                    RightArrow.Enabled = false;
                }
                else
                {
                    RightArrow.Enabled = true;
                }  
                                             
            }
            else
            {               
                OverwriteHistory(DirctoryBox.Text+@"\"+path);
                UpdateExplorer(path, fromSearch);
                RightArrow.Enabled = false;
            }
        }

        private bool UpdateExplorer(string currentPath, bool fromSearch)
        {            
            if (!fromSearch)
            {
                ExplorerContent.Controls.Clear();
                DirctoryBox.Text = _currentPath + currentPath;                
                _currentPath = DirctoryBox.Text + @"\";
            }
            else
            {
                ExplorerContent.Controls.Clear();
                DirctoryBox.Text = currentPath;            
                _currentPath = DirctoryBox.Text + @"\";
            }

            string pathsInDirectorie = FileManager.GetFoldersInDirectory(_currentPath, this);


            string[] lines = pathsInDirectorie.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            // ExplorerContent.SuspendLayout();

            int Foldersfound = 0;
            int Filesfound = 0;

            try
            {
                foreach (string line in lines)
                {

                    if (line.Length <= 0)
                    {

                    }
                    else
                    {
                        Foldersfound++;
                        FoldersFoundLabel.Text = "FoldersFound:" + Foldersfound;
                        BasicFolder currentFile = new BasicFolder();
                        currentFile.InitializeValues(line, this);
                        ExplorerContent.Controls.Add(currentFile);
                    }
                }
            }
            finally
            {
                string contentInDirectorie = FileManager.GetContentInDirectory(_currentPath);

                string[] Contentlines = contentInDirectorie.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                try
                {
                    foreach (string line in Contentlines)
                    {

                        if (line.Length <= 0)
                        {

                        }
                        else
                        {
                            Filesfound++;
                            FilesFoundLabel.Text = "FilesFound:" + Filesfound;
                            BasicFile currentContent = new BasicFile();
                            currentContent.InitializeValues(line, true, DirctoryBox.Text, this);
                            ExplorerContent.Controls.Add(currentContent);
                        }

                    }
                }
                finally
                {

                }
            }
            return true;
        }

        private bool UpdateExplorerFromSearch(string Paths)
        {

            DirctoryBox.Text = "";
            ExplorerContent.Controls.Clear();
            string pathsInDirectorie = Paths;

            string[] lines = pathsInDirectorie.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);


            int Foldersfound = 0;
            int Filesfound = 0;

            
            foreach (string line in lines)
            {
                    
                    if (line.Length <= 0)
                    {

                    }

                    else if (!CheckIfHasExtension(line))
                    {
                        Foldersfound++;
                        BasicFolder currentFolder = new BasicFolder();
                        currentFolder.InitializeValues(line, this);
                        ExplorerContent.Controls.Add(currentFolder);


                    }                    
                    else if (CheckIfHasExtension(line))
                    {
                        
                        Filesfound++;
                        BasicFile currentFile = new BasicFile();
                        currentFile.InitializeValues(line, false, line, this);
                        ExplorerContent.Controls.Add(currentFile);

                    }

                    FoldersFoundLabel.Text = "FoldersFound:" + Foldersfound;
                    FilesFoundLabel.Text = "FilesFound:" + Filesfound;
            }
                      
            return true;
        }
        
        static bool CheckIfHasExtension(string path)
        {            
            string[] parts = path.Split('\\');
            string lastPart = parts[^1];

            Regex regex = new Regex(@"\.[^_]*$");
            return regex.IsMatch(lastPart);
        }

        private static List<string> _history = new List<string>();
        private static int _currentHistoryIndex = -1;
     
        public void OverwriteHistory(string path)
        {

            if (_currentHistoryIndex < _history.Count - 1)
            {
                _history.RemoveRange(_currentHistoryIndex + 1, _history.Count - _currentHistoryIndex - 1);
            }

            _history.Add(path);
            _currentHistoryIndex = _history.Count-1;            
        }

        public static string StepBackHistory()
        {
            if (_currentHistoryIndex-1 >= 0)
            {              
                _currentHistoryIndex--;
                return _history[_currentHistoryIndex];               
            }

            return "";
        }

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

        private void InitializeIcons()
        {
            string closeNormalPath = defaultDirectory + @"AppDependancies\UiIcons\Normal\close-button.png";
            _closeNormal = Image.FromFile(closeNormalPath);
            string closeHoverPath = defaultDirectory + @"AppDependancies\UiIcons\Hover\close-button.png";
            _closeHover = Image.FromFile(closeHoverPath);
            string closeClickkPath = defaultDirectory + @"AppDependancies\UiIcons\Pressed\close-button.png";
            _closeClick = Image.FromFile(closeClickkPath);

            string maximiseNormalPath = defaultDirectory + @"AppDependancies\UiIcons\Normal\maximize-size.png";
            _maximiseNormal = Image.FromFile(maximiseNormalPath);
            string maximiseHoverPath = defaultDirectory + @"AppDependancies\UiIcons\Hover\maximize-size.png";
            _maximiseHover = Image.FromFile(maximiseHoverPath);
            string maximiseClickkPath = defaultDirectory + @"AppDependancies\UiIcons\Pressed\maximize-size.png";
            _maximiseClick = Image.FromFile(maximiseClickkPath);

            string minimiseNormalPath = defaultDirectory + @"AppDependancies\UiIcons\Normal\minus.png";
            _minimiseNormal = Image.FromFile(minimiseNormalPath);
            string minimiseHoverPath = defaultDirectory + @"AppDependancies\UiIcons\Hover\minus.png";
            _minimiseHover = Image.FromFile(minimiseHoverPath);
            string minimiseClickkPath = defaultDirectory + @"AppDependancies\UiIcons\Pressed\minus.png";
            _minimiseClick = Image.FromFile(minimiseClickkPath);

            string leftArrowNormalPath = defaultDirectory + @"AppDependancies\UiIcons\Normal\left.png";
            _leftArrowNormal = Image.FromFile(leftArrowNormalPath);
            string leftArrowHoverPath = defaultDirectory + @"AppDependancies\UiIcons\Hover\left.png";
            _leftArrowHover = Image.FromFile(leftArrowHoverPath);
            string leftArrowClickPath = defaultDirectory + @"AppDependancies\UiIcons\Pressed\left.png";
            _leftArrowClick = Image.FromFile(leftArrowClickPath);

            string rightArrowNormalPath = defaultDirectory + @"AppDependancies\UiIcons\Normal\right.png";
            _rightArrowNormal = Image.FromFile(rightArrowNormalPath);
            string rightArrowHoverPath = defaultDirectory + @"AppDependancies\UiIcons\Hover\right.png";
            _rightArrowHover = Image.FromFile(rightArrowHoverPath);
            string rightArrowClickPath = defaultDirectory + @"AppDependancies\UiIcons\Pressed\right.png";
            _rightArrowClick = Image.FromFile(rightArrowClickPath);

            string ontopDisabledPath = defaultDirectory + @"AppDependancies\UiIcons\Icon States\keep-ontop-disabled.png";
            _ontopDisabled = Image.FromFile(ontopDisabledPath);
            string ontopEnabledPath = defaultDirectory + @"AppDependancies\UiIcons\Icon States\keep-ontop-enabled.png";
            _ontopEnabled = Image.FromFile(ontopEnabledPath);
            string _ontopFromDisabledPath = defaultDirectory + @"AppDependancies\UiIcons\Hover\keep-ontop-from-dissabled.png";
            _ontopFromDisabled = Image.FromFile(_ontopFromDisabledPath);
            string ontopFromEnabledPath = defaultDirectory + @"AppDependancies\UiIcons\Hover\keep-ontop-from-enabled.png";
            _ontopFromEnabled = Image.FromFile(ontopFromEnabledPath);

            string settingsNormaPath = defaultDirectory + @"AppDependancies\UiIcons\Normal\settings-gear-icon.png";
            _settingsNormal = Image.FromFile(settingsNormaPath);
            string _settingsHoverPath = defaultDirectory + @"AppDependancies\UiIcons\Hover\settings-gear-icon.png";
            _settingsHover = Image.FromFile(_settingsHoverPath);
            string settingsClickPath = defaultDirectory + @"AppDependancies\UiIcons\Pressed\settings-gear-icon.png";
            _settingsClick = Image.FromFile(settingsClickPath);
        }

        //---ButtonManager---
        private void DirctoryBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
            {
                UpdateExplorer(DirctoryBox.Text, true);
            }
        }

        private void SettingsBox_MouseEnter(object sender, EventArgs e)
        {
            SettingsBox.Image = _settingsHover;
        }

        private void SettingsBox_MouseLeave(object sender, EventArgs e)
        {
            SettingsBox.Image = _settingsNormal;
        }

        private void SettingsBox_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }

        private void SearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
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
        private static void ShowErrorMessage(string err)
        {
            // Define the error message
            string message = "Before you are able to search, the drives needs to be indexed.\n\nGo settings>Indexing>Index";
            string caption = "Drives Not Indexed";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Error;

            // Display the message box
            MessageBox.Show(message, caption, buttons, icon);
        }
        private void LeftArrow_MouseLeave(object sender, EventArgs e)
        {
            LeftArrow.Image = _leftArrowNormal;
        }

        private void LeftArrow_MouseEnter(object sender, EventArgs e)
        {
            LeftArrow.Image = _leftArrowHover;
        }

        private void LeftArrow_MouseDown(object sender, MouseEventArgs e)
        {
            LeftArrow.Image = _leftArrowClick;
        }

        private void LeftArrow_MouseUp(object sender, MouseEventArgs e)
        {
            LeftArrow.Image = _leftArrowHover;
        }

        private void RightArrow_MouseLeave(object sender, EventArgs e)
        {
            RightArrow.Image = _rightArrowNormal;
        }

        private void RightArrow_MouseEnter(object sender, EventArgs e)
        {
            RightArrow.Image = _rightArrowHover;
        }

        private void RightArrow_MouseDown(object sender, MouseEventArgs e)
        {
            RightArrow.Image = _rightArrowClick;
        }

        private void RightArrow_MouseUp(object sender, MouseEventArgs e)
        {
            RightArrow.Image = _rightArrowHover;
        }

        private void Close_MouseEnter(object sender, EventArgs e)
        {
            CloseBox.Image = _closeHover;
        }

        private void Close_MouseLeave(object sender, EventArgs e)
        {
            CloseBox.Image = _closeNormal;
        }

        private void CloseBox_MouseDown(object sender, MouseEventArgs e)
        {
            CloseBox.Image = _closeClick;
        }

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

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Application.Exit();
            }
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                notifyIcon.Visible = false;
            }
        }

        private void MaximiseBox_MouseEnter(object sender, EventArgs e)
        {
            MaximiseBox.Image = _maximiseHover;
        }

        private void MaximiseBox_MouseLeave(object sender, EventArgs e)
        {
            MaximiseBox.Image = _maximiseNormal;
        }

        private void MaximiseBox_MouseDown(object sender, MouseEventArgs e)
        {
            MaximiseBox.Image = _maximiseClick;
        }

        private void MaximiseBox_MouseUp(object sender, MouseEventArgs e)
        {
            MaximiseBox.Image = _maximiseNormal;
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void MinimiseBox_MouseEnter(object sender, EventArgs e)
        {
            MinimiseBox.Image = _minimiseHover;
        }

        private void MinimiseBox_MouseLeave(object sender, EventArgs e)
        {
            MinimiseBox.Image = _minimiseNormal;
        }

        private void MinimiseBox_MouseDown(object sender, MouseEventArgs e)
        {
            MinimiseBox.Image = _minimiseClick;
        }

        private void MinimiseBox_MouseUp(object sender, MouseEventArgs e)
        {
            MinimiseBox.Image = _minimiseNormal;
            if (e.Button == MouseButtons.Left)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private bool _keepOntop = false;

        private void WindowontopBox_Click(object sender, EventArgs e)
        {
            if (_keepOntop)
            {
                WindowontopBox.Image = _ontopDisabled;
                _keepOntop = false;
                this.TopMost = false;

            }
            else
            {
                WindowontopBox.Image = _ontopEnabled;
                _keepOntop = true;
                this.TopMost = true;
            }
        }

        private void WindowontopBox_MouseEnter(object sender, EventArgs e)
        {
            if (_keepOntop)
            {

                WindowontopBox.Image = _ontopFromEnabled;

            }
            else
            {

                WindowontopBox.Image = _ontopFromDisabled;

            }
        }

        private void WindowontopBox_MouseLeave(object sender, EventArgs e)
        {
            if (_keepOntop)
            {

                WindowontopBox.Image = _ontopEnabled;

            }
            else
            {

                WindowontopBox.Image = _ontopDisabled;

            }
        }


        //---DRAG FORM---
        private bool isDragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void MainBarTable_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }

        private void MainBarTable_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

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

        private void LeftArrow_Click(object sender, EventArgs e)
        {                      
            ShowFolder(StepBackHistory(), true,true);           
        }

        private void RightArrow_Click(object sender, EventArgs e)
        {
            ShowFolder(StepForwardHistory(), true, true);           
        }
    }
}
