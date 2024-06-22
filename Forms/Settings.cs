using Microsoft.Win32;
using System.Diagnostics;
using WindowsQuickSearch.Classes;

//Index After Start to be done
//Delay before indexing after start to be done
//Smart Indexing to be done

namespace WindowsQuickSearch.Forms
{
    public partial class Settings : Form
    {
        private System.Windows.Forms.Timer _timer;
        private Stopwatch _stopwatch;
        private bool _indexing = false;

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
            _indexing = true;
            StartIndexing.Enabled = false;

            Save();
            CheckSave();

            circularSpinner.StartSpinning();
            circularSpinner.ForeColor = Color.FromArgb(0, 204, 204);
            circularSpinner.BackColor = Color.FromArgb(21, 21, 21);

            string[] back = new string[3];

            await Task.Run(() =>
            {
                back = FileManager.IndexFiles();
            });

            TimeSpan sumts;
            sumts = StringToTimeSpan(back[0]);
            sumts += StringToTimeSpan(back[1]);
            sumts += StringToTimeSpan(back[2]);

            IndexTimeLabel.Text = back[0].ToString();
            ProcessingTimeLabel.Text = back[1].ToString();
            SavingTimeLabel.Text = back[2].ToString();
            PrevTimeLabel.Text = ConvertToMinutesAndSeconds(sumts);

            DateTime currentDateTime = DateTime.Now;
            LastIndexedLabel.Text = currentDateTime.ToString("yyyy-MM-dd HH:mm");

            FileManager.SetFieldInFile(FileManager._appSettingsFile, "Previous_Indexing_Time", back[0]);
            FileManager.SetFieldInFile(FileManager._appSettingsFile, "Previous_Processing_Time", back[1]);
            FileManager.SetFieldInFile(FileManager._appSettingsFile, "Previous_Saving_Time", back[2]);
            FileManager.SetFieldInFile(FileManager._appSettingsFile, "Previous_Total_Indexing_Time", PrevTimeLabel.Text);
            FileManager.SetFieldInFile(FileManager._appSettingsFile, "Last_Indexed", LastIndexedLabel.Text);

            StartIndexing.Enabled = true;

            CheckSave();

            circularSpinner.ForeColor = Color.FromArgb(36, 36, 36);
            circularSpinner.BackColor = Color.FromArgb(36, 36, 36);
        }



