using MsInfoSys.currMain;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

        //早点到，年级下拉表
        public List<String> GradeLstSource { get; set; }
        public string GradeLstSelect { get; set; }

        //早点到，专业下拉表
        public List<String> MajorLstSource { get; set; }
        public string MajorLstSelect { get; set; }
        /// 构造方法       
        public apartmentSign()
        {
            InitializeComponent();
            GradeLstSource = new List<string>() { "全部" };
            GradeLstSelect = "全部";
            GetGrade();
            MajorLstSource = new List<string>() { "全部" };
            MajorLstSelect = "全部";
            GetMajorName();
            this.DataContext = this;
        }

        /// <summary>
        /// 查询字符串：
        /// </summary>
        private void GetMajorName()
        {

            ///
            /// 老方法
            ///


            //构造查询字符串

            //string sql = "select major_name  from major";

            //MySqlDataAdapter mda = new MySqlDataAdapter(sql, DBHelper.MySQLStr);

            //设置XXX

            //DataSet ds = new DataSet();

            //mda.Fill(ds, "MajorName");


            //DataView dv = new DataView();
            //dv = ds.Tables["student"].DefaultView;
            //MessageBox.Show(dv.ToString());


            ///
            /// 新方法
            ///
            StudentDataProvider sdp = new StudentDataProvider("select major_name  from major", "MajorName");

            DataSet ds = sdp.GetStudents();


            if (ds.Tables["MajorName"].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    //Console.WriteLine(row[0].ToString());
                    MajorLstSource.Add(row[0].ToString());
                }
            }
            else
            {
                MessageBox.Show("数据表为空！");
            }
        }

        private void GetGrade()
        {
            /// 构造查询字符串
            string sql = "select grade_name  from grade";

            MySqlDataAdapter mda = new MySqlDataAdapter(sql, DBHelper.MySQLStr);

            /// 设置XXX
            DataSet ds = new DataSet();

            mda.Fill(ds, "Grade");

            if (ds.Tables["Grade"].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    GradeLstSource.Add(row[0].ToString());
                }
            }
            else
            {
                MessageBox.Show("数据表为空！");
            }
        }


        private void Show_Click(object sender, RoutedEventArgs e)
        {
            new apartmentSign().Show();
        }

        private DataTable Show()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql1 = "select stu_number,stu_name,major_name,class_name,dor_num from major,class,student_new,dormitory,ban where stu_dormitory=dor_id and stu_class=class_id and dor_ban=ban_id and class.major_id=major.major_id";
                MySqlDataAdapter mda = new MySqlDataAdapter(sql1, DBHelper.MySQLStr);
                DataSet ds = new DataSet();
                mda.Fill(ds, "Show");

                dt = ds.Tables["Show"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
        //尝试构造拼接sql语句
        //string field = "";
        //if (ComboBox.SelectedItem == "全部" )
        //{
        //    str = " ";
        //}
        //else
        //{

        //}
   

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

