using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ActiveXDataObjectDemo.DAL
{
    public static class DBContact
    {
        static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-N05LLDH\\SQLEXPRESS;Initial Catalog=Firm;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        public static DataTable ExecuteSelectQuery(SqlCommand command)
        {
            command.Connection = connection;
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static int ExecuteDMLQuery(SqlCommand command)
        {
            command.Connection = connection;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }
    }
}
