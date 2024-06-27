using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using WindowsQuickSearch.Forms;

namespace WindowsQuickSearch.Classes
{
    public class FileManager
    {
        public static string defaultDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public static readonly string _appSettingsFile = defaultDirectory + @"AppDependancies\AppSettings.txt";

        private static readonly string _FoldersFile = defaultDirectory + @"AppDependancies\TextFiles\Folders";
        private static readonly string _directoriesFile = defaultDirectory + @"AppDependancies\TextFiles\directories";
        private static readonly string _executablesFile = defaultDirectory + @"AppDependancies\TextFiles\executables";
        private static readonly string _imagesFile = defaultDirectory + @"AppDependancies\TextFiles\images";
        private static readonly string _videosFile = defaultDirectory + @"AppDependancies\TextFiles\videos";
        private static readonly string _audioFile = defaultDirectory + @"AppDependancies\TextFiles\audios";
        private static readonly string _systemFile = defaultDirectory + @"AppDependancies\TextFiles\systems";
        private static readonly string _textFile = defaultDirectory + @"AppDependancies\TextFiles\text";
        private static readonly string _CompressedFile = defaultDirectory + @"AppDependancies\TextFiles\Compressed";
        private static readonly string _miscellaneousFile = defaultDirectory + @"AppDependancies\TextFiles\miscellaneous";
        

        private static readonly string[] _executablesTypes = { ".exe", ".msi", ".bat", ".cmd", ".com", ".cpl", ".scr" };
        private static readonly string[] _imagesTypes = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".ico" };
        private static readonly string[] _videosTypes = { ".mp4", ".avi", ".mkv", ".mov", ".wmv", ".flv", ".webm" };
        private static readonly string[] _audioTypes = { ".mp3", ".wav", ".aac", ".flac", ".ogg", ".wma", ".m4a" };
        private static readonly string[] _systemTypes = { ".sys", ".dll", ".drv", ".ocx", ".inf", ".wer" };
        private static readonly string[] _textTypes = { ".txt", ".csv", ".xml", ".json", ".log", ".config", ".ini", ".html", ".css", ".md", ".ini" };
        private static readonly string[] _compressedTypes = { ".zip", ".rar", ".7z", ".tar", ".gz", ".bz2", ".xz" };

        private static int _foldersfilesSearched = 0;

