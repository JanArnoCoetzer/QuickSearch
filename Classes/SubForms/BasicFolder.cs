namespace WindowsQuickSearch.Forms.SubForms
{
    public partial class BasicFolder : UserControl
    {
        public static string defaultDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string _iconsPath = defaultDirectory + @"AppDependancies\Icons\";
        private Image? _singleFile;
        QuickSearchMaster? _master;
        private string? _fullpath;

        public BasicFolder()
        {
            InitializeComponent();
            InitializeImages();
        }

        public void InitializeValues(string Path, QuickSearchMaster master)
        {
            FolderPath.Text = ExtractLastThreeParts(Path);
            _master = master;
            FolderIcon.BackgroundImage = _singleFile;
            _fullpath = Path;
        }

        private void InitializeImages()
        {
            string singleFolderPath = Path.Combine(_iconsPath, "folder.png");
            _singleFile = Image.FromFile(singleFolderPath);
        }

        private void DirectoryLabel_Click(object sender, EventArgs e)
        {
            if (FolderPath.Text.Contains("\\"))
            {
                _master.ShowFolder(_fullpath, true);
            }
            else
            {
                _master.ShowFolder(_fullpath, false);
            }

        }

        static string ExtractLastThreeParts(string path)
        {
            // Split the path by the backslash
            string[] parts = path.Split('\\');

            // Get the last three parts
            int partCount = parts.Length;
            string[] lastThreeParts = parts.Length >= 3 ? parts[(partCount - 3)..partCount] : parts;

            // Join the last three parts with backslashes
            return string.Join("\\", lastThreeParts);
        }
    }
}
