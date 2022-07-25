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
    /// Interaction logic for fStorage.xaml
    /// </summary>
    public partial class fStorage : Window
    {
        public fStorage()
        {
            InitializeComponent();
        }

        public class Storage
        {
            public string masach { get; set; }
            public string tensach { get; set; }
            public int soluong { get; set; }
        }

        private void storage_LV(object sender, RoutedEventArgs e)
        {
            List <Storage> storage = new List<Storage>();
            string query = "SELECT K.masach, tensach, soluong FROM KHO K, SACH S WHERE K.masach = S.masach";

            DataTable dp = DP.Instance.ExecuteQuery(query);

            foreach(DataRow i in dp.Rows)
            {
                storage.Add(new Storage() { masach = i["masach"].ToString(), tensach = i["tensach"].ToString(), soluong = Convert.ToInt32(i["soluong"]) });
            }

            lvStorage.ItemsSource = storage;
        }

        private void augment_Click(object sender, RoutedEventArgs e)
        {
            object select = new Storage();
            select = lvStorage.SelectedItem;
            Storage selected = (Storage)select;

            if (select == null)
            {
                MessageBox.Show("Bạn chưa chọn sách, Vui lòng chọn", "Thông báo");
            }
            else
            {
                string query_update = "UPDATE KHO SET soluong=" + (selected.soluong + 1).ToString() + "WHERE masach = '" + selected.masach + "'";
                DP.Instance.ExecuteQuery(query_update);

                List<Storage> storage = new List<Storage>();
                string query = "SELECT K.masach, tensach, soluong FROM KHO K, SACH S WHERE K.masach = S.masach";

                DataTable dp = DP.Instance.ExecuteQuery(query);

                foreach (DataRow i in dp.Rows)
                {
                    storage.Add(new Storage() { masach = i["masach"].ToString(), tensach = i["tensach"].ToString(), soluong = Convert.ToInt32(i["soluong"]) });
                }

                lvStorage.ItemsSource = storage;
            }
        }

        private void reduce_Click(object sender, RoutedEventArgs e)
        {
            object select = new Storage();
            select = lvStorage.SelectedItem;
            Storage selected = (Storage)select;

            if (select == null)
            {
                MessageBox.Show("Bạn chưa chọn sách, Vui lòng chọn", "Thông báo");
            }
            else
            {
                string query_update = "UPDATE KHO SET soluong=" + (selected.soluong - 1).ToString() + "WHERE masach = '" + selected.masach + "'";
                DP.Instance.ExecuteQuery(query_update);

                List<Storage> storage = new List<Storage>();
                string query = "SELECT K.masach, tensach, soluong FROM KHO K, SACH S WHERE K.masach = S.masach";

                DataTable dp = DP.Instance.ExecuteQuery(query);

                foreach (DataRow i in dp.Rows)
                {
                    storage.Add(new Storage() { masach = i["masach"].ToString(), tensach = i["tensach"].ToString(), soluong = Convert.ToInt32(i["soluong"]) });
                }

                lvStorage.ItemsSource = storage;
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
