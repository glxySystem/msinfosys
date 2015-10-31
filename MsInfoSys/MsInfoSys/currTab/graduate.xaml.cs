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
    /// graduate.xaml 的交互逻辑
    /// </summary>
    public partial class graduate : UserControl
    {
        public graduate()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            currMain.Content = new currMain.tabGraduate();
        }
        //加载毕业生信息模块
        private void graduateInfoStack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            graduateInfoStack.Background = new SolidColorBrush(Color.FromRgb(242, 242, 242));
            graduateDevelopmentStack.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }
        //加载毕业生去向模块
        private void graduateDevelopmentStack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            graduateDevelopmentStack.Background = new SolidColorBrush(Color.FromRgb(242, 242, 242));
            graduateInfoStack.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }
    }
}
