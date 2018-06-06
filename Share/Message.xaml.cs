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
using System.Windows.Shapes;

namespace Share
{
    /// <summary>
    /// Interaction logic for Message.xaml
    /// </summary>
    public partial class Message : Window
    {
        public Message(string Title, string MessageString)
        {
            InitializeComponent();
            MessageTitle.Text = Title ?? "";
            MessageContent.Text = MessageString ?? "";
            
            
        }
        public Message(string Title, string MessageString, int WindowHeigth, int WindowWidth)
        {
           
            
            InitializeComponent();
            this.MaxHeight = WindowHeigth;
            this.MaxWidth = WindowWidth;
            this.Height = WindowHeigth;
            this.Width = WindowWidth;
            MessageTitle.Text = Title ?? "";
            MessageContent.Text = MessageString ?? "";


        }
        private void CloseWindow(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void Minimizebtn(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void Close_Hover(object sender, MouseEventArgs e)
        {
            TextBlock srcButton = e.Source as TextBlock;
            srcButton.Foreground = Brushes.Red;
        }

        private void Close_EndHover(object sender, MouseEventArgs e)
        {
            TextBlock srcButton = e.Source as TextBlock;
            srcButton.Foreground = Brushes.White;
        }
        private void Grid(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CopyMessage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(MessageContent.Text);
            CopiedText.Text = "Copied";
        }
    }
}
