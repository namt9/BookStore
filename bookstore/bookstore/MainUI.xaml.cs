using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace bookstore
{
    /// <summary>
    /// Interaction logic for MainUI.xaml
    /// </summary>
    public partial class MainUI : Window
    {
        public MainUI()
        {
            InitializeComponent();
        }


        private void listproductsImage_MLBU(object sender, MouseButtonEventArgs e)
        {
            
        }
        private void listproductsImage_ME(object sender, MouseEventArgs e)
        {
            listproductsImage.Height = 155;
            listproductsImage.Width = 185;
        }
        private void listproductsImage_ML(object sender, MouseEventArgs e)
        {
            listproductsImage.Height = 150;
            listproductsImage.Width = 180;
        }
        private void logout_MLBU(object sender, MouseButtonEventArgs e)
        {
            fLogin login = new fLogin();
            login.Show();
            Close();
        }
        private void logout_ME(object sender, MouseEventArgs e)
        {
            logout.Height = 155;
            logout.Width = 185;
        }
        private void logout_ML(object sender, MouseEventArgs e)
        {
            logout.Height = 150;
            logout.Width = 180;
        }
        private void infouserImage_MLBU(object sender, MouseButtonEventArgs e)
        {
            if (fLogin.setvalue_username == "admin")
            {
                fInfoAdmin info = new fInfoAdmin();
                info.Show();
                Close();
            }
            else
            {
                fInfo info = new fInfo();
                info.Show();
                Close();
            }
        }

        private void infouserImage_ME(object sender, MouseEventArgs e)
        {
            infouserImage.Height = 155;
            infouserImage.Width = 185;
        }

        private void infouserImage_ML(object sender, MouseEventArgs e)
        {
            infouserImage.Height = 150;
            infouserImage.Width = 180;
        }
    }
}
