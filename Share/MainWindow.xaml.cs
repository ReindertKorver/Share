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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoginFormControl.Content = new SignInFormControl();
            MainFormControl.Content = new StartMenuControl();
        }
        public string LoginTextString
        {
            get
            {
                return LoginText.Text;
            }
            set
            {
                LoginText.Text = value;
            }
        }
        public Thickness LoginFormThickness
        {
            get { return LoginGrid.Margin; }
            set { LoginGrid.Margin = value; }
        }
        public void ShowLoginForm(bool showForm)
        {
            if (showForm)
            {
                LoginGrid.Margin = new Thickness(-50, 0, 0, 0);
            }
            else
            {
                LoginGrid.Margin = new Thickness(-700, 0, 0, 0);
            }
        }
        private void ShowLogin(object sender, MouseButtonEventArgs e)
        {
            if (LoginGrid.Margin == new Thickness(-700, 0, 0, 0))
            {
                LoginGrid.Margin = new Thickness(-50, 0, 0, 0);
            }
            else
            {
                LoginGrid.Margin = new Thickness(-700, 0, 0, 0);
            }
        }
       
        private void Grid(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
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


        private void CloseWindow(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Application.Current.MainWindow.Close();
        }


        //private void SignInClick(object sender, RoutedEventArgs e)
        //{
        //    string TBUsername = Username.Text;
        //    string TBPassword = Password.Password;
        //    if (!string.IsNullOrEmpty(TBUsername) && !string.IsNullOrEmpty(TBPassword))
        //    {
        //        try
        //        {
        //            Class.User LoggedInUser = Methods.Database.SignInUser(new Class.User() { Email = TBUsername, Password = TBPassword });
        //            if (LoggedInUser != null)
        //            {
        //                App.Current.Properties["LoggedinUser"] = LoggedInUser;
        //                LoginText.Text = LoggedInUser.Name;
        //                ShowMessage("You are logged in", "Welcome " + LoggedInUser.Name + "!");
        //                LoginGrid.Margin = new Thickness(-700, 0, 0, 0);
        //                SignInForm.Visibility = Visibility.Collapsed;
        //                SignedInForm.Visibility = Visibility.Visible;
        //            }
        //            else
        //            {
        //                Messager.Show("Oops", "Wrong combination of username and password.\nPlease try again");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Messager.Show("Something went wrong",ex.Message);
        //        }
        //    }
        //    else
        //    {
        //        Messager.Show("Eeh", "You didn't fill one or more of the required textboxes.\nPlease try again");
        //    }
        //}
        //private void SignOutClick(object sender, RoutedEventArgs e)
        //{
        //    LoginText.Text = "Login";
        //    ShowMessage("You are logged out", "See you soon!");
        //    MainContent.Content = new StartMenu();
        //    LoginGrid.Margin = new Thickness(-700, 0, 0, 0);
        //}

        private void Minimizebtn(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        //private void TypeSelectionChange(object sender, SelectionChangedEventArgs e)
        //{
        //    TextBox.Visibility = Visibility.Collapsed;
        //    TextTitle.Visibility = Visibility.Collapsed;
        //    FileBox.Visibility = Visibility.Collapsed;
        //    FileTitle.Visibility = Visibility.Collapsed;
        //    switch (Type.SelectedIndex)
        //    {
        //        case 0:
        //            TextBox.Visibility = Visibility.Visible;
        //            TextTitle.Visibility = Visibility.Visible;
        //            break;
        //        case 1:
        //            FileBox.Visibility = Visibility.Visible;
        //            FileTitle.Visibility = Visibility.Visible;
        //            break;
        //    }
        ////}
        //public void ShowMessage(string Title, string MessageString)
        //{
        //    Message message = new Message(Title, MessageString);
        //    message.ShowDialog();
        //}

        private void AddUser(object sender, RoutedEventArgs e)
        {

        }

        //private void Share_Click(object sender, RoutedEventArgs e)
        //{
        //    if (Type.SelectedIndex == 0)
        //    {
        //        //send plaintext
        //        Class.File file = new Class.File();
        //        file.Data = TextBox.Text;
        //        file.Datetime = DateTime.Now;
        //        file.EmailToUser = SendTo.Text;
        //        file.FromUser = ((Class.User)App.Current.Properties["LoggedinUser"]) ;
        //        file.isText = true;
        //        string result = Methods.Database.SendData(file);
        //        Messager.Show("Result",result);
        //    }
        //    else if(Type.SelectedIndex==1)
        //    {
        //        //send file
        //        Class.File file = new Class.File();
        //        file.Data = FileBox.Text;
        //        file.Datetime = DateTime.Now;
        //        file.EmailToUser = SendTo.Text;
        //        file.FromUser = ((Class.User)App.Current.Properties["LoggedinUser"]);
        //        file.isText = false;
        //        string result = Methods.Database.SendData(file);
        //        Messager.Show("Result", result);
        //    }
        //}
    }
}
