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
    /// currTab0.xaml 的交互逻辑
    /// </summary>
    public partial class index : UserControl
    {
        public index()
        {
            InitializeComponent();
        }

        private void indeximg1_MouseEnter(object sender, MouseEventArgs e)
        {
            indeximg1.BorderBrush = new SolidColorBrush(Color.FromRgb(43, 150, 221));
        }

        private void indeximg1_MouseLeave(object sender, MouseEventArgs e)
        {
            indeximg1.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }
    }
}
