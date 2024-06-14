using System.ComponentModel;
using System.Diagnostics;

namespace WindowsQuickSearch.Forms.SubForms
{
    public partial class BasicFile : UserControl
    {
        private QuickSearchMaster? _master;
        private string? _fileName;
        private string? _filePath;
        private bool _Concatenated;
        private Image? _fileIcon;

        public static string defaultDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string _iconsPath = defaultDirectory + @"AppDependancies\Icons\";

        public BasicFile()
        {
            InitializeComponent();
            InitializeImages();
        }

        private void InitializeImages()
        {
            string singleFolderPath = Path.Combine(_iconsPath, "text-file.png");
            _fileIcon = Image.FromFile(singleFolderPath);
            FileIcon.Image = _fileIcon;
        }

        public void InitializeValues(string Name, bool concat, string Path, QuickSearchMaster master)
        {
            _filePath = Path;
            _fileName = Name;
            _Concatenated = concat;

            int lastSlashIndex = Name.LastIndexOf('\\');

            if (lastSlashIndex != -1)
            {
                int secondToLastSlashIndex = Name.LastIndexOf('\\', lastSlashIndex - 1);
                if (secondToLastSlashIndex != -1)
                {
                    string substring;
                    if (lastSlashIndex - secondToLastSlashIndex <= 11)
                    {
                        substring = Name.Substring(secondToLastSlashIndex + 1);
                    }
                    else
                    {
                        substring = Name.Substring(lastSlashIndex + 1);
                    }
                    FileName.Text = substring;
                }
                else
                {
                    FileName.Text = Name;
                }
            }
            else
            {
                FileName.Text = Name;
            }
            _master = master;
        }

        private void DirectoryLabel_Click(object sender, EventArgs e)
        {
            if (_Concatenated)
            {
                Debug.WriteLine(_filePath + @"\" + _fileName);
                OpenFileFromPath(_filePath + @"\" + _fileName);
            }
            else
            {
                Debug.WriteLine(_filePath);
                OpenFileFromPath(_filePath);
            }
        }

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
