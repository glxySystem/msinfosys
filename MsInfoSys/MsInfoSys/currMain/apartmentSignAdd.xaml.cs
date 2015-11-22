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

            public List<string> WeekLstSource { get; set; }
            public string WeekLstSelect { get; set; }

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
                WeekLstSource = new List<string>() { "全部" };
                WeekLstSelect = "全部";
                GetWeek();
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
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
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
                    MessageBox.Show("数据表空！");
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

        private void GetWeek()
        {
            /// 构造查询字符串
            string sql = "select week_num  from ms_week";

            MySqlDataAdapter mda = new MySqlDataAdapter(sql, DBHelper.MySQLStr);

            /// 设置XXX
            DataSet ds = new DataSet();

            mda.Fill(ds, "Week");

            if (ds.Tables["Week"].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                   WeekLstSource.Add(row[0].ToString());
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
            //先读取数据，验证学号和年纪等是否匹配
            private void ShowCheck(object sender, RoutedEventArgs e)
            {
<<<<<<< HEAD
                StudentDataProvider sdp = new StudentDataProvider("select stu_num,student.name,class.name,building.num,dormitory.num from school,major,class,student,dormitory,building","ShowCheck");
                DataSet ds = sdp.GetRawData();
            
                //if (ds.Tables["ShowCheck"].Rows.Count > 0)
                //{
                //    foreach (DataRow mDr in ds.Tables[0].Rows)
                //    {
                //        foreach (DataColumn mDc in ds.Tables[0].Columns)
                //        {
                //            Console.WriteLine(mDr[mDc].ToString());
                //        if (ds.Tables["mDr"].Rows.Count > 0)
                //         {
                //                mDr[1] == TextBox1.text;
                //                mDr[2]==
                //            }
                //        }
                //    }
             }
                else
                {
                    MessageBox.Show("数据表为空！");
                }
               // dt = ds.Tables["ShowCheck"];
             }
            //插入数据，插入stu_mor表
            //public static  void Insert(Student student)
            //{
            //    DataSet dt = new dt;
                if
                {
                    
                }
            //   StudentDataProvider sdp = new StudentDataProvider("insert into stu_mor(stu_id,moringsign_id,state) values('{0}','{1}','{2}')", stu_mor(stu_id, moringsign_id, state);
                  StudentDataProvider sdp = new StudentDataProvider("insert into ms_stu_morningsign(stu_id,moringsign_id,state) values('{0}','{1}','{2}')", ms_stu_morningsign(stu_id, id, name);
//}
=======
                //StudentDataProvider sdp = new StudentDataProvider("select * from ms_student","ShowCheck");
                //DataSet ds = sdp.GetRawData();
                //if (ds.Tables["ShowCheck"].Rows.Count > 0)
                //{
                //    foreach (DataRow row in ds.Tables[0].Rows)
                //    {
                //    //Console.WriteLine(row[0].ToString());
                //    //ShowCheck.Add(row[0].ToString());
                //    StuInfodataGrid.Add(row[0].ToString());
                //}
                //}
                //else
                //{
                //    MessageBox.Show("数据表为空！");
                //}
            // dt = ds.Tables["ShowCheck"];
                //DataTable dt = DBHelper.ExecuteDataSet("select * from ms_student");
                //StuDataGrid.ItemsSource = dt.DefaultView;//数据才会显示
        }

        private void Query_Click(object sender, RoutedEventArgs e)
        {
            string para = ClassLstSelect;
            string sql = string.Format("select * from ms_student where class_name='{0}'", para);
            //MessageBox.Show();
            ClassCombox.SelectedItem.ToString();
            //DataTable dt = DBHelper.ExecuteDataSet("select * from ms_student where ");
            DataTable dt = DBHelper.ExecuteDataSet(sql);
            StuDataGrid.ItemsSource = dt.DefaultView;//数据才会显示
        }
>>>>>>> origin/master

private void doCancel_Click(object sender, RoutedEventArgs e)
            {
                Close();
            }
    }
}
