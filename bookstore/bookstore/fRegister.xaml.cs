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
    /// Interaction logic for fRegister.xaml
    /// </summary>
    public partial class fRegister : Window
    {
        public fRegister()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            string query1 = "SELECT COUNT(manv) FROM NHANVIEN WHERE manv != 'admin'";
            object dt1 = DP.Instance.ExecuteScalar(query1);
            string MaKH = "nv" + dt1;
            string ten = HoTen_txt.Text.ToString();
            string ngaysinh = NgSinh_DataPicker.DisplayDate.ToString();
            string sdt = SoDT_txt.Text.ToString();
            string email = Email_txt.Text.ToString();
            string gioitinh;
            if (GT_Nam.IsChecked == true)
            {
                gioitinh = GT_Nam.Content.ToString();
            }    
            else
            {
                gioitinh = GT_Nu.Content.ToString();
            }
            string dc = Dc_txt.Text.ToString();
            string username = un_txt.Text.ToString();
            string pw = pw_txt.Password.ToString();
            string rpw = rpw_txt.Password.ToString();

            string query_check_username = "SELECT COUNT(username) FROM NHANVIEN WHERE username = '" + username + "'";
            object check_username = DP.Instance.ExecuteScalar(query_check_username);
            if (sdt == "" || username == "" || pw == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc (Họ và tên, số điện thoại, username, mật khẩu)", "Failed");
            }    
            else if (Convert.ToInt32(check_username) != 0)
            {
                MessageBox.Show("Username đã tồn tại, vui lòng nhập lại !", "Failed");
            }   
            
            else if (pw != rpw)
            {
                MessageBox.Show("Mật khẩu không giống nhau, vui lòng nhập lại", "Failed");
            }    

            else
            {
                string query_adduser = " INSERT INTO TAIKHOAN(username, password)"
                                        + " VALUES('" + username + "' ,'" + pw + "')"
                                        + "INSERT INTO NHANVIEN(manv, tennv, gioitinh, ngaysinh, diachi, email, sdt, username)"
                                        + " VALUES('" + MaKH + "', '" + ten + "', '" + gioitinh + "', '" + ngaysinh + "', '" + dc + "', '" + email + "', '" + Convert.ToInt32(sdt) + "' ,'" + username + "')";

                object add = DP.Instance.ExecuteQuery(query_adduser);
                MessageBox.Show("Đăng kí thành công", "Successfully");
                fLogin login = new fLogin();
                login.Show();
                Close();
            } 
            
        }
    }
}
