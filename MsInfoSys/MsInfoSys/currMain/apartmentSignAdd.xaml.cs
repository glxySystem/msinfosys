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
using System.Windows.Shapes;

namespace MsInfoSys.currMain
{
    /// <summary>
    /// apartmentSignAdd.xaml 的交互逻辑
    /// </summary>
    public partial class apartmentSignAdd : Window
    {
        public apartmentSignAdd()
        {
            InitializeComponent();
        }

        private void doSignAdd_Click(object sender, RoutedEventArgs e)
        {
            //添加点到信息操作
            Close();
        }

        private void doCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
