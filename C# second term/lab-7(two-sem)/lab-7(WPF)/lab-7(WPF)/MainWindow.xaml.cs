using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;
using WinForms = System.Windows.Forms;

namespace lab_7_WPF_
{
    public partial class MainWindow : Window
    {
        private List<string> pathToFiles = new List<string>();
        private bool isChanged = false;

        private readonly FileWindow fileWindow = new FileWindow();

        WinForms.FolderBrowserDialog fbd = new WinForms.FolderBrowserDialog();

        private readonly string MESSAGE_BOX_TITLE = "Что то пошло не так";

        public MainWindow()
        {
            InitializeComponent();
            mainPath.Text = Path.GetFullPath(".");
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            if (isChanged) return;

            if (mainPath.Text == "" || fileName.Text == "")
            {
                MessageBox.Show("Заполните все соотвецтвующие поля перед поиском", MESSAGE_BOX_TITLE);
                return;
            }

            try
            {
                pathToFiles = Directory.GetFiles(mainPath.Text, fileName.Text, SearchOption.AllDirectories).ToList();
            }
            catch
            {
                MessageBox.Show("Директория заполнена не коректно, либо слишком отдаленний путь от файла", MESSAGE_BOX_TITLE);
                return;
            }

            if (pathToFiles.Count != 0)
            {
                logTextBlock.Foreground = Brushes.Green;
                logTextBlock.Text = "Даний файл найден!!!";
                openButton.IsEnabled = true;
            }
            else
            {
                logTextBlock.Foreground = Brushes.Red;
                logTextBlock.Text = "Такой файл не найден!!!";
                openButton.IsEnabled = false;
            }

            isChanged = true;
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                fileWindow.fillWindow(pathToFiles.First());
                fileWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), MESSAGE_BOX_TITLE);
            }
        }

        private void textChanged(object sender, TextChangedEventArgs e)
        {
            if (isChanged)
            {
                openButton.IsEnabled = false;
                logTextBlock.Text = "";
                pathToFiles.Clear();
                isChanged = false;
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fbd.ShowDialog();
            if (fbd.SelectedPath != "")
                mainPath.Text = fbd.SelectedPath;
            isChanged = false;
        }
    }
}
