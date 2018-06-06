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
    /// Interaction logic for StartMenuControl.xaml
    /// </summary>
    public partial class StartMenuControl : UserControl
    {
        public StartMenuControl()
        {
            InitializeComponent();
        }
        private void Grid(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) { }
            //MainWindow.DragMove();
        }
        private void ShowLogin(object sender, MouseButtonEventArgs e)
        {
            //margin veranderen van loginscherm zodat hij er achter verdwijnt haal dit op uit de mainwindow.xaml
            MainWindow main = (MainWindow)Application.Current.MainWindow;
            if (main.LoginFormThickness == new Thickness(-700, 0, 0, 0))
            {
                main.LoginFormThickness = new Thickness(-50, 0, 0, 0);

            }
            else
            {
                main.LoginFormThickness = new Thickness(-700, 0, 0, 0);
            }

        }
    }
}
