using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsInfoSys
{
    class StudentDataProvider
    {
        private MySqlDataAdapter adapter;
        /// 构造查询字符串
        private string sql;
        private string tableStr;
        private DataSet dataset;

        public StudentDataProvider(string queryStr,string tableStr)
        {
            this.tableStr = tableStr;
            this.sql = queryStr;
            dataset = new DataSet();
            adapter = new MySqlDataAdapter(this.sql, DBHelper.MySQLStr);
            adapter.Fill(dataset, this.tableStr);

            ///要不要关闭？
            //DBHelper.conn.Close();
        }

        public DataSet GetRawData()
        {
            return this.dataset;
        }
    }
}
