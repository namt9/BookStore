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
        public fListBook()
        {
            InitializeComponent();
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

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            //lvBooks.ItemsSource = null;
            object select = new Book();
            select = lvBooks.SelectedItem;
            Book selected = (Book)select;
            string query = "SELECT * FROM SACH WHERE masach='" + selected.masach + "'";
        }

        private void detail_Click(object sender, RoutedEventArgs e)
        {
            object select = new Book();
            select = lvBooks.SelectedItem;
            Book selected = (Book)select;
            selected_book = selected.masach.ToString();
            fDetailBook detail = new fDetailBook();
            detail.Show();
        }
    }
}
