
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using WindowsQuickSearch.Forms;

namespace WindowsQuickSearch.Classes
{
    public class FileManager : IDisposable
    {
        public static string defaultDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public static readonly string _appSettingsFile = Path.Combine(defaultDirectory, @"AppDependancies\AppSettings.txt");

        // File paths for different categories of files
        private static readonly string _FoldersFile = Path.Combine(defaultDirectory, @"AppDependancies\TextFiles\Folders");
        private static readonly string _directoriesFile = Path.Combine(defaultDirectory, @"AppDependancies\TextFiles\directories");
        private static readonly string _executablesFile = Path.Combine(defaultDirectory, @"AppDependancies\TextFiles\executables");
        private static readonly string _imagesFile = Path.Combine(defaultDirectory, @"AppDependancies\TextFiles\images");
        private static readonly string _videosFile = Path.Combine(defaultDirectory, @"AppDependancies\TextFiles\videos");
        private static readonly string _audioFile = Path.Combine(defaultDirectory, @"AppDependancies\TextFiles\audios");
        private static readonly string _systemFile = Path.Combine(defaultDirectory, @"AppDependancies\TextFiles\systems");
        private static readonly string _textFile = Path.Combine(defaultDirectory, @"AppDependancies\TextFiles\text");
        private static readonly string _CompressedFile = Path.Combine(defaultDirectory, @"AppDependancies\TextFiles\Compressed");
        private static readonly string _miscellaneousFile = Path.Combine(defaultDirectory, @"AppDependancies\TextFiles\miscellaneous");

        // Arrays of file extensions for different categories
        private static readonly string[] _executablesTypes = { ".exe", ".msi", ".bat", ".cmd", ".com", ".cpl", ".scr" };
        private static readonly string[] _imagesTypes = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".ico" };
        private static readonly string[] _videosTypes = { ".mp4", ".avi", ".mkv", ".mov", ".wmv", ".flv", ".webm" };
        private static readonly string[] _audioTypes = { ".mp3", ".wav", ".aac", ".flac", ".ogg", ".wma", ".m4a" };
        private static readonly string[] _systemTypes = { ".sys", ".dll", ".drv", ".ocx", ".inf", ".wer" };
        private static readonly string[] _textTypes = { ".txt", ".csv", ".xml", ".json", ".log", ".config", ".ini", ".html", ".css", ".md", ".ini" };
        private static readonly string[] _compressedTypes = { ".zip", ".rar", ".7z", ".tar", ".gz", ".bz2", ".xz" };

        private static int _foldersfilesSearched = 0;

        // Get field value from a file based on a specified pattern
        public static string GetFieldInFile(string path, string field)
        {
            if (!File.Exists(path))
            {
                Debug.WriteLine($"FilePathError: {path} not found");
                return "";
            }

            string[] lines = File.ReadAllLines(path);
            string pattern = @"\{(.*?)\}";

            foreach (string line in lines)
            {
                Match match = Regex.Match(line, pattern);
                if (match.Success)
                {
                    string content = match.Groups[1].Value;
                    if (line.Contains(field))
                    {
                        return content;
                    }
                }
            }
            Debug.WriteLine($"---Content Error: Field '{field}' not found in {path}");
            return "";
        }

        // Set field value in a file
        public static bool SetFieldInFile(string path, string field, string value)
        {
            if (!File.Exists(path))
            {
                Debug.WriteLine($"FilePathError: {path} not found");
                return false;
            }

            string[] lines = File.ReadAllLines(path);
            string pattern = $@"({field}\{{)(.*?)(\}})";
            bool fieldFound = false;

            for (int i = 0; i < lines.Length; i++)
            {
                Match match = Regex.Match(lines[i], pattern);
                if (match.Success)
                {
                    lines[i] = Regex.Replace(lines[i], pattern, $"${{{1}}}{value}${{{3}}}");
                    fieldFound = true;
                    break;
                }
            }

            if (fieldFound)
            {
                File.WriteAllLines(path, lines);
                return true;
            }
            else
            {
                Debug.WriteLine($"---Content Error: Field '{field}' not found in {path}");
                return false;
            }
        }

