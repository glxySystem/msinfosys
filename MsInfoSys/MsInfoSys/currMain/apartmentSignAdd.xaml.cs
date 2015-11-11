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
using System.Windows.Shapes;

namespace MsInfoSys.currMain
{
    /// <summary>
    /// apartmentSignAdd.xaml 的交互逻辑
    /// </summary>
    public partial class apartmentSignAdd : Window
    {

            //早点到，年级下拉表
            public List<String> GradeLstSource { get; set; }
            public string GradeLstSelect { get; set; }

            //早点到，专业下拉表
            public List<String> MajorLstSource { get; set; }
            public string MajorLstSelect { get; set; }

        public List<String> ClassLstSource { get; set; }
        public string ClassLstSelect { get; set; }
        /// 构造方法       
        public apartmentSignAdd()
            {
                InitializeComponent();
                GradeLstSource = new List<string>() { "全部" };
                GradeLstSelect = "全部";
                GetGrade();
                MajorLstSource = new List<string>() { "全部" };
                MajorLstSelect = "全部";
                GetMajorName();
                ClassLstSource = new List<string>() { "全部" };
                ClassLstSelect = "全部";
                GetClass();
                this.DataContext = this;
            }

            /// <summary>
            /// 查询字符串：
            /// </summary>
            private void GetMajorName()
            {
                /// 构造查询字符串
                string sql = "select major_name  from ms_major";

                MySqlDataAdapter mda = new MySqlDataAdapter(sql, DBHelper.MySQLStr);

                /// 设置XXX
                DataSet ds = new DataSet();

                mda.Fill(ds, "MajorName");

                if (ds.Tables["MajorName"].Rows.Count > 0)
                {
                    /// Test Code
                    //MessageBox.Show(ds.Tables["MajorName"].Rows.Count.ToString());

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
                string sql = "select grade_num  from ms_grade";

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

            private void GetClass()
        {
            /// 构造查询字符串
            string sql = "select class_name  from ms_class";

            MySqlDataAdapter mda = new MySqlDataAdapter(sql, DBHelper.MySQLStr);

            /// 设置XXX
            DataSet ds = new DataSet();

            mda.Fill(ds, "Class");

            if (ds.Tables["Class"].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ClassLstSource.Add(row[0].ToString());
                }
            }
            else
            {
                MessageBox.Show("数据表为空！");
            }
        }
        
            private void doSignAdd_Click(object sender, RoutedEventArgs e)
            {

                //添加点到信息操作
                Close();
            }

            //public static void Insert(Student student)
            //{
            //    string sql = string.Format("insert into student(id,name,address) values('{0}','{1}','{2}')", student.Id, student.Name, student.Address);
            //    MySqlHelper.ExecuteNonQuery("server=192.168.1.1;database=s_t;uid=root;pwd=;", sql, null);
            //}

        private void doCancel_Click(object sender, RoutedEventArgs e)
            {
                Close();
            }
    }
}
