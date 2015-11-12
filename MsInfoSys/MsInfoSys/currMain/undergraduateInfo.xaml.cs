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
        public List<String> si { get; set; }
        //在校生信息，年级下拉表
        public List<String> GradeLstSource { get; set; }
        public string GradeLstSelect { get; set; }

        //在校生信息，专业下拉表
        public List<String> MajorLstSource { get; set; }
        public string MajorLstSelect { get; set; }

        //在校生信息，班级下拉表
        public List<String> ClassLstSource { get; set; }
        public string ClassLstSelect { get; set; }

        public List<String> memberData { get; set; }

        /// 构造方法       
        public undergraduateInfo()
        {
            InitializeComponent();

            GetGrade();

            GetMajorName();

            GetClass();

            this.DataContext = this;
        }


        /// <summary>
        /// 查询字符串：
        /// </summary>
        private void GetMajorName()
        {

            ///// 构造查询字符串
            //string sql = "select name  from major";

            //MySqlDataAdapter mda = new MySqlDataAdapter(sql, DBHelper.MySQLStr);

            ///// 设置XXX
            //DataSet ds = new DataSet();

            MajorLstSource = new List<string>() { "全部" };


            MajorLstSelect = "全部";


            StudentDataProvider sdp = new StudentDataProvider("select major_name  from ms_major", "MajorName");



            DataSet ds = sdp.GetRawData();

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
            
            GradeLstSource = new List<string>() { "全部" };

            GradeLstSelect = "全部";

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
            ClassLstSource = new List<string>();
            ClassLstSource.Add("全部");
            ClassLstSelect = "全部";
        }




        private void QueryButton_Click(object sender, RoutedEventArgs e)
        {
            if ("全部" == ClassLstSelect && "全部" == MajorLstSelect && "全部" == GradeLstSelect)
            {
                DataTable dt = DBHelper.ExecuteDataSet("select * from ms_student");

                StuInfodataGrid.ItemsSource = dt.DefaultView;//数据才会显示
            }
            else
            {
                StuInfodataGrid.ItemsSource = null;
                MessageBox.Show("请选择具体查询信息");
            }
            
        }

        private void StuInfodataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            if (StuInfodataGrid.SelectedItem != null)
            {
                //AppGlobal.ShowPatientInfo.Execute(DGView.SelectedItem);
                //StuInfodataGrid.SelectAll();
                //object dv = StuInfodataGrid.SelectedItem;

                DataRowView mySelectedElement = (DataRowView)StuInfodataGrid.SelectedItem;
                string param = mySelectedElement.Row["uid"].ToString();
                
                //MessageBox.Show(result);
                //DataTable dt = DBHelper.ExecuteDataSet("select * from student where uid = @getId",new MySqlParameter("@getId",result));

                //StuInfodataGrid.ItemsSource = dt.DefaultView;//数据才会显示
                StudentInfoDialog sid = new StudentInfoDialog(param);
                sid.ShowDialog();


            }
        }
    }


    class StuInfo
    {
        public string school_name { get; set; }
    }


}



//StudentDataProvider sdp = new StudentDataProvider("select * from student","Student");
//DataSet ds = sdp.GetRawData();


//string MySQLStr = ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;
//MySqlConnection conn = new MySqlConnection(MySQLStr);
//if (conn != null)
//{


//MySqlDataAdapter mda = new MySqlDataAdapter("select * from student", DBHelper.conn);
//MessageBox.Show(mda);
//DataTable dt = new DataTable();
//mda.AcceptChangesDuringUpdate = true;
//mda.Fill(dt);
//StuInfodataGrid.ItemsSource = dt.DefaultView;//数据才会显示



//StudentInfo = TableToList(table);
//cityName.ItemsSource = listCity;


////将返回的表转换成List<Area>  
//private List<string> TableToList(DataTable table)
//{
//    List<string> si = new List<string>();
//    foreach (DataRow row in table.Rows)
//    {
//        //string city = new Area();
//        //city.AreaID = (int)row["AreaId"];
//        //city.AreaName = (string)row["AreaName"];
//        si.Add(city);
//    }
//    return area;
//}
