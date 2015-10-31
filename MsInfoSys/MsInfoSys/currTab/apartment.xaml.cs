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
        //加载早点到模块
        private void apartmentSignStack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            apartmentSignStack.Background = new SolidColorBrush(Color.FromRgb(242, 242, 242));
            apartmentSanitaryStack.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            apartmentCheckStack.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }
        //加载卫生检查模块
        private void apartmentSanitaryStack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            apartmentSanitaryStack.Background = new SolidColorBrush(Color.FromRgb(242, 242, 242));
            apartmentSignStack.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            apartmentCheckStack.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }
        //加载晚查寝模块
        private void apartmentCheckStack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            apartmentCheckStack.Background = new SolidColorBrush(Color.FromRgb(242, 242, 242));
            apartmentSignStack.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            apartmentSanitaryStack.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }
    }
}
