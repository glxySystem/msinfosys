using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MsInfoSys.currMain
{
    /// <summary>
    /// StudentInfoDialog.xaml 的交互逻辑
    /// </summary>
    public partial class StudentInfoDialog : Window
    {
        private string result;

        //public StudentInfoDialog()
        //{
        //    InitializeComponent();
        //}

        public StudentInfoDialog(string result)
        {
            this.result = result;
            InitializeComponent();
        }

        private void TabItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("i am here1");
        }
        private void TabItem2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("i am here2");
        }

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("dianjii");
        }

        private void TabItem_StudyCard_GotFocus(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("学籍卡片");
        }
    }
}
