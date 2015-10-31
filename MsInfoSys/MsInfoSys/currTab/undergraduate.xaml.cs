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
    /// undergraduate.xaml 的交互逻辑
    /// </summary>
    public partial class undergraduate : UserControl
    {
        public undergraduate()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            currMain.Content = new currMain.undergraduateInfo();
        }
        //加载在校生基本信息模块
        private void undergraduateInfoStack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            undergraduateInfoStack.Background = new SolidColorBrush(Color.FromRgb(242,242,242));
            undergraduateGradeStack.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            undergraduateTestStack.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            undergraduateRewardStack.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }
        //加载在校生成绩管理模块
        private void undergraduateGradeStack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            undergraduateGradeStack.Background = new SolidColorBrush(Color.FromRgb(242, 242, 242));
            undergraduateInfoStack.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            undergraduateTestStack.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            undergraduateRewardStack.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }
        //加载在校生补缓考信息模块
        private void undergraduateTestStack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            undergraduateTestStack.Background = new SolidColorBrush(Color.FromRgb(242, 242, 242));
            undergraduateInfoStack.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            undergraduateGradeStack.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            undergraduateRewardStack.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }
        //加载在校生奖惩管理模块
        private void undergraduateRewardStack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            undergraduateRewardStack.Background = new SolidColorBrush(Color.FromRgb(242, 242, 242));
            undergraduateInfoStack.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            undergraduateGradeStack.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            undergraduateTestStack.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }
    }
}
