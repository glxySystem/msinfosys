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
        private void indexClock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            indexContent.Content = new currMain.indexContent.indexClock();
        }

        private void indexcontact_MouseDown(object sender, MouseButtonEventArgs e)
        {
            indexContent.Content = new currMain.indexContent.indexContact();
        }
    }
}
