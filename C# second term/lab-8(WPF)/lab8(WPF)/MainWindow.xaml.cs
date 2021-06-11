using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab8_WPF_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path = @"config.lb";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowProperties winConfig;
            BinaryFormatter formater = new BinaryFormatter();

            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    winConfig = (WindowProperties)formater.Deserialize(fs);
                }
            }
            else
            {
                winConfig = new WindowProperties();
            }
            

            this.Height = winConfig.windowHeight;
            this.Width = winConfig.windowWidth;
            textBox.Text = winConfig.textBoxContent;
            checkBox1.IsChecked = winConfig.checkBox1IsChecked;
            checkBox2.IsChecked = winConfig.checkBox2IsChecked;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            WindowProperties winConfig = new WindowProperties();
            BinaryFormatter formater = new BinaryFormatter();

            winConfig.windowHeight = this.Height;
            winConfig.windowWidth = this.Width;
            winConfig.textBoxContent = textBox.Text;
            winConfig.checkBox1IsChecked = checkBox1.IsChecked;
            winConfig.checkBox2IsChecked = checkBox2.IsChecked;

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formater.Serialize(fs, winConfig);
            }
        }
    }
}
