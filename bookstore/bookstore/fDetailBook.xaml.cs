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
            string query = "select tensach, tenTL, tenTG, namXB, giaban from SACH S, THELOAI TL, TACGIA tg where S.maTL = TL.maTL and S.maTG = tg.maTG and S.masach='" + fListBook.selected_book.Replace(" ", "") + "'"; ;
            DataTable dp = DP.Instance.ExecuteQuery(query);
            foreach (DataRow i in dp.Rows)
            {
                tensach_LB.Content = i["tensach"].ToString();
                tacgia_LB.Content = i["tenTG"].ToString();
            }
        }
        
    }
}