        public static string GetFieldInFile(string path, string field)
        {
            
            if (!File.Exists(path))
            {
                Debug.WriteLine("FilePathError: " + path + " not found");
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
            Debug.WriteLine("---Content Error: Field '" + field + "' not found in " + path);
            return "";
        }

        public static bool SetFieldInFile(string path, string field, string value)
        {
            if (!File.Exists(path))
            {
                Debug.WriteLine("FilePathError: " + path + " not found");
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
                Debug.WriteLine("---Content Error: Field '" + field + "' not found in " + path);
                return false;
            }
        }


        public static string[] IndexFiles()
        {
            List<string> drives = GetFixedDriveNames();
            

            if (!Directory.Exists(defaultDirectory))
            {
                Directory.CreateDirectory(defaultDirectory);
                Directory.CreateDirectory(defaultDirectory + @"\AppDependancies");
                Directory.CreateDirectory(defaultDirectory + @"\AppDependancies\TextFiles");
                IndexFiles();
            }
            if (!Directory.Exists(defaultDirectory + @"\AppDependancies"))
            {
                Directory.CreateDirectory(defaultDirectory + @"\AppDependancies");
                Directory.CreateDirectory(defaultDirectory + @"\AppDependancies\TextFiles");
                IndexFiles();
            }
            if (!Directory.Exists(defaultDirectory + @"\AppDependancies\TextFiles"))
            {
                Directory.CreateDirectory(defaultDirectory + @"\AppDependancies\TextFiles");
                IndexFiles();
            }
            
            Debug.WriteLine("-_-_-_Indexing_-_-_-");
            Debug.WriteLine("starting search");

            string directoriesContent = "";

            Stopwatch FilesSearchStopwatch = new Stopwatch();
            FilesSearchStopwatch.Start();

            foreach (string drive in drives)
            {
                Debug.WriteLine("Searching drive: " + drive);
                directoriesContent += "\n" + SearchFiles(drive);
            }

            FilesSearchStopwatch.Stop();
            TimeSpan FileSearchTS = FilesSearchStopwatch.Elapsed;
            string FileSearchE = String.Format("{0:00}:{1:00}", FileSearchTS.Minutes, FileSearchTS.Seconds);


            Debug.WriteLine("proccessing");

            Stopwatch ProcessingStopwatch = new Stopwatch();
            ProcessingStopwatch.Start();

            CreateOrUpdateTextFile(_directoriesFile, directoriesContent);

            string executablesPaths = FilterAndJoinPaths(directoriesContent, _executablesTypes);
            string imagesPaths = FilterAndJoinPaths(directoriesContent, _imagesTypes);
            string videosPaths = FilterAndJoinPaths(directoriesContent, _videosTypes);
            string audioPaths = FilterAndJoinPaths(directoriesContent, _audioTypes);
            string systemPaths = FilterAndJoinPaths(directoriesContent, _systemTypes);
            string textPaths = FilterAndJoinPaths(directoriesContent, _textTypes);
            string compressedPaths = FilterAndJoinPaths(directoriesContent, _compressedTypes);
            string folderPaths = FilterFoldersFromPaths(directoriesContent);
            string miscellaneousPaths = GetMiscellaneousPaths
                (
                    directoriesContent,
                    _executablesTypes
                    .Concat(_imagesTypes)
                    .Concat(_videosTypes)
                    .Concat(_audioTypes)
                    .Concat(_systemTypes)
                    .Concat(_textTypes)
                    .Concat(_compressedTypes)
                    .ToArray()
                );


            ProcessingStopwatch.Stop();

            TimeSpan ProcessingTS = ProcessingStopwatch.Elapsed;
            string ProcessingE = String.Format("{0:00}:{1:00}", ProcessingTS.Minutes, ProcessingTS.Seconds);

            Debug.WriteLine("StartSaving...");

            Stopwatch SavingStopwatch = new Stopwatch();
            SavingStopwatch.Start();

            CreateOrUpdateTextFile(_executablesFile, executablesPaths);
            CreateOrUpdateTextFile(_imagesFile, imagesPaths);
            CreateOrUpdateTextFile(_videosFile, videosPaths);
            CreateOrUpdateTextFile(_audioFile, audioPaths);
            CreateOrUpdateTextFile(_systemFile, systemPaths);
            CreateOrUpdateTextFile(_textFile, textPaths);
            CreateOrUpdateTextFile(_CompressedFile, compressedPaths);
            CreateOrUpdateTextFile(_miscellaneousFile, miscellaneousPaths);
            CreateOrUpdateTextFile(_FoldersFile, folderPaths);

            SavingStopwatch.Stop();
            TimeSpan SaveTS = ProcessingStopwatch.Elapsed;
            string SaveE = String.Format("{0:00}:{1:00}", SaveTS.Minutes, SaveTS.Seconds);

            string[] strings = new string[]
            {
                FileSearchE,
                ProcessingE,
                SaveE
            };
            return strings;
        }

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

        public static string SearchIndexed(string keyword, QuickSearchMaster master)
        {
            _foldersfilesSearched = 0;

            if (Regex.IsMatch(keyword, @"^[a-zA-Z0-9_\-]+\.(?=.*[a-zA-Z])[a-zA-Z0-9_\-]+$"))
            {
                try
                {
                    string[] extensionparts = keyword.Split('.');
                    string extension = "." + (extensionparts[^1].ToLower());                    

                    if (_executablesTypes.Contains(extension))
                    {
                        string content = File.ReadAllText(_executablesFile);
                        return FindLinesWithWord(content, keyword, master);
                    }
                    else if (_imagesTypes.Contains(extension))
                    {
                        string content = File.ReadAllText(_imagesFile);
                        return FindLinesWithWord(content, keyword, master);
                    }
                    else if (_videosTypes.Contains(extension))
                    {
                        string content = File.ReadAllText(_videosFile);
                        return FindLinesWithWord(content, keyword, master);
                    }
                    else if (_audioTypes.Contains(extension))
                    {
                        string content = File.ReadAllText(_audioFile);
                        return FindLinesWithWord(content, keyword, master);
                    }
                    else if (_systemTypes.Contains(extension))
                    {
                        string content = File.ReadAllText(_systemFile);
                        return FindLinesWithWord(content, keyword, master);
                    }
                    else if (_textTypes.Contains(extension))
                    {
                        string content = File.ReadAllText(_textFile);
                        return FindLinesWithWord(content, keyword, master);
                    }
                    else if (_compressedTypes.Contains(_CompressedFile))
                    {
                        string content = File.ReadAllText(_CompressedFile);
                        return FindLinesWithWord(content, keyword, master);
                    }
                    else
                    {
                        string content = File.ReadAllText(_miscellaneousFile);

                        if (content.Trim().Length <= 0)
                        {
                            string _directoriesFilecontent = File.ReadAllText(_directoriesFile);
                            content += "\n" + FindLinesWithWord(_directoriesFilecontent, keyword, master);
                        }
                        else
                        {
                            return content;
                        }
                        return FindLinesWithWord(content, keyword, master);
                    }
                }
                catch (DirectoryNotFoundException ex)
                {
                    ShowErrorMessage(ex.ToString());
                    return "";
                }


            }

            else
            {
                try
                {
                    string content = File.ReadAllText(_FoldersFile);
                    string resaults = FindLinesWithWord(content, keyword, master);
                    resaults = RemoveDuplicateLines(FilterPathsByKeyword(resaults, keyword));

                    if (resaults.Trim().Length <= 0)
                    {
                        string _directoriesFilecontent = File.ReadAllText(_directoriesFile);
                        resaults += "\n" + FindLinesWithWord(_directoriesFilecontent, keyword, master);

                        return resaults;
                    }
                    else
                    {
                        return resaults;
                    }
                }

                catch (DirectoryNotFoundException ex) 
                {
                    ShowErrorMessage(ex.ToString());
                    return "";
                }

            }
        }

        private static void ShowErrorMessage(string err)
        {
            
            string message = "Before you are able to search, the drives needs to be indexed.\n\nGo settings>Indexing>Index";
            string caption = "Drives Not Indexed";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Error;

           
            MessageBox.Show(message, caption, buttons, icon);
        }


        static string SearchFiles(string directory = @"C:\")
        {
            StringBuilder filesStringBuilder = new StringBuilder();
            Stack<string> directoriesStack = new Stack<string>();
            directoriesStack.Push(directory);

            while (directoriesStack.Count > 0)
            {
                string currentDir = directoriesStack.Pop();

                try
                {
                    string[] files = Directory.GetFiles(currentDir);
                    foreach (string file in files)
                    {
                        filesStringBuilder.AppendLine(file);
                    }

                    string[] subDirectories = Directory.GetDirectories(currentDir);
                    foreach (string subDir in subDirectories)
                    {
                        directoriesStack.Push(subDir);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                }
                catch (Exception ex)
                {
                }
            }

            return filesStringBuilder.ToString();
        }





        static void CreateOrUpdateTextFile(string path, string content)
        {
            Debug.WriteLine("-_-_-_SAVING_-_-_-\n" + path);
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


        static string FindLinesWithWord(string input, string word, QuickSearchMaster master)
        {
            StringBuilder resultBuilder = new StringBuilder();
            object lockObject = new object();
            string[] lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            _foldersfilesSearched += lines.Length;

            master.FoldersSearchedLabel.Text = "Folders/FilesSearched:" + _foldersfilesSearched;

            Parallel.ForEach(lines, line =>
            {
                if (line.ToUpper().Contains(word.ToUpper()))
                {
                    lock (lockObject)
                    {
                        resultBuilder.AppendLine(line);
                    }
                }
            });

            return resultBuilder.ToString();
        }



        static string FilterAndJoinPaths(string paths, string[] types)
        {
            List<string> filteredPaths = FilterPaths(paths, types);

            return string.Join(Environment.NewLine, filteredPaths);
        }

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



        static bool IsFileType(string path, string[] types)
        {
            string extension = Path.GetExtension(path);
            return types.Any(type => extension.Equals(type, StringComparison.OrdinalIgnoreCase));
        }

        public static string GetFoldersInDirectory(string path, QuickSearchMaster master)
        {
            try
            {
                string[] files = Directory.GetFiles(path);
                string[] directories = Directory.GetDirectories(path);


                string content = "";

                foreach (string directory in directories)
                {
                    content += Path.GetFileName(directory) + "\n";
                }

                var lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                var nonBlankLines = lines.Where(line => !string.IsNullOrWhiteSpace(line));
                return string.Join("\n", nonBlankLines);
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static string GetContentInDirectory(string path)
        {
            try
            {
                string[] files = Directory.GetFiles(path);
                string[] directories = Directory.GetDirectories(path);


                string content = "";

                foreach (string file in files)
                {
                    content += Path.GetFileName(file) + "\n";
                }

                var lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                var nonBlankLines = lines.Where(line => !string.IsNullOrWhiteSpace(line));

                return string.Join("\n", nonBlankLines);
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private static string FilterFoldersFromPaths(string paths)
        {
            List<string> filteredPaths = FilterFolders(paths);
            return RemoveDuplicateLines(string.Join(Environment.NewLine, filteredPaths));
        }

        static List<string> FilterFolders(string paths)
        {
            List<string> filteredPaths = new List<string>();

            string[] pathArray = paths.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var path in pathArray)
            {
                filteredPaths.Add(OneStepUp(path));
            }
            return filteredPaths;
        }

        static string OneStepUp(string path)
        {

            int lastSeparatorIndex = path.LastIndexOf('\\');

            if (lastSeparatorIndex > 0)
            {
                return path.Substring(0, lastSeparatorIndex);
            }
            else
            {
                return "";
            }
        }

        static string RemoveDuplicateLines(string input)
        {
            
            HashSet<string> uniqueLines = new HashSet<string>();
            StringBuilder resultBuilder = new StringBuilder();

            
            string[] lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            foreach (string line in lines)
            {
                if (uniqueLines.Add(line))
                {
                    
                    resultBuilder.AppendLine(line);
                }
            }

            return resultBuilder.ToString().TrimEnd();
        }

        static string FilterPathsByKeyword(string input, string keyword)
        {
            StringBuilder resultBuilder = new StringBuilder();
            string[] lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            foreach (string line in lines)
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

                    string filteredPath = path.Substring(0, endIndex);
                    resultBuilder.AppendLine(filteredPath);
                }
            }

            return resultBuilder.ToString().TrimEnd();
        }

        private static int StringToInt(string value)
        {
            int result;
            if (int.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                Debug.WriteLine("StringToIntError: Invalid integer string '" + value + "'");
                return 0;
            }
        }
    }
}
