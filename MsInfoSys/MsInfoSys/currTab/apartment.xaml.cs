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
using System.Collections.ObjectModel;

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
            signView.DataContext = new apartmentSignViewModel();
            sanitaryView.DataContext = new apartmentSanitaryViewModel();
        }
        //图表显示
        public class apartmentSignViewModel
        {
            public ObservableCollection<TestClass> Sign { get; private set; }

            public apartmentSignViewModel()
            {
                Sign = new ObservableCollection<TestClass>();
                Sign.Add(new TestClass() { Category = "星期一", Number = 75 });
                Sign.Add(new TestClass() { Category = "星期二", Number = 2 });
                Sign.Add(new TestClass() { Category = "星期三", Number = 12 });
                Sign.Add(new TestClass() { Category = "星期四", Number = 83 });
                Sign.Add(new TestClass() { Category = "星期五", Number = 29 });
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
                Sanitary.Add(new TestClass() { Category = "第三周", Number = 8});
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
