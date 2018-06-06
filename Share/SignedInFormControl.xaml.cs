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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Share
{
    /// <summary>
    /// Interaction logic for SignedInFormControl.xaml
    /// </summary>
    public partial class SignedInFormControl : UserControl
    {
        List<Class.File> files;
        public SignedInFormControl()
        {
            InitializeComponent();
            LoadFileView();
        }
        void LoadFileView()
        {
            try
            {
                if ((Class.User)App.Current.Properties["LoggedinUser"] != null)
                {
                     files = Methods.Database.GetFiles((Class.User)App.Current.Properties["LoggedinUser"]);
                    FileView.ItemsSource = files;
                    
                }
            }
            catch (Exception ex)
            {
                Messager.Show("Exception", "Something went wrong: " + ex.Message);

            }
        }
        private void SignOutClick(object sender, RoutedEventArgs e)
        {
            //set the login text back to login
            App.Current.Properties["LoggedinUser"] = null;
            MainWindow main = (MainWindow)Application.Current.MainWindow;
            main.LoginTextString = "Login";
            Messager.Show("You are logged out", "See you soon!");
            main.LoginFormThickness = new Thickness(-700, 0, 0, 0);
            main.LoginFormControl.Content = new SignInFormControl();
            main.MainFormControl.Content = new StartMenuControl();

        }
        
        private void RefreshButtonClick(object sender, MouseButtonEventArgs e)
        {
           Task.Delay(100);
                LoadFileView();
            

        }

        private void FileViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object selectedValue = FileView.SelectedValue;
            int value = Convert.ToInt32(selectedValue);
            Class.File file = files.Where(w => w.ID == value).FirstOrDefault();
            Messager.ShowFile(file);
        }
    }
}
