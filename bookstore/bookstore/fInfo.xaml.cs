using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for fInfo.xaml
    /// </summary>
    public partial class fInfo : Window
    {
        public class NV
        {
            public string manv { get; set; }
            public string tennv { get; set; }
            public string gioitinh { get; set; }

            public string diachi { get; set; }
            public string ngaysinh { get; set; } 
            public string username { get; set; }
            public string sdt { get; set; }
            public string email { get; set; }
        }
        public static NV nv = new NV();

        public fInfo()
        {
            InitializeComponent();
            string query = "SELECT * FROM NHANVIEN WHERE username = '" + fLogin.setvalue_username + "'";
            DataTable dp = DP.Instance.ExecuteQuery(query);
            foreach (DataRow i in dp.Rows)
            {
                nv.tennv = i["tennv"].ToString();
                nv.gioitinh = i["gioitinh"].ToString();
                nv.ngaysinh = i["ngaysinh"].ToString();
                nv.sdt = i["sdt"].ToString();
                nv.username = i["username"].ToString();
                nv.email = i["email"].ToString();
                nv.diachi = i["diachi"].ToString();
            }
            DataContext = nv;
        }

        private void changepw_Button(object sender, RoutedEventArgs e)
        {
            fCheckCode checkcode = new fCheckCode();
            checkcode.Show();
            Close();
        }

        private void update_Button(object sender, RoutedEventArgs e)
        {
            fUpdateInfo update = new fUpdateInfo();
            update.Show();
            Close();
        }
    }
}
