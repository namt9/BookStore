using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    /// Interaction logic for fCreateBill.xaml
    /// </summary>
    public partial class fCreateBill : Window
    {
        public class CTHD
        {
            public string tensach { get; set; }

            public int soluong { get; set; }

            public int dongia { get; set; }
            public int thanhtien { get; set; }
        }

        public static int total { get; set; }
        public static int sl_VC { get; set; }
        public fCreateBill()
        {
            InitializeComponent();
        }

        private void dsKH_Loaded(object sender, RoutedEventArgs e)
        {
            string query = "select tenKH from KHACHHANG";
            DataTable dp = DP.Instance.ExecuteQuery(query);
            dsKH_CBB.ItemsSource = dp.DefaultView;
            dsKH_CBB.DisplayMemberPath = "tenKH";
        }

        private void searchInfo_Click(object sender, RoutedEventArgs e)
        {
            string gt = "";
            string query = "SELECT *FROM KHACHHANG WHERE tenKH = '" + dsKH_CBB.Text + "'";
            DataTable dp = DP.Instance.ExecuteQuery(query);
            foreach (DataRow i in dp.Rows)
            {
                tenKH_TB.Text = i["tenKH"].ToString();
                gt = i["gioitinh"].ToString();
                emailKH_TB.Text = i["email"].ToString();
                dcKH_TB.Text = i["diachi"].ToString();
                sdtKH_TB.Text = i["sdt"].ToString();
            }

            if (gt.Replace(" ", "") == "nam")
            {
                GTnam_RB.IsChecked = true;
            }
            else if (gt.Replace(" ", "") == "nu")
            {
                GTnu_RB.IsChecked = true;
            }
        }
        private int count(string a, List<string> arr)
        {
            int cnt = 0;
            for(int i=0;i<arr.Count;i++)
            {
                if (arr[i] == a)
                {
                    cnt += 1;
                }    
            }    
            return cnt;
        }
        private void dsBook_Loaded(object sender, RoutedEventArgs e)
        {
            total = 0;
            List<string> listbooks = fListBook.listbooks;
            var temp = listbooks.Distinct();
            List<string> ds = temp.ToList<string>();
            var ct = new List<CTHD>();
            List<int> cnt = new List<int>();
            for(int i = 0; i < ds.Count; i++)
            {
                cnt.Add(count(ds[i], listbooks));
                string query = "SELECT tensach, giaban FROM SACH WHERE masach='" + ds[i] + "'";
                DataTable dp = DP.Instance.ExecuteQuery(query);
                foreach(DataRow j in dp.Rows)
                {
                    ct.Add(new CTHD() { tensach = j["tensach"].ToString(), soluong = count(ds[i], listbooks), dongia = Convert.ToInt32(j["giaban"]), thanhtien = count(ds[i], listbooks)* Convert.ToInt32(j["giaban"]) }) ;
                    total += count(ds[i], listbooks) * Convert.ToInt32(j["giaban"]);
                }
            }
            lvBill.ItemsSource = ct;
            totalMoney_LB.Content = total.ToString() + " VNĐ";
            discount_LB.Content = 0.ToString() + " VNĐ";
            lastPrice_LB.Content = total.ToString() + " VNĐ";
        }

        private void applyVC_Click(object sender, RoutedEventArgs e)
        {
            double discount = 0;
            if (vc_TB == null)
            {
                discount_LB.Content = 0.ToString() + " VNĐ";
                lastPrice_LB.Content = total.ToString() + " VNĐ";
            }    
            else
            {
                string query_VC = "SELECT maVC FROM VOUCHER WHERE maVC='" + vc_TB.Text + "'";
                object dp_VC = DP.Instance.ExecuteScalar(query_VC);
                if (dp_VC == null)
                {
                    MessageBox.Show("Mã giảm giá không đúng, Bạn sẽ không được giảm giá", "Thông báo");
                    discount_LB.Content = 0.ToString() + " VNĐ";
                    lastPrice_LB.Content = total.ToString() + " VNĐ";
                }    
                else
                {
                    string query_sl = "SELECT soluong FROM VOUCHER WHERE maVC='" + vc_TB.Text + "'";
                    sl_VC = Convert.ToInt32(DP.Instance.ExecuteScalar(query_sl));
                    discount = Convert.ToDouble(DP.Instance.ExecuteScalar("SELECT trigia FROM VOUCHER WHERE maVC='" + vc_TB.Text + "'"));
                    discount_LB.Content = (total * discount).ToString() + " VNĐ";
                    lastPrice_LB.Content = (total - total * discount).ToString() + " VNĐ";
                }    

            }
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            if (tenKH_TB.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên khách hàng", "Thông báo");
            }
            else
            {
                if (dsKH_CBB.Text == "")
                {
                    string gt = "";
                    if (GTnam_RB.IsChecked == true)
                    {
                        gt = "nam";
                    }
                    else if (GTnu_RB.IsChecked == true)
                        gt = "nu";

                    string query = "INSERT INTO KHACHHANG values('kh" + DP.Instance.ExecuteScalar("SELECT COUNT(maKH) from KHACHHANG").ToString() + "', '" +
                                                                tenKH_TB.Text + "', '" + gt + "', '" + dcKH_TB.Text + "', '" + emailKH_TB.Text + "', '" + sdtKH_TB.Text + "')";
                    DP.Instance.ExecuteQuery(query);

                }

                string query_VC = "SELECT maVC FROM VOUCHER WHERE maVC='" + vc_TB.Text + "'";
                object dp_VC = DP.Instance.ExecuteScalar(query_VC);



                string maHD = DP.Instance.ExecuteScalar("SELECT COUNT(maKH) from HOADON").ToString();
                string maKH = DP.Instance.ExecuteScalar("SELECT maKH FROM KHACHHANG WHERE tenKH ='" + tenKH_TB.Text + "'").ToString();
                string maNV = DP.Instance.ExecuteScalar("SELECT maNV FROM NHANVIEN WHERE username='" + fLogin.setvalue_username + "'").ToString();
                string query_HD = "INSERT INTO HOADON values ('hd" + maHD + "', '" + maKH + "', '" + maNV + "', '" + vc_TB.Text + "', '" + DateTime.Now.ToString().Replace("PM", "") + "', '" + lastPrice_LB.Content.ToString().Replace(" VNĐ", "") + "')";
                DP.Instance.ExecuteQuery(query_HD);

                List<string> listbooks = fListBook.listbooks;
                var temp = listbooks.Distinct();
                List<string> ds = temp.ToList<string>();

                for (int i = 0; i < lvBill.Items.Count; i++)
                {
                    object cthd = new CTHD();
                    cthd = lvBill.Items[i];
                    CTHD a = (CTHD)cthd;

                    string query_CTHD = "INSERT INTO CTHD values ('hd" + maHD + "', '" + ds[i] + "', " + a.soluong + ", " + a.dongia + ")";
                    DP.Instance.ExecuteQuery(query_CTHD);

                    string query_sl = "SELECT soluong from KHO WHERE masach='" + ds[i] + "'";
                    object sl_book = DP.Instance.ExecuteScalar(query_sl);
                    string query_updateStorage = "UPDATE KHO SET soluong = " + (Convert.ToInt32(sl_book) - a.soluong).ToString() + "WHERE masach='" + ds[i] + "'";
                    DP.Instance.ExecuteQuery(query_updateStorage);
                }

                sl_VC = Convert.ToInt32(DP.Instance.ExecuteScalar("SELECT soluong from VOUCHER WHERE maVC='" + vc_TB.Text + "'"));
                DP.Instance.ExecuteQuery("UPDATE VOUCHER SET soluong='" + (sl_VC - 1).ToString() + "' WHERE maVC='" + vc_TB.Text + "'");
                MessageBox.Show("Thành công", "Thông báo");
                fListBook listb = new fListBook();
                listb.Show();
                Close();
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            fListBook listb = new fListBook();
            listb.Show();
            Close();
        }
    }
}
