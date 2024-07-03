using QuickSearch.Classes.SubForms;
using System.Diagnostics;
using System.Windows.Forms;

namespace WindowsQuickSearch.Forms.SubForms
{
    public partial class BasicFolder : UserControl
    {
        public static string defaultDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private readonly string _iconsPath = defaultDirectory + @"AppDependancies\UiIcons\Animations\FolderAnimated";
        private Image? _singleFile;
        private QuickSearchMaster? _master;
        private FlowLayoutPanel? ExplorerContent;

        private string? _fullpath;
        private string? _path;

        private bool isHovered;
        private int animationFrame;
        private System.Windows.Forms.Timer? hoverTimer;

        private Image? _frame1;
        private Image? _frame2;
        private Image? _frame3;

        private bool OptionsOpen = false;

        // Constructor to initialize the component and images
        public BasicFolder()
        {
            InitializeComponent();
            InitializeImages();
            InitializeHoverTimer();
        }

        // Set values for the folder control
        public void InitializeValues(string path, string directory, bool fromSearch, QuickSearchMaster master, FlowLayoutPanel explorerContent)
        {
            FolderPath.Text = ExtractLastThreeParts(path);
            _master = master;
            FolderIcon.BackgroundImage = _singleFile;
            ExplorerContent = explorerContent;

            _fullpath = path;
            _path = fromSearch ? path : Path.Combine(directory, path);
        }

        // Initialize the folder icon image
        private void InitializeImages()
        {
            string folderIconPath = Path.Combine(_iconsPath, "FolderNormal.png");
            _singleFile = Image.FromFile(folderIconPath);
        }

        // Handle the click event to show the folder contents
        private void DirectoryLabel_Click(object sender, EventArgs e)
        {
            _master?.ShowFolder(_fullpath!, FolderPath.Text.Contains("\\"));
        }

        // Extract the last three parts of the folder path
        static string ExtractLastThreeParts(string path)
        {
            string[] parts = path.Split('\\');
            int partCount = parts.Length;
            string[] lastThreeParts = parts.Length >= 3 ? parts[(partCount - 3)..partCount] : parts;
            return string.Join("\\", lastThreeParts);
        }

        // Initialize the hover timer and animation frames
        private void InitializeHoverTimer()
        {
            hoverTimer = new System.Windows.Forms.Timer
            {
                Interval = 1000 / 60 // 60 FPS
            };
            hoverTimer.Tick += HoverTimer_Tick;

            _frame1 = LoadImage("HoverBaseF1.png");
            _frame2 = LoadImage("HoverBaseF2.png");
            _frame3 = LoadImage("HoverBaseF3.png");
        }

        // Load image from file
        private Image? LoadImage(string fileName)
        {
            string filePath = Path.Combine(_iconsPath, fileName);
            return Image.FromFile(filePath);
        }

        // Start the hover animation
        private void StartHoverAnimation()
        {
            animationFrame = 1;
            hoverTimer?.Start();
        }

        // Handle mouse enter event for the folder icon
        private void FolderIcon_MouseEnter(object sender, EventArgs e)
        {
            OptionsOpen = false;
            isHovered = true;
            animationFrame = 0;
            StartHoverAnimation();
        }

        // Handle mouse leave event for the folder icon
        private void FolderIcon_MouseLeave(object sender, EventArgs e)
        {
            if (!OptionsOpen)
            {
                isHovered = false;
                ResetHoverTimer();
            }
        }

        // Handle hover timer tick event to animate the folder icon
        private void HoverTimer_Tick(object sender, EventArgs e)
        {
            if (isHovered)
            {
                UpdateAnimationFrame(true);
            }
            else
            {
                UpdateAnimationFrame(false);
            }
        }

        // Update the animation frame
        private void UpdateAnimationFrame(bool forward)
        {
            if (forward)
            {
                animationFrame++;
            }
            else
            {
                animationFrame--;
            }

            switch (animationFrame)
            {
                case 1:
                    FolderIcon.Image = _singleFile;
                    break;
                case 2:
                    FolderIcon.Image = _frame1;
                    break;
                case 3:
                    FolderIcon.Image = _frame2;
                    break;
                case 4:
                    FolderIcon.Image = _frame3;
                    if (forward)
                    {
                        hoverTimer?.Stop();
                    }
                    break;
                default:
                    if (animationFrame <= 0)
                    {
                        ResetHoverTimer();
                    }
                    break;
            }
        }

        // Reset hover timer and release resources
        private void ResetHoverTimer()
        {
            FolderIcon.Image = _singleFile;
            hoverTimer?.Stop();
            _frame1 = null;
            _frame2 = null;
            _frame3 = null;
            GC.Collect();
        }

        // Handle mouse click event for the folder icon to show dropdown options
        private void FolderIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (animationFrame == 4 && isHovered)
            {
                animationFrame = 5;
            }

            if (!OptionsOpen)
            {
                Debug.WriteLine(_path);
                OptionsOpen = true;
                _master?.ShowDropdown(_path!);
            }
        }
    }
}
