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
    /// Interaction logic for fChangePw.xaml
    /// </summary>
    public partial class fChangePw : Window
    {
        public fChangePw()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {    
            string query = "UPDATE TAIKHOAN SET password = '" + password_txt.Password.ToString() + "' WHERE username = '" + fLogin.setvalue_username + "'";
            if (password_txt.Password.ToString() != rpassword_txt.Password.ToString())
            {
                MessageBox.Show("Mật khẩu không trùng khớp", "Failed");
            }
            else
            {
                object dt = DP.Instance.ExecuteQuery(query);
                MessageBox.Show("Đổi mật khẩu thành công", "Succesfully");
                fLogin login = new fLogin();
                login.Show();
                Close();
            }    
                
        }
    }
}
