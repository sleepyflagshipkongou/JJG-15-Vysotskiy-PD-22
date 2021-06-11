using System.IO;
using System.Windows;

namespace lab_7_WPF_
{
    public partial class FileWindow : Window
    {
        public FileWindow()
        {
            InitializeComponent();
        }
        public void fillWindow(string pathToFile)
        {
            this.Title = new FileInfo(pathToFile).Name;
            using (StreamReader fileReader = new StreamReader(pathToFile))
            {
                textArea.Text = fileReader.ReadToEnd();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            (sender as Window).Hide();

            this.Title = "";
            textArea.Text = "";
        }
    }
}
