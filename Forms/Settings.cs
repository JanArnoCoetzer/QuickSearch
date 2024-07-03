using Microsoft.Win32;
using System.Diagnostics;
using WindowsQuickSearch.Classes;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsQuickSearch.Forms
{
    public partial class Settings : Form
    {
        private System.Windows.Forms.Timer _timer;
        private Stopwatch _stopwatch;
        private bool _indexing = false;

        // Initial settings values
        private bool initialStartWithWindows;
        private bool initialIndexOnStart;
        private bool initialSmartIndex;
        private int initialDelay;

        // Constructor to initialize form and settings
        public Settings()
        {
            InitializeComponent();
            CenterToScreen();
            SetSettingsValues();
            StoreInitialValues();
            CheckSave();
        }

        // Start indexing files
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

            TimeSpan sumts = StringToTimeSpan(back[0]) + StringToTimeSpan(back[1]) + StringToTimeSpan(back[2]);

            IndexTimeLabel.Text = back[0];
            ProcessingTimeLabel.Text = back[1];
            SavingTimeLabel.Text = back[2];
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

        // Set initial values for settings
        private void SetSettingsValues()
        {
            StartWithWindowsCheck.Checked = StringToBool(FileManager.GetFieldInFile(FileManager._appSettingsFile, "Launch_On_Start"));
            IndexOnStartCheck.Checked = StringToBool(FileManager.GetFieldInFile(FileManager._appSettingsFile, "Index_On_Start"));
            DelayBox.Value = StringToInt(FileManager.GetFieldInFile(FileManager._appSettingsFile, "Index_On_Start_Delay"));
            SmartIndexCheck.Checked = StringToBool(FileManager.GetFieldInFile(FileManager._appSettingsFile, "Smart_Indexing"));
            LastIndexedLabel.Text = FileManager.GetFieldInFile(FileManager._appSettingsFile, "Last_Indexed");
            VersionLabel.Text = "Version:" + FileManager.GetFieldInFile(FileManager._appSettingsFile, "Version");

            TimeSpan sumts = StringToTimeSpan(FileManager.GetFieldInFile(FileManager._appSettingsFile, "Previous_Indexing_Time")) +
                             StringToTimeSpan(FileManager.GetFieldInFile(FileManager._appSettingsFile, "Previous_Processing_Time")) +
                             StringToTimeSpan(FileManager.GetFieldInFile(FileManager._appSettingsFile, "Previous_Saving_Time"));

            IndexTimeLabel.Text = FileManager.GetFieldInFile(FileManager._appSettingsFile, "Previous_Indexing_Time");
            ProcessingTimeLabel.Text = FileManager.GetFieldInFile(FileManager._appSettingsFile, "Previous_Processing_Time");
            SavingTimeLabel.Text = FileManager.GetFieldInFile(FileManager._appSettingsFile, "Previous_Saving_Time");
            PrevTimeLabel.Text = ConvertToMinutesAndSeconds(sumts);

            IndexOnStartCheck.Enabled = StartWithWindowsCheck.Checked;
            DelayBox.Enabled = IndexOnStartCheck.Checked && StartWithWindowsCheck.Checked;
        }

        // Store initial values for comparison when checking for changes
        private void StoreInitialValues()
        {
            initialStartWithWindows = StartWithWindowsCheck.Checked;
            initialIndexOnStart = IndexOnStartCheck.Checked;
            initialSmartIndex = SmartIndexCheck.Checked;
            initialDelay = (int)DelayBox.Value;
        }

        // Convert a string to a boolean
        private bool StringToBool(string value)
        {
            return value.ToLower() == "true";
        }

        // Convert a string to an integer with error handling
        private static int StringToInt(string value)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            else
            {
                Debug.WriteLine("StringToIntError: Invalid integer string '" + value + "'");
                return 0;
            }
        }

        // Convert a string to a TimeSpan
        private static TimeSpan StringToTimeSpan(string timeString)
        {
            if (TimeSpan.TryParseExact(timeString, @"mm\:ss", System.Globalization.CultureInfo.InvariantCulture, out TimeSpan timeSpan))
            {
                return timeSpan;
            }
            else
            {
                throw new FormatException($"Unable to parse '{timeString}' into a TimeSpan using the provided format.");
            }
        }

        // Convert a TimeSpan to a string in minutes and seconds
        private string ConvertToMinutesAndSeconds(TimeSpan timeSpan)
        {
            int totalMinutes = (int)timeSpan.TotalMinutes;
            int seconds = timeSpan.Seconds;
            return $"{totalMinutes:D2}:{seconds:D2}";
        }

        // Save the current settings
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

        // Check if any settings have been modified
        private void CheckSave()
        {
            bool isModified = StartWithWindowsCheck.Checked != initialStartWithWindows ||
                              IndexOnStartCheck.Checked != initialIndexOnStart ||
                              SmartIndexCheck.Checked != initialSmartIndex ||
                              (int)DelayBox.Value != initialDelay;

            Savebutton.Enabled = isModified && !_indexing;
        }

        // Set or remove the application from startup
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

        // Add application to Windows startup
        static void SetStartup()
        {
            string appName = "QuickSearch";
            string appPath = "\"" + Application.ExecutablePath + "\" --autorun"; // Add the --autorun argument

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            key.SetValue(appName, appPath);
        }

        // Remove application from Windows startup
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

        // Display a custom tooltip
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

            // Draw the text
            e.Graphics.DrawString(e.ToolTipText, e.Font, new SolidBrush(textColor), e.Bounds);
        }

        // Destroy the tooltip
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

        // Event handlers for various controls

        // Check state change event for StartWithWindowsCheck
        private void StartWithWindowsCheck_CheckStateChanged(object sender, EventArgs e)
        {
            IndexOnStartCheck.Enabled = StartWithWindowsCheck.Checked;
            if (!StartWithWindowsCheck.Checked)
            {
                IndexOnStartCheck.Checked = false;
            }

            DelayBox.Enabled = IndexOnStartCheck.Checked && StartWithWindowsCheck.Checked;
            CheckSave();
        }

        // Mouse hover event for StartWithWindowsCheck
        private void StartWithWindowsCheck_MouseHover(object sender, EventArgs e)
        {
            DisplayToolTip("QuickSearch will Start when windows is started");
        }

        // Mouse leave event for StartWithWindowsCheck
        private void StartWithWindowsCheck_MouseLeave(object sender, EventArgs e)
        {
            DestroyToolTip();
        }

        // Check state change event for IndexOnStartCheck
        private void IndexOnStartCheck_CheckStateChanged(object sender, EventArgs e)
        {
            DelayBox.Enabled = IndexOnStartCheck.Checked;
            CheckSave();
        }

        // Mouse hover event for IndexOnStartCheck
        private void IndexOnStartCheck_MouseHover(object sender, EventArgs e)
        {
            DisplayToolTip("QuickSearch will index after it starts with windows");
        }

        // Mouse leave event for IndexOnStartCheck
        private void IndexOnStartCheck_MouseLeave(object sender, EventArgs e)
        {
            DestroyToolTip();
        }

        // Check state change event for SmartIndexCheck
        private void SmartIndexCheck_CheckStateChanged(object sender, EventArgs e)
        {
            CheckSave();
        }

        // Mouse hover event for SmartIndexCheck
        private void SmartIndexCheck_MouseHover(object sender, EventArgs e)
        {
            DisplayToolTip("Will Index whenever the computer is not in use");
        }

        // Mouse leave event for SmartIndexCheck
        private void SmartIndexCheck_MouseLeave(object sender, EventArgs e)
        {
            DestroyToolTip();
        }

        // Value changed event for DelayBox
        private void DelayBox_ValueChanged(object sender, EventArgs e)
        {
            CheckSave();
        }

        // Click event for Savebutton
        private void Savebutton_Click(object sender, EventArgs e)
        {
            Save();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        // Click event for CloseButton
        private void CloseButton_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            this.Close();
            this.Dispose();
        }
    }
}