        private void SetSettingsValues()
        {
            StartWithWindowsCheck.Checked = StringToBool(FileManager.GetFieldInFile(FileManager._appSettingsFile, "Launch_On_Start"));
            IndexOnStartCheck.Checked = StringToBool(FileManager.GetFieldInFile(FileManager._appSettingsFile, "Index_On_Start"));
            DelayBox.Value = StringToInt(FileManager.GetFieldInFile(FileManager._appSettingsFile, "Index_On_Start_Delay"));
            SmartIndexCheck.Checked = StringToBool(FileManager.GetFieldInFile(FileManager._appSettingsFile, "Smart_Indexing"));
            LastIndexedLabel.Text = FileManager.GetFieldInFile(FileManager._appSettingsFile, "Last_Indexed");

            string prevTimeString1 = FileManager.GetFieldInFile(FileManager._appSettingsFile, "Previous_Indexing_Time");
            string prevTimeString2 = FileManager.GetFieldInFile(FileManager._appSettingsFile, "Previous_Processing_Time");
            string prevTimeString3 = FileManager.GetFieldInFile(FileManager._appSettingsFile, "Previous_Saving_Time");

            TimeSpan sumts;

            sumts = StringToTimeSpan(prevTimeString1);
            sumts += StringToTimeSpan(prevTimeString2);
            sumts += StringToTimeSpan(prevTimeString3);

            IndexTimeLabel.Text = prevTimeString1;
            ProcessingTimeLabel.Text = prevTimeString2;
            SavingTimeLabel.Text = prevTimeString3;
            PrevTimeLabel.Text = ConvertToMinutesAndSeconds(sumts);

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
            initialDelay = (int)DelayBox.Value;
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

        private string ConvertToMinutesAndSeconds(TimeSpan timeSpan)
        {
            
            int totalMinutes = (int)timeSpan.TotalMinutes;
            int seconds = timeSpan.Seconds;

            return $"{totalMinutes:D2}:{seconds:D2}";
        }

        private bool initialStartWithWindows;
        private bool initialIndexOnStart;
        private bool initialSmartIndex;
        private int initialDelay;



        private void Save()
        {
            FileManager.SetFieldInFile(FileManager._appSettingsFile, "Launch_On_Start", StartWithWindowsCheck.Checked.ToString().ToLower());
            FileManager.SetFieldInFile(FileManager._appSettingsFile, "Index_On_Start", IndexOnStartCheck.Checked.ToString().ToLower());
            FileManager.SetFieldInFile(FileManager._appSettingsFile, "Index_On_Start_Delay", DelayBox.Value.ToString());
            FileManager.SetFieldInFile(FileManager._appSettingsFile, "Smart_Indexing", SmartIndexCheck.Checked.ToString().ToLower());

            StartWithWindows(StringToBool(FileManager.GetFieldInFile(FileManager._appSettingsFile, "Launch_On_Start")));

            SetSettingsValues();
            StoreInitialValues();
            CheckSave();
        }

        private void CheckSave()
        {
            bool isModified =
                StartWithWindowsCheck.Checked != initialStartWithWindows ||
                IndexOnStartCheck.Checked != initialIndexOnStart ||
                SmartIndexCheck.Checked != initialSmartIndex ||
                (int)DelayBox.Value != initialDelay;

            if (isModified && !_indexing)
            {

                Savebutton.Enabled = true;
            }
            else
            {
                Savebutton.Enabled = false;
            }
        }

        private void StartWithWindows(bool start)
        {
            if (start)
            {
                SetStartup();
            }
            else
            {
                RemoveStartup();
            }
        }

        static void SetStartup()
        {
            string appName = "QuickSearch";
            string appPath = "\"" + Application.ExecutablePath + "\" --autorun"; // Add the --autorun argument

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            key.SetValue(appName, appPath);
        }

        static void RemoveStartup()
        {
            string appName = "QuickSearch";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            if (key.GetValue(appName) != null)
            {
                key.DeleteValue(appName);
            }
        }

        private System.Windows.Forms.Timer tooltipTimer;
        private string tooltipText;

        private void DisplayToolTip(string text)
        {
            tooltipTimer = new System.Windows.Forms.Timer();
            tooltipTimer.Interval = 2000; // 2 seconds
            tooltipTimer.Tick += TooltipTimer_Tick;

            // Enable owner-drawn tooltip
            toolTip1.OwnerDraw = true;
            toolTip1.Draw += new DrawToolTipEventHandler(toolTip1_Draw);

            tooltipText = text;
            tooltipTimer.Start();
        }
        private void TooltipTimer_Tick(object sender, EventArgs e)
        {
            tooltipTimer.Stop();
            Point mousePos = this.PointToClient(Cursor.Position);
            toolTip1.Show(tooltipText, this, mousePos.X + 10, mousePos.Y + 10);
        }

        private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            
            Color backColor = Color.FromArgb(32, 32, 32); 
            Color textColor = Color.LightGray; 

            // Fill the background
            e.Graphics.FillRectangle(new SolidBrush(backColor), e.Bounds);

            
            e.Graphics.DrawString(e.ToolTipText, e.Font, new SolidBrush(textColor), e.Bounds);
        }

        private void DestroyToolTip()
        {
            if (toolTip1 != null && toolTip1.Active) 
            {
                toolTip1.Hide(this);
                
            }

            if (tooltipTimer != null && tooltipTimer.Enabled) 
            {
                tooltipTimer.Stop(); 
            }
        }
            


        //Buttons and options
        private void StartWithWindowsCheck_CheckStateChanged(object sender, EventArgs e)
        {
            if (StartWithWindowsCheck.Checked == true)
            {
                IndexOnStartCheck.Enabled = true;

            }
            else if (StartWithWindowsCheck.Checked == false)
            {
                IndexOnStartCheck.Enabled = false;
                IndexOnStartCheck.Checked = false;
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

        private void StartWithWindowsCheck_MouseHover(object sender, EventArgs e)
        {
            DisplayToolTip("QuickSearch will Start when windows is started");
        }
        private void StartWithWindowsCheck_MouseLeave(object sender, EventArgs e)
        {
            DestroyToolTip();
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

        private void IndexOnStartCheck_MouseHover(object sender, EventArgs e)
        {
            DisplayToolTip("QuickSearch will index after it starts with windows");
        }

        private void IndexOnStartCheck_MouseLeave(object sender, EventArgs e)
        {
            
            DestroyToolTip();
 
        }

        private void SmartIndexCheck_CheckStateChanged(object sender, EventArgs e)
        {
            CheckSave();
        }
        private void SmartIndexCheck_MouseHover(object sender, EventArgs e)
        {
            DisplayToolTip("Will Index whenever the computer is not in use");
        }

        private void SmartIndexCheck_MouseLeave(object sender, EventArgs e)
        {
            DestroyToolTip();
        }

        private void DelayBox_ValueChanged(object sender, EventArgs e)
        {
            CheckSave();
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            Save();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            this.Close();
            this.Dispose();
        }

        
    }
}
