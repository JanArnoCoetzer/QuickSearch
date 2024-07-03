using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using WindowsQuickSearch.Classes;
using WindowsQuickSearch.Forms;

namespace QuickSearch
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            bool isAutoRun = args.Contains("--autorun");

             LaunchAsAdmin("QuickSearchHelper.exe");

            ApplicationConfiguration.Initialize();
            Application.Run(new QuickSearchMaster());

            


            if (isAutoRun && FileManager.GetFieldInFile(FileManager._appSettingsFile, "Index_On_Start") == "true")
            {
                int result;
                if (int.TryParse(FileManager.GetFieldInFile(FileManager._appSettingsFile, "Index_On_Start_Delay"), out result))
                {
                    Thread.Sleep(result*1000);
                    FileManager.IndexFiles();
                }
            }
            else
            {
                
            }          
        }

        static void LaunchAsAdmin(string fileName)
        {
            try
            {
                // Create a new process start info
                ProcessStartInfo processInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    UseShellExecute = true,
                    Verb = "runas" // This specifies the process should be started with admin privileges
                };

                // Start the process
                try 
                { 
                    Process.Start(processInfo); 
                } 
                catch 
                { 

                }
                
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                if (ex.NativeErrorCode == 1223)
                {
                    Console.WriteLine("The operation was canceled by the user.");
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
