using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace PracticalWork9
{
    public partial class MainWindow : Window
    {
        public static MainWindow Window;
        public MainWindow()
        {
            InitializeComponent();
            Window = this;
        }

        private void DragWindow(object sender, RoutedEventArgs e)
        {
            if(Mouse.LeftButton == MouseButtonState.Pressed)
            {
                MainWindow.Window.DragMove();
            }
        }
        private void SplitTextButton_Click(object sender, RoutedEventArgs e)
        {
            SplittedTextListBox.Items.Clear();
            if (!String.IsNullOrEmpty(OriginalTextBox.Text))
            {
                var lines = new List<string>(OriginalTextBox.Text.Split(' '));
                foreach (var line in lines)
                {
                    SplittedTextListBox.Items.Add(line);
                }
            }
        }

        private void ReverseTextButton_Click(object sender, RoutedEventArgs e)
        {
            ReverseTextLabel.Content = "";
            if (!String.IsNullOrEmpty(OriginalTextBox.Text))
            {
                string[] lines = OriginalTextBox.Text.Split(' ');
                Array.Reverse(lines);
                foreach (var line in lines)
                {
                    ReverseTextLabel.Content += line+' ';
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
