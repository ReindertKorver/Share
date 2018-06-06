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
    /// Interaction logic for SignInFormControl.xaml
    /// </summary>
    public partial class SignInFormControl : UserControl
    {
        public SignInFormControl()
        {
            InitializeComponent();
        }
        private void SignInClick(object sender, RoutedEventArgs e)
        {
            string TBUsername = Username.Text;
            string TBPassword = Password.Password;
            if (!string.IsNullOrEmpty(TBUsername) && !string.IsNullOrEmpty(TBPassword))
            {
                try
                {
                    Class.User LoggedInUser = Methods.Database.SignInUser(new Class.User() { Email = TBUsername, Password = TBPassword });
                    if (LoggedInUser != null&&LoggedInUser.Email!=null)
                    {
                        App.Current.Properties["LoggedinUser"] = LoggedInUser;
                        MainWindow main = (MainWindow)Application.Current.MainWindow;
                        main.LoginTextString = LoggedInUser.Name;
                        Messager.Show("You are logged in", "Welcome " + LoggedInUser.Name + "!");
                        main.LoginFormThickness = new Thickness(-700, 0, 0, 0);
                        main.LoginFormControl.Content = new SignedInFormControl();
                        main.MainFormControl.Content = new ShareMenuControl();
                        
                    }
                    else
                    {
                        Messager.Show("Oops", "Wrong combination of username and password.\nPlease try again");
                    }
                }
                catch (Exception ex)
                {
                    Messager.Show("Something went wrong", ex.Message);
                }
            }
            else
            {
                Messager.Show("Eeh", "You didn't fill one or more of the required textboxes.\nPlease try again");
            }
        }
    }
}
