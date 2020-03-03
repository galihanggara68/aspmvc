using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.Utility
{
    class Connector
    {
        private SqlConnection connection;

        public Connector()
        {
            connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=HR;Trusted_Connection=true");
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }
    }
}
