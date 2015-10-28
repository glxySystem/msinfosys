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
    /// apartmentSign.xaml 的交互逻辑
    /// </summary>
    public partial class apartmentSign : UserControl
    {
        public apartmentSign()
        {
            InitializeComponent();
            GradeLstSource = new List<string>() { "全部", "14级", "15级" };
            GradeLstSelect = "全部";
            MajorLstSource = new List<string>() { "全部", "信管", "电商" };
            MajorLstSelect = "全部";
            this.DataContext = this;
        }
        //早点到，年级下拉表
        public List<String> GradeLstSource { get; set; }
        public string GradeLstSelect { get; set; }

        //早点到，专业下拉表
        public List<String> MajorLstSource { get; set; }
        public string MajorLstSelect { get; set; }

        private void SignAdd_Click(object sender, RoutedEventArgs e)
        {
            new apartmentSignAdd().ShowDialog();
        }

        private void SignEdit_Click(object sender, RoutedEventArgs e)
        {
            //判断是否选中行数据,有则
            new apartmentSignEdit().ShowDialog();
            //若没有选中则 MessageBox.Show("请先点击选择一行数据！");
        }

        private void SignDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("确定要删除吗", "问题", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
            {
                try
                {
                    //早点到信息删除操作
                    MessageBox.Show("删除成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