        // Index files from all fixed drives
        public static string[] IndexFiles()
        {
            List<string> drives = GetFixedDriveNames();
            EnsureDirectoriesExist();

            Debug.WriteLine("-_-_-_Indexing_-_-_-");
            Debug.WriteLine("Starting search");

            string directoriesContent = "";
            Stopwatch filesSearchStopwatch = Stopwatch.StartNew();

            foreach (string drive in drives)
            {
                Debug.WriteLine($"Searching drive: {drive}");
                directoriesContent += "\n" + SearchFiles(drive);
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            filesSearchStopwatch.Stop();
            string fileSearchTime = FormatTimeSpan(filesSearchStopwatch.Elapsed);

            Debug.WriteLine("Processing");

            Stopwatch processingStopwatch = Stopwatch.StartNew();
            CreateOrUpdateTextFile(_directoriesFile, directoriesContent);
            CreateFilteredFiles(directoriesContent);

            processingStopwatch.Stop();
            string processingTime = FormatTimeSpan(processingStopwatch.Elapsed);

            Debug.WriteLine("Start saving...");

            Stopwatch savingStopwatch = Stopwatch.StartNew();
            SaveFilteredFiles();

            savingStopwatch.Stop();
            string savingTime = FormatTimeSpan(savingStopwatch.Elapsed);

            GC.Collect();
            GC.WaitForPendingFinalizers();

            return new[] { fileSearchTime, processingTime, savingTime };
        }

        // Get names of all fixed drives
        static List<string> GetFixedDriveNames()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            List<string> driveNames = new List<string>();

            foreach (DriveInfo drive in allDrives)
            {
                if (drive.DriveType == DriveType.Fixed)
                {
                    driveNames.Add(drive.Name);
                }
            }
            return driveNames;
        }

