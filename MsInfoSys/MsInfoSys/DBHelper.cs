using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsInfoSys
{
    class DBHelper
    {
        public static string MySQLStr = ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;
        public static MySqlConnection conn = new MySqlConnection(MySQLStr);

        public static DataTable ExecuteDataSet(string sql, params MySqlParameter[] sqlParameters)
        {
            using (MySqlConnection conn = new MySqlConnection(MySQLStr))
            {
                conn.Open();
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Parameters.AddRange(sqlParameters);
                    cmd.CommandText = sql;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    return dataSet.Tables[0];
                }
            }
        }

        public static int ExecuteNonQuery(string sql, params MySqlParameter[] sqlParameters)
        {
            using (MySqlConnection conn = new MySqlConnection(MySQLStr))
            {
                conn.Open();
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Parameters.AddRange(sqlParameters);
                    cmd.CommandText = sql;
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
