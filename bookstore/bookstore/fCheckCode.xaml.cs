using System;
using System.Collections.Generic;
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
    /// Interaction logic for fCheckCode.xaml
    /// </summary>
    public partial class fCheckCode : Window
    {
        public fCheckCode()
        {
            InitializeComponent();
        }

        private void check_Click(object sender, RoutedEventArgs e)
        {
            if (code.Text.ToString() == "180401")
            {
                fChangePw changepw = new fChangePw();
                changepw.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Mã xác minh không chính xác", "Failed");
            }
        }
    }
}
