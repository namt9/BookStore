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
    /// Interaction logic for fDetailBill.xaml
    /// </summary>
    public partial class fDetailBill : Window
    {
        public fDetailBill()
        {
            InitializeComponent();
        }
        public static int total_price = 0;
        private void books_Loaded(object sender, RoutedEventArgs e)
        {
            string selected = "";
            if(fLogin.setvalue_username == "admin")
            {
                selected = fStatisticAdmin.selected_bill_admin;
            }
            else
            {
                selected = fStatistic.selected_bill;
            }    
            var books= new List<fCreateBill.CTHD>();
            string query = "SELECT tensach, soluong, dongia FROM CTHD, SACH S WHERE CTHD.masach = S.masach and maHD = '" + selected + "'";
            DataTable dp = DP.Instance.ExecuteQuery(query);
            foreach(DataRow i in dp.Rows)
            {
                books.Add(new fCreateBill.CTHD() { tensach = i["tensach"].ToString(), soluong = Convert.ToInt32(i["soluong"]), dongia = Convert.ToInt32(i["dongia"]), thanhtien = Convert.ToInt32(i["soluong"]) * Convert.ToInt32(i["dongia"]) });
                total_price += Convert.ToInt32(i["soluong"]) * Convert.ToInt32(i["dongia"]);
            }
            books_LV.ItemsSource = books;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            if(fLogin.setvalue_username == "admin")
            {
                fStatisticAdmin statistic_admin = new fStatisticAdmin();
                statistic_admin.Show();
            }
            else
            {
                fStatistic statistic = new fStatistic();
                statistic.Show();
            }         
            Close();
        }

        private void price_Loaded(object sender, RoutedEventArgs e)
        {
            double voucher = 0;
            if (fLogin.setvalue_username == "admin")
            {
                voucher = fStatisticAdmin.voucher_value_admin;
            }
            else
            {
                voucher = fStatistic.voucher_value;
            }
            total_LB.Content = total_price;
            discount_LB.Content = total_price * voucher;
            lastPrice_LB.Content = total_price - total_price * voucher;
        }
    }
}
