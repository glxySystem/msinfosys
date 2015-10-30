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

namespace MsInfoSys.currTab
{
    /// <summary>
    /// apartment.xaml 的交互逻辑
    /// </summary>
    public partial class apartment : UserControl
    {
        public apartment()
        {
            InitializeComponent();
        }

        private void apartmentSign_Click(object sender, RoutedEventArgs e)
        {
            currMain.Content = new currMain.apartmentSign();
        }

        private void apartmentSanitary_Click(object sender, RoutedEventArgs e)
        {
            currMain.Content = new currMain.apartmentSign(); 
        }
    }
}
