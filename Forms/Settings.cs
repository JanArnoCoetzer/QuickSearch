using WindowsQuickSearch.Classes;

namespace WindowsQuickSearch.Forms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void StartIndexing_Click(object sender, EventArgs e)
        {
            FileManager.IndexFiles();
            this.Close();
            this.Dispose();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
