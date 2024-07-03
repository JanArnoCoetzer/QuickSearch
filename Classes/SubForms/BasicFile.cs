using System.ComponentModel;
using System.Diagnostics;

namespace WindowsQuickSearch.Forms.SubForms
{
    public partial class BasicFile : UserControl
    {
        private QuickSearchMaster? _master;
        private string? _fileName;
        private string? _filePath;
        private bool _concatenated;
        private Image? _fileIcon;

        public static string defaultDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private readonly string _iconsPath = Path.Combine(defaultDirectory, @"AppDependancies\Icons\");

        // Constructor for initializing the component and images
        public BasicFile()
        {
            InitializeComponent();
            InitializeImages();
        }

        // Initialize the file icon image
        private void InitializeImages()
        {
            string singleFolderPath = Path.Combine(_iconsPath, "text-file.png");
            _fileIcon = Image.FromFile(singleFolderPath);
            FileIcon.Image = _fileIcon;
        }

        // Set values for the file control
        public void InitializeValues(string name, bool concat, string path, QuickSearchMaster master)
        {
            _filePath = path;
            _fileName = name;
            _concatenated = concat;

            int lastSlashIndex = name.LastIndexOf('\\');

            if (lastSlashIndex != -1)
            {
                int secondToLastSlashIndex = name.LastIndexOf('\\', lastSlashIndex - 1);
                if (secondToLastSlashIndex != -1)
                {
                    string substring = (lastSlashIndex - secondToLastSlashIndex <= 11)
                        ? name.Substring(secondToLastSlashIndex + 1)
                        : name.Substring(lastSlashIndex + 1);
                    FileName.Text = substring;
                }
                else
                {
                    FileName.Text = name;
                }
            }
            else
            {
                FileName.Text = name;
            }
            _master = master;
        }

        // Handle the click event to open the file
        private void DirectoryLabel_Click(object sender, EventArgs e)
        {
            string filePath = _concatenated ? Path.Combine(_filePath, _fileName) : _filePath;
            Debug.WriteLine(filePath);
            OpenFileFromPath(filePath);
        }

        // Open the file from the specified path
        public void OpenFileFromPath(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = filePath,
                        UseShellExecute = true
                    });
                }
                catch (Win32Exception ex) when (ex.NativeErrorCode == 1155) // ERROR_NO_ASSOCIATION
                {
                    // No application associated with the file type
                    try
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = "rundll32.exe",
                            Arguments = $"shell32.dll,OpenAs_RunDLL {filePath}",
                            UseShellExecute = true
                        });
                    }
                    catch (Exception innerEx)
                    {
                        MessageBox.Show($"An error occurred while trying to choose an application to open the file: {innerEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while opening the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("The specified file does not exist.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
