using System;
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
    }
}
