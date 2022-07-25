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
    /// Interaction logic for fStatistic.xaml
    /// </summary>
    public partial class fStatistic : Window
    {
        public class HOADON
        {
            public string maHD { get; set; }
            public string tenKH { get; set; }
            public string ngaylap { get; set; }
            public string giamgia { get; set; }
            public int thanhtien { get; set; }
        }

        public static string selected_bill { get; set;   }
        public static double voucher_value { get; set; }
        public fStatistic()
        {
            InitializeComponent();
        }

        private void bills_Loaded(object sender, RoutedEventArgs e)
        {
            string maNV = DP.Instance.ExecuteScalar("SELECT maNV FROM NHANVIEN WHERE username='" + fLogin.setvalue_username + "'").ToString();
            var bills = new List<HOADON>();


            string query = "SELECT HD.maHD, tenKH, ngaylap, thanhtien, trigia FROM HOADON HD, KHACHHANG KH, VOUCHER VC WHERE VC.maVC = HD.maVC and HD.maKH = KH.maKH and maNV='" + maNV + "'";
            DataTable dp = DP.Instance.ExecuteQuery(query);
            foreach(DataRow i in dp.Rows)
            {
                bills.Add(new HOADON() { maHD = i["maHD"].ToString(), tenKH = i["tenKH"].ToString(), ngaylap = i["ngaylap"].ToString(), thanhtien = Convert.ToInt32(i["thanhtien"]), giamgia = (Convert.ToDouble(i["trigia"]) * 100).ToString()+"%"  });
            }

            bills_LV.ItemsSource = bills;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainUI main = new MainUI();
            main.Show();
            Close();
        }

        private void detail_Click(object sender, RoutedEventArgs e)
        {
            object select = new HOADON();
            select = bills_LV.SelectedItem;
            HOADON selected = (HOADON)select;
            selected_bill = selected.maHD;
            voucher_value = Convert.ToDouble(selected.giamgia.Replace("%",""))/100;
            fDetailBill bill = new fDetailBill();
            bill.Show();
            Close();
        }
    }
}
