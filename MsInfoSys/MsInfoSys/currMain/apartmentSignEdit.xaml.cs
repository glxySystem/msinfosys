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
    /// apartmentSignEdit.xaml 的交互逻辑
    /// </summary>
    public partial class apartmentSignEdit : Window
    {
        public void apartmentSign()
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

        private void doSignEdit_Click(object sender, RoutedEventArgs e)
        {
            //早点到信息修改操作
            Close();
        }

        private void doCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
