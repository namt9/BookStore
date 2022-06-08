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
    /// Interaction logic for fDetailBook.xaml
    /// </summary>
    public partial class fDetailBook : Window
    {
        public fDetailBook()
        {
            InitializeComponent();
            String stringPath = fListBook.selected_book.Replace(" ", "") + ".png";
            Uri imageUri = new Uri(stringPath, UriKind.Relative);
            BitmapImage imageBitmap = new BitmapImage(imageUri);
            Image myImage = new Image();
            imageBook.Source = imageBitmap;
            string query = "select tensach, tenTL, tenTG, year(namXB) as namXB, tenNXB, giaban, K.soluong from SACH S, THELOAI TL, TACGIA tg, NXB, KHO K" +
                            " where NXB.maNXB = S.maNXB and S.maTL = TL.maTL and S.maTG = tg.maTG and S.masach='" + fListBook.selected_book.Replace(" ", "") + "' and K.masach ='" + fListBook.selected_book.Replace(" ", "") + "'" ;
            DataTable dp = DP.Instance.ExecuteQuery(query);
            int sl = 0;
            foreach (DataRow i in dp.Rows)
            {
                tensach_LB.Content = i["tensach"].ToString();
                tacgia_LB.Content = i["tenTG"].ToString();
                theloai_LB.Content = i["tenTL"].ToString();
                namxb_LB.Content = i["namXB"].ToString();
                sl = Convert.ToInt32(i["soluong"]);
                nxb_LB.Content = i["tenNXB"].ToString();
                price_LB.Content = Convert.ToInt32(i["giaban"]) + "VNĐ";
            }
            if (sl > 0)
            {
                trangthai_LB.Content = "Con hang";
            }
            else
            {
                trangthai_LB.Content = "Het hang";
            }
        }
        
    }
}
