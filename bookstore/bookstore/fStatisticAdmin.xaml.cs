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
    /// Interaction logic for fStatisticAdmin.xaml
    /// </summary>
    public partial class fStatisticAdmin : Window
    {
        public fStatisticAdmin()
        {
            InitializeComponent();
        }

        public static string selected_bill_admin { get; set; }
        public static double voucher_value_admin { get; set; }
        private void employees_Loaded(object sender, RoutedEventArgs e)
        {
            string query = "select tennv from NHANVIEN WHERE manv!='admin'";
            DataTable dp = DP.Instance.ExecuteQuery(query);
            employees_CCB.ItemsSource = dp.DefaultView;
            employees_CCB.DisplayMemberPath = "tennv";
        }

        private void detail_Click(object sender, RoutedEventArgs e)
        {
            object select = new fStatistic.HOADON();
            select = bills_LV.SelectedItem;
            fStatistic.HOADON selected = (fStatistic.HOADON)select;
            selected_bill_admin = selected.maHD;
            voucher_value_admin = Convert.ToDouble(selected.giamgia.Replace("%", "")) / 100;
            fDetailBill bill = new fDetailBill();
            bill.Show();
            Close();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainUI main = new MainUI();
            main.Show();
            Close();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            string maNV = DP.Instance.ExecuteScalar("SELECT maNV FROM NHANVIEN WHERE tennv='" + employees_CCB.Text + "'").ToString();
            var bills = new List<fStatistic.HOADON>();


            string query = "SELECT HD.maHD, tenKH, ngaylap, thanhtien, trigia FROM HOADON HD, KHACHHANG KH, VOUCHER VC WHERE VC.maVC = HD.maVC and HD.maKH = KH.maKH and maNV='" + maNV + "'";
            DataTable dp = DP.Instance.ExecuteQuery(query);
            foreach (DataRow i in dp.Rows)
            {
                bills.Add(new fStatistic.HOADON() { maHD = i["maHD"].ToString(), tenKH = i["tenKH"].ToString(), ngaylap = i["ngaylap"].ToString(), thanhtien = Convert.ToInt32(i["thanhtien"]), giamgia = (Convert.ToDouble(i["trigia"]) * 100).ToString() + "%" });
            }

            bills_LV.ItemsSource = bills;
        }
    }
}
