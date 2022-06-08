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
using System.Data.SqlClient;
using System.Data;

namespace bookstore
{
    /// <summary>
    /// Interaction logic for fLogin.xaml
    /// </summary>
    public partial class fLogin : Window
    {
        public static string setvalue_username;
        public static string username_logged;
        public fLogin()
        {
            InitializeComponent();
        }

        public static string cvt_Str (string a, string b, string c)
        {
            if (b == "")
            {
                return "";
            }
            else
            {
                return a + "='" + b +"' " + c;
            }
        }

        private void Login_click(object sender, RoutedEventArgs e)
        {
  
            string query = "SELECT COUNT(1) from TaiKhoan WHERE username='" + txtusername.Text.ToString() + "' AND password='" + txtpassword.Password.ToString() + "'";
            object dt = DP.Instance.ExecuteScalar(query);
            if (Convert.ToInt32(dt) > 0)
            {
                setvalue_username = txtusername.Text;
                MainUI main = new MainUI();
                main.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai", "Login failed");
            }    

        }


        private void txtusername_MouseEnter(object sender, MouseEventArgs e)
        {
            if (txtusername.Text == "Username")
            {
                txtusername.Text = "";
                txtusername.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void txtusername_MouseLeave(object sender, MouseEventArgs e)
        {
            if(txtusername.Text == "")
            {
                txtusername.Text = "Username";
                txtusername.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void txtpassword_MouseEnter(object sender, MouseEventArgs e)
        {
            if (txtpassword.Password == "Password")
            {
                txtpassword.Password = "";
                txtpassword.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void txtpassword_MouseLeave(object sender, MouseEventArgs e)
        {
            if (txtpassword.Password == "")
            {
                txtpassword.Password = "Password";
                txtpassword.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void forgot_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            setvalue_username = txtusername.Text ;
            string query = "SELECT count(1) FROM TAIKHOAN WHERE username = '" + txtusername.Text.ToString() + "'";
            object dp = DP.Instance.ExecuteScalar(query);
            if (Convert.ToInt32(dp) == 1)
            {
                fCheckCode checkCode = new fCheckCode();
                checkCode.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập trống hoặc không tồn tại", "Failed");
            }
        }

        private void forgotpw_ME(object sender, MouseEventArgs e)
        {
            forgotpw_Label.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void forgotpw_ML(object sender, MouseEventArgs e)
        {
            forgotpw_Label.Foreground = new SolidColorBrush(Colors.Gray);
        }
    }
}
