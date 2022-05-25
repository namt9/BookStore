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
    /// Interaction logic for fInfoAdmin.xaml
    /// </summary>
    public partial class fInfoAdmin : Window
    {
        public static fInfo.NV nv = new fInfo.NV();
        public fInfoAdmin()
        {
            InitializeComponent();
        }

        private void KT_Click(object sender, RoutedEventArgs e)
        {
            string query1 = "SELECT * FROM NHANVIEN WHERE tennv = '" + nv_CBB.Text + "'";
            DataTable dp = DP.Instance.ExecuteQuery(query1);
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
            tennv_Label.Content = nv.tennv;
            ns_Label.Content = nv.ngaysinh;
            gioitinh_Label.Content = nv.gioitinh;
            sdt_Label.Content = nv.sdt;
            email_Label.Content = nv.email;
            username_Label.Content = nv.username;
            diachi_Label.Content = nv.diachi;
            //DataContext = nv;
        }
        private void update_Button(object sender, RoutedEventArgs e)
        {
            fUpdateInfo update = new fUpdateInfo();
            update.Show();
            Close();
        }

        private void add_Button(object sender, RoutedEventArgs e)
        {
            fRegister register = new fRegister();
            register.Show();
            Close();
        }

        private void nvCBB_Loaded(object sender, RoutedEventArgs e)
        {
            string query = "select tennv from NHANVIEN";
            DataTable dp = DP.Instance.ExecuteQuery(query);
            nv_CBB.ItemsSource = dp.DefaultView;
            nv_CBB.DisplayMemberPath = "tennv";
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainUI main = new MainUI();
            main.Show();
            Close();
        }
    }
}
