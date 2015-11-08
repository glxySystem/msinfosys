using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            signView.DataContext = new apartmentSignViewModel();
            sanitaryView.DataContext = new apartmentSanitaryViewModel();
        }

        //private void UserControl_Loaded(object sender, RoutedEventArgs e)
        //{
        //    //currMain.Content = new currMain.undergraduateInfo();
        //}


        //图表显示
        public class apartmentSignViewModel
        {
            public ObservableCollection<TestClass> Sign { get; private set; }

            public apartmentSignViewModel()
            {
                Sign = new ObservableCollection<TestClass>();
                Sign.Add(new TestClass() { Category = "江西", Number = 75 });
                Sign.Add(new TestClass() { Category = "江苏", Number = 2 });
                Sign.Add(new TestClass() { Category = "浙江", Number = 12 });
                Sign.Add(new TestClass() { Category = "安徽", Number = 83 });
                Sign.Add(new TestClass() { Category = "湖北", Number = 29 });
            }

            private object selectedItem = null;
            public object SelectedItem
            {
                get
                {
                    return selectedItem;
                }
                set
                {
                    // selected item has changed
                    selectedItem = value;
                }
            }
        }

        public class apartmentSanitaryViewModel
        {
            public ObservableCollection<TestClass> Sanitary { get; private set; }

            public apartmentSanitaryViewModel()
            {
                Sanitary = new ObservableCollection<TestClass>();
                Sanitary.Add(new TestClass() { Category = "第一周", Number = 6 });
                Sanitary.Add(new TestClass() { Category = "第二周", Number = 2 });
                Sanitary.Add(new TestClass() { Category = "第三周", Number = 8 });
                Sanitary.Add(new TestClass() { Category = "第四周", Number = 4 });
            }

            private object selectedItem = null;
            public object SelectedItem
            {
                get
                {
                    return selectedItem;
                }
                set
                {
                    // selected item has changed
                    selectedItem = value;
                }
            }
        }
        // class which represent a data point in the chart
        public class TestClass
        {
            public string Category { get; set; }

            public int Number { get; set; }
        }


        //加载在校生基本信息模块
        private void undergraduateInfoStack_MouseDown(object sender, MouseButtonEventArgs e)
        {

            undergraduateInfoStack.Background = new SolidColorBrush(Color.FromRgb(242,242,242));
            undergraduateGradeStack.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            undergraduateTestStack.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            undergraduateRewardStack.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            currMain.Content = new currMain.undergraduateInfo();
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
