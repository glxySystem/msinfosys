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

namespace MsInfoSys
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            /// 构造查询字符串
            string sql = string.Format("select * from auth_user where user_name='{0}' and user_password='{1}'", userName.Text, Password.Password);

            MySqlDataAdapter mda = new MySqlDataAdapter(sql, DBHelper.MySQLStr);
			/// 设置DataSet
            DataSet ds = new DataSet();
            mda.Fill(ds, "auth_user");
            if (ds.Tables["auth_user"].Rows.Count > 0)
            {
                //System.Windows.MessageBox.Show("登陆成功");


                /// 保存全局登录信息
                AuthUser.username = userName.Text;
                AuthUser.username = Password.Password;

                ///登陆成功显示主窗体
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("登陆失败");
            }
        }
    }
}
