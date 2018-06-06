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

namespace Share
{
    /// <summary>
    /// Interaction logic for ShareMenuControl.xaml
    /// </summary>
    public partial class ShareMenuControl : UserControl
    {
        public ShareMenuControl()
        {
            InitializeComponent();
            Type.SelectedIndex = 1;
        }
        private void Share_Click(object sender, RoutedEventArgs e)
        {
            if (Type.SelectedIndex == 0)
            {
                //send plaintext
                Class.File file = new Class.File();
                file.Data = TextBox.Text;
                file.Datetime = DateTime.Now;
                file.EmailToUser = SendTo.Text;
                file.FromUser = ((Class.User)App.Current.Properties["LoggedinUser"]);
                file.isText = true;
                string result = Methods.Database.SendData(file);
                Messager.Show("Result", result);
            }
            else if (Type.SelectedIndex == 1)
            {
                //send file
                Class.File file = new Class.File();
                file.Data = FileBox.Text;
                file.Datetime = DateTime.Now;
                file.EmailToUser = SendTo.Text;
                file.FromUser = ((Class.User)App.Current.Properties["LoggedinUser"]);
                file.isText = false;
                string result = Methods.Database.SendData(file);
                Messager.Show("Result", result);
            }
        }
        private void TypeSelectionChange(object sender, SelectionChangedEventArgs e)
        {
            TextBox.Visibility = Visibility.Collapsed;
            TextTitle.Visibility = Visibility.Collapsed;
            FileBox.Visibility = Visibility.Collapsed;
            FileTitle.Visibility = Visibility.Collapsed;
            switch (Type.SelectedIndex)
            {
                case 0:
                    TextBox.Visibility = Visibility.Visible;
                    TextTitle.Visibility = Visibility.Visible;
                    break;
                case 1:
                    FileBox.Visibility = Visibility.Visible;
                    FileTitle.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}
