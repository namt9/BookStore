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
    /// Interaction logic for fUpdateInfo.xaml
    /// </summary>
    /// 
    public partial class fUpdateInfo : Window
    {
        public fUpdateInfo()
        {
            InitializeComponent();
            set_Info();
        }
        private void set_Info()
        {
            if (fLogin.setvalue_username == "admin")
            {
                ten_Label.Content = fInfoAdmin.nv.tennv;
                ten_TB.Text = fInfoAdmin.nv.tennv;
                ns_DateP.Text = fInfoAdmin.nv.ngaysinh;
                email_TB.Text = fInfoAdmin.nv.email;
                dc_TB.Text = fInfoAdmin.nv.diachi;
                sdt_TB.Text = fInfoAdmin.nv.sdt;
                gt_TB.Text = fInfoAdmin.nv.gioitinh;
                username_Label.Content = fInfoAdmin.nv.username;
            }
            else
            {
                ten_Label.Content = fInfo.nv.tennv;
                ten_TB.Text = fInfo.nv.tennv;
                ns_DateP.Text = fInfo.nv.ngaysinh;
                email_TB.Text = fInfo.nv.email;
                dc_TB.Text = fInfo.nv.diachi;
                sdt_TB.Text = fInfo.nv.sdt;
                gt_TB.Text = fInfo.nv.gioitinh;
                username_Label.Content = fInfo.nv.username;
            }
        }
        private string check_str(String a, String b )
        {
            if (b == "")
            {
                return "";
            }
            return a + "='" + b + "'";
           
        }
        private void save_Button(object sender, RoutedEventArgs e)
        {
         
            string query = "UPDATE NHANVIEN " +

                           "SET tennv ='"+ten_TB.Text.ToString() +"', ngaysinh='" + ns_DateP.Text.ToString()+
                           "', diachi='" + dc_TB.Text.ToString() + "', sdt='" + sdt_TB.Text.ToString() +
                           "', gioitinh='" + gt_TB.Text.ToString() +  "', email='" + email_TB.Text.ToString() + "' " +

                           "WHERE username='" + username_Label.Content.ToString() +"'" ;
            object update = DP.Instance.ExecuteQuery(query);
            MessageBox.Show("Đã lưu thành công", "Succesfully");
            if (fLogin.setvalue_username != "admin")
            {
                fInfo info = new fInfo();
                info.Show();
            }
            else
            {
                fInfoAdmin info = new fInfoAdmin();
                info.Show();
            }
            Close();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            if (fLogin.setvalue_username == "admin")
            {
                fInfoAdmin info = new fInfoAdmin();
                info.Show();
            }
            else
            {
                fInfo info = new fInfo();
                info.Show();
            }
            Close();
        }
    }
}