        // Get miscellaneous paths not matching allowed extensions
        public static string GetMiscellaneousPaths(string directoriesContent, string[] allowedExtensions)
        {
            List<string> miscellaneousPaths = new List<string>();
            string[] filePaths = directoriesContent.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string filePath in filePaths)
            {
                bool hasAllowedExtension = false;
                foreach (string extension in allowedExtensions)
                {
                    if (filePath.EndsWith(extension, StringComparison.OrdinalIgnoreCase))
                    {
                        hasAllowedExtension = true;
                        break;
                    }
                }
                if (!hasAllowedExtension)
                {
                    miscellaneousPaths.Add(filePath);
                }
            }
            return string.Join(Environment.NewLine, miscellaneousPaths);
        }

        // Search indexed files by keyword
        public static string SearchIndexed(string keyword, QuickSearchMaster master)
        {
            _foldersfilesSearched = 0;
            string result = "";

            try
            {
                if (Regex.IsMatch(keyword, @"^[a-zA-Z0-9_\-]+\.(?=.*[a-zA-Z])[a-zA-Z0-9_\-]+$"))
                {
                    result = SearchByExtension(keyword, master);
                }
                else
                {
                    result = SearchByKeyword(keyword, master);
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                ShowErrorMessage(ex.ToString());
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();

            return result;
        }

        // Show error message if drives are not indexed
        private static void ShowErrorMessage(string err)
        {
            string message = "Before you are able to search, the drives need to be indexed.\n\nGo to settings>Indexing>Index";
            string caption = "Drives Not Indexed";
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Search files recursively in a directory
        static string SearchFiles(string directory)
        {
            StringBuilder filesStringBuilder = new StringBuilder();
            Stack<string> directoriesStack = new Stack<string>();
            directoriesStack.Push(directory);

            while (directoriesStack.Count > 0)
            {
                string currentDir = directoriesStack.Pop();

                try
                {
                    foreach (string file in Directory.GetFiles(currentDir))
                    {
                        filesStringBuilder.AppendLine(file);
                    }

                    foreach (string subDir in Directory.GetDirectories(currentDir))
                    {
                        directoriesStack.Push(subDir);
                    }
                }
                catch (UnauthorizedAccessException) { }
                catch (Exception) { }
            }

            return filesStringBuilder.ToString();
        }

        // Create or update a text file with the given content
        static void CreateOrUpdateTextFile(string path, string content)
        {
            Debug.WriteLine($"-_-_-_SAVING_-_-_-\n{path}");
            try
            {
                File.WriteAllText(path, content);
                Debug.WriteLine("-_-_-_SUCCESS_-_-_-.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Find lines containing a specific word
        static string FindLinesWithWord(string input, string word, QuickSearchMaster master)
        {
            StringBuilder resultBuilder = new StringBuilder();
            object lockObject = new object();
            string[] lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            _foldersfilesSearched += lines.Length;
            master.FoldersSearchedLabel.Text = "Folders/FilesSearched:" + _foldersfilesSearched;

            Parallel.ForEach(lines, line =>
            {
                if (line.Contains(word, StringComparison.OrdinalIgnoreCase))
                {
                    lock (lockObject)
                    {
                        resultBuilder.AppendLine(line);
                    }
                }
            });

            return resultBuilder.ToString();
        }

        // Filter and join paths based on file types
        static string FilterAndJoinPaths(string paths, string[] types)
        {
            List<string> filteredPaths = FilterPaths(paths, types);
            return string.Join(Environment.NewLine, filteredPaths);
        }

        // Filter paths based on file types
        static List<string> FilterPaths(string paths, string[] types)
        {
            List<string> filteredPaths = new List<string>();
            string[] pathArray = paths.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            Parallel.ForEach(pathArray, path =>
            {
                if (IsFileType(path, types))
                {
                    lock (filteredPaths)
                    {
                        filteredPaths.Add(path);
                    }
                }
            });

            return filteredPaths;
        }

        // Check if the file is of the specified types
        static bool IsFileType(string path, string[] types)
        {
            string extension = Path.GetExtension(path);
            return types.Any(type => extension.Equals(type, StringComparison.OrdinalIgnoreCase));
        }

        // Get folders in a directory
        public static string GetFoldersInDirectory(string path, QuickSearchMaster master)
        {
            try
            {
                string content = string.Join("\n", Directory.GetDirectories(path).Select(Path.GetFileName));
                return string.Join("\n", content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Where(line => !string.IsNullOrWhiteSpace(line)));
            }
            catch (Exception)
            {
                return "";
            }
        }

        // Get content in a directory.
        public static string GetContentInDirectory(string path)
        {
            try
            {
                string content = string.Join("\n", Directory.GetFiles(path).Select(Path.GetFileName));
                return string.Join("\n", content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Where(line => !string.IsNullOrWhiteSpace(line)));
            }
            catch (Exception)
            {
                return "";
            }
        }

        // Filter folders from paths
        private static string FilterFoldersFromPaths(string paths)
        {
            List<string> filteredPaths = FilterFolders(paths);
            return RemoveDuplicateLines(string.Join(Environment.NewLine, filteredPaths));
        }

        // Filter folder paths
        static List<string> FilterFolders(string paths)
        {
            return paths.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(OneStepUp).ToList();
        }

        // Get the parent directory of the given path
        static string OneStepUp(string path)
        {
            int lastSeparatorIndex = path.LastIndexOf('\\');
            return lastSeparatorIndex > 0 ? path.Substring(0, lastSeparatorIndex) : "";
        }

        // Remove duplicate lines from the input
        static string RemoveDuplicateLines(string input)
        {
            HashSet<string> uniqueLines = new HashSet<string>();
            StringBuilder resultBuilder = new StringBuilder();

            foreach (string line in input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None))
            {
                if (uniqueLines.Add(line))
                {
                    resultBuilder.AppendLine(line);
                }
            }

            return resultBuilder.ToString().TrimEnd();
        }

        // Filter paths by keyword
        static string FilterPathsByKeyword(string input, string keyword)
        {
            StringBuilder resultBuilder = new StringBuilder();

            foreach (string line in input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None))
            {
                string path = line.Substring(line.IndexOf('\t') + 1);
                int keywordIndex = path.IndexOf(keyword, StringComparison.OrdinalIgnoreCase);

                if (keywordIndex != -1)
                {
                    int endIndex = keywordIndex + keyword.Length;
                    while (endIndex < path.Length && (char.IsLetterOrDigit(path[endIndex]) || path[endIndex] == '_' || path[endIndex] == '.'))
                    {
                        endIndex++;
                    }

                    resultBuilder.AppendLine(path.Substring(0, endIndex));
                }
            }

            return resultBuilder.ToString().TrimEnd();
        }

        // Ensure necessary directories exist
        private static void EnsureDirectoriesExist()
        {
            if (!Directory.Exists(defaultDirectory))
            {
                Directory.CreateDirectory(defaultDirectory);
                Directory.CreateDirectory(Path.Combine(defaultDirectory, "AppDependancies"));
                Directory.CreateDirectory(Path.Combine(defaultDirectory, "AppDependancies", "TextFiles"));
                IndexFiles();
            }
            else if (!Directory.Exists(Path.Combine(defaultDirectory, "AppDependancies")))
            {
                Directory.CreateDirectory(Path.Combine(defaultDirectory, "AppDependancies"));
                Directory.CreateDirectory(Path.Combine(defaultDirectory, "AppDependancies", "TextFiles"));
                IndexFiles();
            }
            else if (!Directory.Exists(Path.Combine(defaultDirectory, "AppDependancies", "TextFiles")))
            {
                Directory.CreateDirectory(Path.Combine(defaultDirectory, "AppDependancies", "TextFiles"));
                IndexFiles();
            }
        }

        // Create filtered files based on categories
        private static void CreateFilteredFiles(string directoriesContent)
        {
            CreateOrUpdateTextFile(_executablesFile, FilterAndJoinPaths(directoriesContent, _executablesTypes));
            CreateOrUpdateTextFile(_imagesFile, FilterAndJoinPaths(directoriesContent, _imagesTypes));
            CreateOrUpdateTextFile(_videosFile, FilterAndJoinPaths(directoriesContent, _videosTypes));
            CreateOrUpdateTextFile(_audioFile, FilterAndJoinPaths(directoriesContent, _audioTypes));
            CreateOrUpdateTextFile(_systemFile, FilterAndJoinPaths(directoriesContent, _systemTypes));
            CreateOrUpdateTextFile(_textFile, FilterAndJoinPaths(directoriesContent, _textTypes));
            CreateOrUpdateTextFile(_CompressedFile, FilterAndJoinPaths(directoriesContent, _compressedTypes));
            CreateOrUpdateTextFile(_miscellaneousFile, GetMiscellaneousPaths(directoriesContent, _executablesTypes.Concat(_imagesTypes).Concat(_videosTypes).Concat(_audioTypes).Concat(_systemTypes).Concat(_textTypes).Concat(_compressedTypes).ToArray()));
            CreateOrUpdateTextFile(_FoldersFile, FilterFoldersFromPaths(directoriesContent));
        }

        // Save filtered files to disk
        private static void SaveFilteredFiles()
        {
            CreateOrUpdateTextFile(_executablesFile, File.ReadAllText(_executablesFile));
            CreateOrUpdateTextFile(_imagesFile, File.ReadAllText(_imagesFile));
            CreateOrUpdateTextFile(_videosFile, File.ReadAllText(_videosFile));
            CreateOrUpdateTextFile(_audioFile, File.ReadAllText(_audioFile));
            CreateOrUpdateTextFile(_systemFile, File.ReadAllText(_systemFile));
            CreateOrUpdateTextFile(_textFile, File.ReadAllText(_textFile));
            CreateOrUpdateTextFile(_CompressedFile, File.ReadAllText(_CompressedFile));
            CreateOrUpdateTextFile(_miscellaneousFile, File.ReadAllText(_miscellaneousFile));
            CreateOrUpdateTextFile(_FoldersFile, File.ReadAllText(_FoldersFile));
        }

        // Format TimeSpan to string
        private static string FormatTimeSpan(TimeSpan timeSpan)
        {
            return $"{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";
        }

        // Search by file extension
        private static string SearchByExtension(string keyword, QuickSearchMaster master)
        {
            string[] extensionParts = keyword.Split('.');
            string extension = "." + extensionParts[^1].ToLower();

            string content = extension switch
            {
                var ext when _executablesTypes.Contains(ext) => File.ReadAllText(_executablesFile),
                var ext when _imagesTypes.Contains(ext) => File.ReadAllText(_imagesFile),
                var ext when _videosTypes.Contains(ext) => File.ReadAllText(_videosFile),
                var ext when _audioTypes.Contains(ext) => File.ReadAllText(_audioFile),
                var ext when _systemTypes.Contains(ext) => File.ReadAllText(_systemFile),
                var ext when _textTypes.Contains(ext) => File.ReadAllText(_textFile),
                var ext when _compressedTypes.Contains(ext) => File.ReadAllText(_CompressedFile),
                _ => File.ReadAllText(_miscellaneousFile)
            };

            return FindLinesWithWord(content, keyword, master);
        }

        // Search by keyword
        private static string SearchByKeyword(string keyword, QuickSearchMaster master)
        {
            string content = File.ReadAllText(_FoldersFile);
            string results = FindLinesWithWord(content, keyword, master);
            results = RemoveDuplicateLines(FilterPathsByKeyword(results, keyword));

            if (results.Trim().Length <= 0)
            {
                string directoriesContent = File.ReadAllText(_directoriesFile);
                results += "\n" + FindLinesWithWord(directoriesContent, keyword, master);
            }

            return results;
        }

        public void Dispose()
        {
            // Dispose any unmanaged resources here if needed.
            GC.SuppressFinalize(this);
        }
    }
}
