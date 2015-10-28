using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsInfoSys
{
    class DBHelper
    {
        public static string MySQLStr = ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;
        public static MySqlConnection conn = new MySqlConnection(MySQLStr);
    }
}
