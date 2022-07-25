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
    /// Interaction logic for fListBook.xaml
    /// </summary>
    public partial class fListBook : Window
    {
        public static string selected_book;
        public class Book
        {
            public string tensach { get; set; }
            public int giaban { get; set; }
            public string loai { get; set; }
            public string masach { get; set; }
        }

        public static List<string> listbooks = new List<string>();

        public int total = 0;
        private static string prime1, prime2, tg = "", nhaxb = "", namxb = "", tl = "", loai = "";

        public static string nv_working;
        public fListBook()
        {
            InitializeComponent();
            List<string> prime = new List<string> { "0đ", "10.000đ", "30.000đ", "50.000đ", "100.000đ", "200.000đ", "500.000đ" };
            min_prime.ItemsSource = prime;
            max_prime.ItemsSource = prime;
            string query_tacgia = "SELECT DISTINCT tenTG FROM TACGIA TG, SACH S WHERE TG.maTG = S.maTG ";
            DataTable dp_tg = DP.Instance.ExecuteQuery(query_tacgia);
            tg_CCB.ItemsSource = dp_tg.DefaultView;
            tg_CCB.DisplayMemberPath = "tenTG";

            string query_NXB = "SELECT DISTINCT tenNXB FROM NXB , SACH S WHERE NXB.maNXB = S.maNXB";
            DataTable dp_NXB = DP.Instance.ExecuteQuery(query_NXB);         
            nxb_CCB.ItemsSource = dp_NXB.DefaultView;
            nxb_CCB.DisplayMemberPath = "tenNXB";

            string query_namXB = "SELECT DISTINCT year(namXB) namXB FROM SACH";
            DataTable dp_namXB = DP.Instance.ExecuteQuery(query_namXB);
            namxb_CCB.ItemsSource = dp_namXB.DefaultView;
            namxb_CCB.DisplayMemberPath = "namXB";

            string query_TL = "SELECT DISTINCT tenTL from THELOAI TL, SACH S WHERE TL.maTL = S.maTL";
            DataTable dp_TL = DP.Instance.ExecuteQuery(query_TL);
            tl_CCB.ItemsSource = dp_TL.DefaultView;
            tl_CCB.DisplayMemberPath = "tenTL";

            if (min_prime.Text == "" || min_prime.Text == "giá min")
            {
                prime1 = "0";
            }
            else
            {
                prime1 = min_prime.Text.Replace(".", "");
                prime1 = prime1.Replace("đ", "");
            }

            if (max_prime.Text == "" || max_prime.Text == "giá max")
            {
                prime2 = "500000";
            }
            else
            {
                prime2 = max_prime.Text.Replace(".", "");
                prime2 = prime2.Replace("đ", "");
            }
        }

        private void bookLV_Loaded(object sender, RoutedEventArgs e)
        {
            string query = "SELECT tensach,giaban,loai, masach FROM SACH";
            DataTable dp = DP.Instance.ExecuteQuery(query);
            var books = new List<Book>();
            foreach (DataRow i in dp.Rows)
            {
                books.Add(new Book() { tensach = i["tensach"].ToString() , giaban=Convert.ToInt32(i["giaban"]), loai=i["loai"].ToString(), masach=i["masach"].ToString() });
            }
            lvBooks.ItemsSource = books;
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            lvBooks.ItemsSource = null;
            string tensach = fLogin.cvt_Str("tensach", search_TB.Text, "and");
           
            if(tg_CCB.Text=="tác giả")
            {
                tg = "";
            }
            else
            {
                string query_tg = "SELECT maTG from TACGIA WHERE tenTG='" + tg_CCB.Text + "'";
                object dp_tg = DP.Instance.ExecuteScalar(query_tg);
                tg = " and maTG='" + dp_tg.ToString() + "'";
            }

            if (nxb_CCB.Text=="Nhà xuất bản")
            {
                nhaxb = "";
            }
            else
            {
                string query_nxb = "SELECT maNXB from NXB WHERE tenNXB='" + nxb_CCB.Text + "'";
                object dp_nxb = DP.Instance.ExecuteScalar(query_nxb);
                nhaxb = " and maNXB='" + dp_nxb.ToString() + "'";
            }

            if (namxb_CCB.Text == "Năm xuất bản")
            {
                namxb = "";
            }
            else
            {
                namxb = " and year(namXB)=" + namxb_CCB.Text; 
            }

            if (S_cu.IsChecked == true)
            {
                loai = "and loai='cu'";
            }

            else if (S_moi.IsChecked == true)
            {
                loai = "and loai='moi'";
            }
            else
            {
                loai = "";
            }

            if (tl_CCB.Text == "Thể loại")
            {
                tl = "";
            }
            else
            {
                string query_tl = "SELECT maTL from THELOAI WHERE tenTL='" + tl_CCB.Text + "'";
                object dp_tl = DP.Instance.ExecuteScalar(query_tl);
                tl = " and maTL='" + dp_tl.ToString() + "'";
            }

            string query = "SELECT * FROM SACH " + 
                            "WHERE tensach like '%" + search_TB.Text.Replace("Tên sản phẩm", "") + "%' and giaban between "  + prime1 + " and "+ prime2 + 
                                     tg + tl + namxb + nhaxb + loai;
            DataTable dp = DP.Instance.ExecuteQuery(query);
            var books = new List<Book>();
            foreach (DataRow i in dp.Rows)
            {
                books.Add(new Book() { tensach = i["tensach"].ToString(), giaban = Convert.ToInt32(i["giaban"]), loai = i["loai"].ToString(), masach = i["masach"].ToString() });
            }
            lvBooks.ItemsSource = books;

        }

        private void detail_Click(object sender, RoutedEventArgs e)
        {
            object select = new Book();
            select = lvBooks.SelectedItem;
            Book selected = (Book)select;

            if (select == null)
            {
                MessageBox.Show("Bạn chưa chọn sách, Vui lòng chọn", "Thông báo");
            }
            else
            {
                selected_book = selected.masach.ToString();
                fDetailBook detail = new fDetailBook();
                detail.Show();
            }
        }

        private void yearAscending_Click(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * FROM SACH " +
                            "WHERE tensach like '%" + search_TB.Text.Replace("Tên sản phẩm", "") + "%' and giaban between " + prime1 + " and " + prime2 +
                                     tg + tl + namxb + nhaxb + loai +
                            " ORDER BY namXB ASC";
            DataTable dp = DP.Instance.ExecuteQuery(query);
            var books = new List<Book>();
            foreach (DataRow i in dp.Rows)
            {
                books.Add(new Book() { tensach = i["tensach"].ToString(), giaban = Convert.ToInt32(i["giaban"]), loai = i["loai"].ToString(), masach = i["masach"].ToString() });
            }
            lvBooks.ItemsSource = books;
        }

        private void yearDecrease_Click(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * FROM SACH " +
                            "WHERE tensach like '%" + search_TB.Text.Replace("Tên sản phẩm", "") + "%' and giaban between " + prime1 + " and " + prime2 +
                                     tg + tl + namxb + nhaxb + loai +
                            " ORDER BY namXB DESC";
            DataTable dp = DP.Instance.ExecuteQuery(query);
            var books = new List<Book>();
            foreach (DataRow i in dp.Rows)
            {
                books.Add(new Book() { tensach = i["tensach"].ToString(), giaban = Convert.ToInt32(i["giaban"]), loai = i["loai"].ToString(), masach = i["masach"].ToString() });
            }
            lvBooks.ItemsSource = books;
        }
        private void addBill_Click(object sender, RoutedEventArgs e)
        {
            object select = new Book();
            select = lvBooks.SelectedItem;
            Book selected = (Book)select;
            int num_book = 0;
            if (select == null)
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm", "Thông báo");
            }
            else
            {
                string query_sl = "SELECT soluong FROM KHO WHERE masach='" + selected.masach.ToString() + "'";
                object sl = DP.Instance.ExecuteScalar(query_sl);
                int cnt = 0;
                for (int i = 0; i < lvBill.Items.Count; i++)
                {
                    object item = new Book();
                    item = lvBill.Items[i];
                    Book bBill = (Book)item;
                    if (bBill.masach == selected.masach.ToString())
                        cnt += 1;    
                }
                if (Convert.ToInt32(sl) == 0)
                {
                    MessageBox.Show("Sản phẩm đã hết hàng, Bạn có muốn kiểm trả kho", "Thông báo");
                    fStorage storage = new fStorage();
                    storage.Show();
                    Close();
                }
                else if(Convert.ToInt32(sl) == cnt)
                {
                    MessageBox.Show("Sản phẩm đã hết. Vui lòng chọn sản phẩm khác", "Thông báo");
                }
                else
                {
                    string query = "SELECT tensach,giaban,loai, masach FROM SACH WHERE masach='" + selected.masach.ToString() + "'";
                    DataTable dp = DP.Instance.ExecuteQuery(query);
                    var books = new List<Book>();
                    for (int i = 0; i < lvBill.Items.Count; i++)
                    {
                        object book = new Book();
                        book = lvBill.Items[i];
                        Book b = (Book)book;
                        books.Add(b);
                    }
                    foreach (DataRow i in dp.Rows)
                    {
                        books.Add(new Book() { tensach = i["tensach"].ToString(), giaban = Convert.ToInt32(i["giaban"]), loai = i["loai"].ToString(), masach = i["masach"].ToString() });
                        total += Convert.ToInt32(i["giaban"]);
                        total_LB.Content = total.ToString() + " VNĐ";
                    }
                    lvBill.ItemsSource = books;
                }
            }
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            
            if (lvBill.Items.Count == 0)
            {
                MessageBox.Show("Danh sách mua hàng trống", "Thông báo");
            }
            else
            {
                for (int i = 0; i < lvBill.Items.Count; i++)
                {
                    object book = new Book();
                    book = lvBill.Items[i];
                    Book b = (Book)book;
                    listbooks.Add(b.masach.ToString());
                }
                string query = "SELECT manv from NHANVIEN WHERE username='" + fLogin.setvalue_username + "'";
                object dp = DP.Instance.ExecuteScalar(query);
                nv_working = dp.ToString();
                fCreateBill create = new fCreateBill();
                create.Show();
                Close();
            }
        }

        private void storage_Click(object sender, RoutedEventArgs e)
        {
            fStorage s = new fStorage();
            s.Show();
            Close();
        }

        private void hot_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> ms = new List<string>();
            List<int> gia = new List<int>();
            string query = "SELECT TOP(3)masach, count(masach) FROM CTHD group by masach order by count(masach) DESC";
            DataTable dp = DP.Instance.ExecuteQuery(query);
            foreach(DataRow i in dp.Rows)
            {
                ms.Add(i["masach"].ToString());
            }
            for (int i = 0; i < ms.Count; i++)
            {
                string query_price = "SELECT giaban FROM SACH WHERE masach='" + ms[i] + "'";
                object price = DP.Instance.ExecuteScalar(query_price);
                gia.Add(Convert.ToInt32(price));
            }

            String top1 = ms[0].Replace(" ", "") + ".png";
            Uri imageUri = new Uri(top1, UriKind.Relative);
            BitmapImage imageBitmap = new BitmapImage(imageUri);
            Image myImage = new Image();
            top1_Image.Source = imageBitmap;
            top1_LB.Content = gia[0];

            String top2 = ms[1].Replace(" ", "") + ".png";
            imageUri = new Uri(top2, UriKind.Relative);
            imageBitmap = new BitmapImage(imageUri);
            myImage = new Image();
            top2_Image.Source = imageBitmap;
            top2_LB.Content = gia[1];

            String top3 = ms[2].Replace(" ", "") + ".png";
            imageUri = new Uri(top3, UriKind.Relative);
            imageBitmap = new BitmapImage(imageUri);
            myImage = new Image();
            top3_Image.Source = imageBitmap;
            top3_LB.Content = gia[2];

        }
        private void new_Loaded(object sender, RoutedEventArgs e)
        {
            string new_book = "SELECT masach, giaban FROM SACH where masach = 'ms" + (Convert.ToInt32(DP.Instance.ExecuteScalar("SELECT COUNT(masach) FROM SACH")) - 1).ToString() + "'";
            DataTable dp = DP.Instance.ExecuteQuery(new_book);
            String path_img = "";
            int gia = 0;
            foreach (DataRow i in dp.Rows)
            {
                path_img = i["masach"].ToString().Replace(" ", "") + ".png";              
                new_LB.Content = i["giaban"].ToString();
            }
            Uri imageUri = new Uri(path_img, UriKind.Relative);
            BitmapImage imageBitmap = new BitmapImage(imageUri);
            Image myImage = new Image();
            new_Image.Source = imageBitmap;
        }

        private void searchTB_Leave(object sender, MouseEventArgs e)
        {
            if (search_TB.Text == "")
            {
                search_TB.Text = "Tên sản phẩm";
                search_TB.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void searchTB_Enter(object sender, MouseEventArgs e)
        {
            if (search_TB.Text == "Tên sản phẩm")
            {
                search_TB.Text = "";
                search_TB.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainUI main = new MainUI();
            main.Show();
            Close();
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            S_cu.IsChecked = false;
            S_moi.IsChecked = false;
            search_TB.Text = "Tên sản phẩm";
            search_TB.Foreground = new SolidColorBrush(Colors.Gray);
            min_prime.Text = "giá min";
            max_prime.Text = "giá max";
            tl_CCB.Text = "Thể loại";
            namxb_CCB.Text = "Năm xuất bản";
            nxb_CCB.Text = "Nhà xuất bản";
            tg_CCB.Text = "tác giả";

            string query = "SELECT tensach,giaban,loai, masach FROM SACH";
            DataTable dp = DP.Instance.ExecuteQuery(query);
            var books = new List<Book>();
            foreach (DataRow i in dp.Rows)
            {
                books.Add(new Book() { tensach = i["tensach"].ToString(), giaban = Convert.ToInt32(i["giaban"]), loai = i["loai"].ToString(), masach = i["masach"].ToString() });
            }
            lvBooks.ItemsSource = books;
        }

        private void primeAscending_Click(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * FROM SACH " +
                            "WHERE tensach like '%" + search_TB.Text.Replace("Tên sản phẩm", "") + "%' and giaban between " + prime1 + " and " + prime2 +
                                     tg + tl + namxb + nhaxb + loai +
                            " ORDER BY giaban ASC";
            DataTable dp = DP.Instance.ExecuteQuery(query);
            var books = new List<Book>();
            foreach (DataRow i in dp.Rows)
            {
                books.Add(new Book() { tensach = i["tensach"].ToString(), giaban = Convert.ToInt32(i["giaban"]), loai = i["loai"].ToString(), masach = i["masach"].ToString() });
            }
            lvBooks.ItemsSource = books;

        }

        private void primeDecrease_Click(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * FROM SACH " +
                            "WHERE tensach like '%" + search_TB.Text.Replace("Tên sản phẩm", "") + "%' and giaban between " + prime1 + " and " + prime2 +
                                     tg + tl + namxb + nhaxb + loai +
                            " ORDER BY giaban DESC";
            DataTable dp = DP.Instance.ExecuteQuery(query);
            var books = new List<Book>();
            foreach (DataRow i in dp.Rows)
            {
                books.Add(new Book() { tensach = i["tensach"].ToString(), giaban = Convert.ToInt32(i["giaban"]), loai = i["loai"].ToString(), masach = i["masach"].ToString() });
            }
            lvBooks.ItemsSource = books;
        }
    }
}
