using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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
    /// undergraduateInfo.xaml 的交互逻辑
    /// </summary>
    public partial class undergraduateInfo : UserControl
    {

        //早点到，年级下拉表
        public List<String> GradeLstSource { get; set; }
        public string GradeLstSelect { get; set; }

        //早点到，专业下拉表
        public List<String> MajorLstSource { get; set; }
        public string MajorLstSelect { get; set; }

        public List<String> memberData { get; set; }

        /// 构造方法       
        public undergraduateInfo()
        {
            InitializeComponent();
            GradeLstSource = new List<string>() { "全部" };
            GradeLstSelect = "全部";
            GetGrade();
            MajorLstSource = new List<string>() { "全部" };
            MajorLstSelect = "全部";
            GetMajorName();
            this.DataContext = this;


            //StudentDataProvider sdp = new StudentDataProvider("select * from student","Student");
            //DataSet ds = sdp.GetRawData();


            //string MySQLStr = ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;
            //MySqlConnection conn = new MySqlConnection(MySQLStr);
            //if (conn != null)
            //{
                MySqlDataAdapter mda = new MySqlDataAdapter("select * from student", DBHelper.conn);
                //MessageBox.Show(mda);
                DataTable dt = new DataTable();
                mda.AcceptChangesDuringUpdate = true;
                mda.Fill(dt);
                StuInfodataGrid.ItemsSource = dt.DefaultView;//数据才会显示
               /// MessageBox.Show("打开数据库成功" + mda);
            //}

            //StuInfodataGrid.ItemsSource = null;
            //memberData = new List<String>();
            //if (ds.Tables["Student"].Rows.Count > 0)
            //{
            //    foreach (DataRow row in ds.Tables[0].Rows)
            //    {
            //        //Console.WriteLine(row[0].ToString());
            //        //MajorLstSource.Add(row[0].ToString());
            //        memberData.Add(row[0].ToString());
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("数据表为空！");
            //}


            //memberData.Add(new Member()
            //{
            //    Name = "Joe",
            //    Age = "23",
            //    Sex = SexOpt.Male,
            //    Pass = true,
            //    Email = new Uri("mailto:Joe@school.com")
            //});
            //memberData.Add(new Member()
            //{
            //    Name = "Mike",
            //    Age = "20",
            //    Sex = SexOpt.Male,
            //    Pass = false,
            //    Email = new Uri("mailto:Mike@school.com")
            //});
            //memberData.Add(new Member()
            //{
            //    Name = "Lucy",
            //    Age = "25",
            //    Sex = SexOpt.Female,
            //    Pass = true,
            //    Email = new Uri("mailto:Lucy@school.com")
            //});
            //StuInfodataGrid.DataContext = memberData;
        }


        //public enum SexOpt { Male, Female };

        //public class Member
        //{
        //    public string Name { get; set; }
        //    public string Age { get; set; }
        //    public SexOpt Sex { get; set; }
        //    public bool Pass { get; set; }
        //    public Uri Email { get; set; }
        //}

        /// <summary>
        /// 查询字符串：
        /// </summary>
        private void GetMajorName()
        {
            ///// 构造查询字符串
            //string sql = "select major_name  from major";

            //MySqlDataAdapter mda = new MySqlDataAdapter(sql, DBHelper.MySQLStr);

            ///// 设置XXX
            //DataSet ds = new DataSet();

            //mda.Fill(ds, "MajorName");

            StudentDataProvider sdp = new StudentDataProvider("select major_name  from major", "MajorName");

            DataSet ds = sdp.GetRawData();

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
    }
}
