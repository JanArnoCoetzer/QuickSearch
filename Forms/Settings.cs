using System.Diagnostics;
using WindowsQuickSearch.Classes;


namespace WindowsQuickSearch.Forms
{
    public partial class Settings : Form
    {

        private bool _indexing = false;
        private bool _firstindex = true;
        private bool initialStartWithWindows;
        private bool initialIndexOnStart;
        private bool initialSmartIndex;
        private bool initialMultiThreading;
        private int initialDelay;
        private int initialThreadCount;
        private string initialLastIndexed;

        private System.Windows.Forms.Timer _timer;
        private Stopwatch _stopwatch;


        public Settings()
        {
            InitializeComponent();
            CenterToScreen();
            SetSettingsValues();
            StoreInitialValues();
            CheckSave();
        }

        private async void StartIndexing_Click(object sender, EventArgs e)
        {
            Save();
            StartIndexing.Enabled = false;
            _indexing = true;
            CheckSave();
            string[] back = new string[3];
            startProgressBar();

            await Task.Run(() =>
            {

                back = FileManager.IndexFiles();

            });

            FileManager.SetFieldInFile(FileManager._appSettingsFile, "Previous_Indexing_Time", back[0]);
            FileManager.SetFieldInFile(FileManager._appSettingsFile, "Previous_Processing_Time", back[1]);
            FileManager.SetFieldInFile(FileManager._appSettingsFile, "Previous_Saving_Time", back[2]);

            PrevTimeLabel.Text = back[0];
            DateTime currentDateTime = DateTime.Now;
            LastIndexedLabel.Text = currentDateTime.ToString("yyyy-MM-dd HH:mm");
            FileManager.SetFieldInFile(FileManager._appSettingsFile, "Last_Indexed", LastIndexedLabel.Text);
            StartIndexing.Enabled = true;
            CheckSave();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void SetSettingsValues()
        {
            _firstindex = StringToBool(FileManager.GetFieldInFile(FileManager._appSettingsFile, "First_Index"));
            StartWithWindowsCheck.Checked = StringToBool(FileManager.GetFieldInFile(FileManager._appSettingsFile, "Launch_On_Start"));
            IndexOnStartCheck.Checked = StringToBool(FileManager.GetFieldInFile(FileManager._appSettingsFile, "Index_On_Start"));
            DelayBox.Value = StringToInt(FileManager.GetFieldInFile(FileManager._appSettingsFile, "Index_On_Start_Delay"));
            SmartIndexCheck.Checked = StringToBool(FileManager.GetFieldInFile(FileManager._appSettingsFile, "Smart_Indexing"));
            MultiThreadingCheck.Checked = StringToBool(FileManager.GetFieldInFile(FileManager._appSettingsFile, "Multi_Threading"));
            DelayBox.Value = StringToInt(FileManager.GetFieldInFile(FileManager._appSettingsFile, "Index_On_Start_Delay"));
            ThreadCountTrackBar.Minimum = 1;
            ThreadCountTrackBar.Maximum = Environment.ProcessorCount;
            int threadfingCount = StringToInt(FileManager.GetFieldInFile(FileManager._appSettingsFile, "Multi_Threaded_Indexing_Max_Threads"));
            ThreadCountTrackBar.Value = threadfingCount;
            ThreadCountLabel.Text = threadfingCount.ToString();
            LastIndexedLabel.Text = FileManager.GetFieldInFile(FileManager._appSettingsFile, "Last_Indexed");
            PrevTimeLabel.Text = FileManager.GetFieldInFile(FileManager._appSettingsFile, "Previous_Indexing_Time");

            if (MultiThreadingCheck.Checked == true)
            {
                ThreadCountTrackBar.Enabled = true;
            }
            else if (MultiThreadingCheck.Checked == false)
            {
                ThreadCountTrackBar.Enabled = false;
            }

            if (StartWithWindowsCheck.Checked == true)
            {
                IndexOnStartCheck.Enabled = true;
            }
            else if (StartWithWindowsCheck.Checked == false)
            {
                IndexOnStartCheck.Enabled = false;
            }

            if (IndexOnStartCheck.Checked == true && StartWithWindowsCheck.Checked == true)
            {
                DelayBox.Enabled = true;
            }
            else if (IndexOnStartCheck.Checked == false || StartWithWindowsCheck.Checked == false)
            {
                DelayBox.Enabled = false;
            }


        }

        private void StoreInitialValues()
        {
            initialStartWithWindows = StartWithWindowsCheck.Checked;
            initialIndexOnStart = IndexOnStartCheck.Checked;
            initialSmartIndex = SmartIndexCheck.Checked;
            initialMultiThreading = MultiThreadingCheck.Checked;
            initialDelay = (int)DelayBox.Value;
            initialThreadCount = ThreadCountTrackBar.Value;
            initialLastIndexed = LastIndexedLabel.Text;
        }

        private bool StringToBool(string value)
        {
            return value.ToLower() == "true";
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

        private static TimeSpan StringToTimeSpan(string timeString)
        {
            // Define the format for mm:ss
            string format = @"mm\:ss";

            TimeSpan timeSpan;
            if (TimeSpan.TryParseExact(timeString, format, System.Globalization.CultureInfo.InvariantCulture, out timeSpan))
            {
                return timeSpan;
            }
            else
            {
                throw new FormatException($"Unable to parse '{timeString}' into a TimeSpan using the provided format.");
            }
        }

        private void ThreadCountTrackBar_ValueChanged(object sender, EventArgs e)
        {
            ThreadCountLabel.Text = ThreadCountTrackBar.Value.ToString();
            CheckSave();
        }

        private void CheckSave()
        {
            bool isModified =
                StartWithWindowsCheck.Checked != initialStartWithWindows ||
                IndexOnStartCheck.Checked != initialIndexOnStart ||
                SmartIndexCheck.Checked != initialSmartIndex ||
                MultiThreadingCheck.Checked != initialMultiThreading ||
                (int)DelayBox.Value != initialDelay ||
                ThreadCountTrackBar.Value != initialThreadCount ||
                LastIndexedLabel.Text != initialLastIndexed;

            if (isModified&&!_indexing)
            {
                AllowSave();
            }
            else
            {
                BlockSave();
            }
        }

        private void AllowSave()
        {
            Savebutton.Enabled = true;
        }
        private void BlockSave()
        {
            Savebutton.Enabled = false;
        }

        private void StartWithWindowsCheck_CheckStateChanged(object sender, EventArgs e)
        {
            if (StartWithWindowsCheck.Checked == true)
            {
                IndexOnStartCheck.Enabled = true;
            }
            else if (StartWithWindowsCheck.Checked == false)
            {
                IndexOnStartCheck.Enabled = false;
            }

            if (IndexOnStartCheck.Checked == true && StartWithWindowsCheck.Checked == true)
            {
                DelayBox.Enabled = true;
            }
            else if (IndexOnStartCheck.Checked == false || StartWithWindowsCheck.Checked == false)
            {
                DelayBox.Enabled = false;
            }


            CheckSave();
        }

        private void IndexOnStartCheck_CheckStateChanged(object sender, EventArgs e)
        {
            if (IndexOnStartCheck.Checked == true)
            {
                DelayBox.Enabled = true;
            }
            else if (IndexOnStartCheck.Checked == false)
            {
                DelayBox.Enabled = false;
            }
            CheckSave();
        }

        private void SmartIndexCheck_CheckStateChanged(object sender, EventArgs e)
        {


            CheckSave();
        }

        private void MultiThreadingCheck_CheckStateChanged(object sender, EventArgs e)
        {
            if (MultiThreadingCheck.Checked == true)
            {
                ThreadCountTrackBar.Value = Environment.ProcessorCount / 2;
                ThreadCountTrackBar.Enabled = true;
            }
            else if (MultiThreadingCheck.Checked == false)
            {
                ThreadCountTrackBar.Value = 1;
                ThreadCountTrackBar.Enabled = false;
            }


            CheckSave();
        }
        private void DelayBox_ValueChanged(object sender, EventArgs e)
        {
            CheckSave();
        }


        private void Savebutton_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
            this.Dispose();
        }


        private void Save() 
        {
            FileManager.SetFieldInFile(FileManager._appSettingsFile, "Launch_On_Start", StartWithWindowsCheck.Checked.ToString().ToLower());
            FileManager.SetFieldInFile(FileManager._appSettingsFile, "Index_On_Start", IndexOnStartCheck.Checked.ToString().ToLower());
            FileManager.SetFieldInFile(FileManager._appSettingsFile, "Index_On_Start_Delay", DelayBox.Value.ToString());
            FileManager.SetFieldInFile(FileManager._appSettingsFile, "Smart_Indexing", SmartIndexCheck.Checked.ToString().ToLower());
            FileManager.SetFieldInFile(FileManager._appSettingsFile, "Multi_Threading", MultiThreadingCheck.Checked.ToString().ToLower());
            FileManager.SetFieldInFile(FileManager._appSettingsFile, "Multi_Threaded_Indexing_Max_Threads", ThreadCountTrackBar.Value.ToString());                     
        }

        private TimeSpan prevTS; 

        private void startProgressBar()
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();

            
            string prevTimeString = FileManager.GetFieldInFile(FileManager._appSettingsFile, "Previous_Indexing_Time");
            prevTS = StringToTimeSpan(prevTimeString);

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 100; 
            _timer.Tick += new EventHandler(UpdateProgress);
            _timer.Start();
        }

        private void UpdateProgress(object sender, EventArgs e)
        {
            if (_indexing)
            {
                TimeSpan elapsed = _stopwatch.Elapsed;

                // Calculate percentage completion between current elapsed time and previous elapsed time
                double percentage = (elapsed.TotalMilliseconds / (prevTS.TotalMilliseconds + elapsed.TotalMilliseconds)) * 100;                
                IndexingProgressBar.Value = (float) percentage;
                
            }
            else
            {
                _stopwatch.Stop();
                _timer.Stop();
            }
        }


    }
}
