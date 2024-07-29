using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ActiveXDataObjectDemo.DAL;

namespace ActiveXDataObjectDemo.BL
{
    public static class Services
    {
        public static DataTable GetByID(int id)
        {
            SqlCommand command = new SqlCommand("select * from worker where id=@_id");
            command.Parameters.AddWithValue("_id", id);
            return DBContact.ExecuteSelectQuery(command);
        }

        public static DataTable GetAll()
        {
            SqlCommand command = new SqlCommand("select * from worker");
            return DBContact.ExecuteSelectQuery(command);
        }

        public static DataTable Search(string searchQuery)
        {
            SqlCommand command = new SqlCommand(
                $"Select * From Worker Where ID Like '%{searchQuery}%' " +
                $"OR Name Like '%{searchQuery}%' " +
                $"OR City Like '%{searchQuery}%' " +
                $"OR Phone Like '%{searchQuery}%'");
            DataTable dataTable = DBContact.ExecuteSelectQuery(command);
            return dataTable;
        }

        public static int InsertEntry(int id, string name, string address, string phoneNumber)
        {
            int rowsAffected;
            if (UniqueID(id))
            {
                SqlCommand command = new SqlCommand("insert into worker values(@id, @name, @address, @phoneNumber)");
                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("address", address);
                command.Parameters.AddWithValue("phoneNumber", phoneNumber);
                rowsAffected = DBContact.ExecuteDMLQuery(command);
            } 
            else
            {
                rowsAffected = -1;
            }
            return rowsAffected;
        }

        public static int UpdateEntry(int id, string name, string address, string phoneNumber)
        {
            SqlCommand command = new SqlCommand($"UPDATE Worker SET Name = @name, City = @address, Phone = @phoneNumber WHERE ID = @id;");
            command.Parameters.AddWithValue("id", id);
            command.Parameters.AddWithValue("name", name);
            command.Parameters.AddWithValue("address", address);
            command.Parameters.AddWithValue("phoneNumber", phoneNumber);
            int rowsAffected = DBContact.ExecuteDMLQuery(command);
            return rowsAffected;
        }

        public static int DeleteEntry(int id)
        {
            SqlCommand command = new SqlCommand("delete from worker where id=@_id");
            command.Parameters.AddWithValue("_id", id);
            int rowsAffected = DBContact.ExecuteDMLQuery(command);
            return rowsAffected;
        }

        public static bool ValidateEntries(int id, string name, string address, string phoneNumber)
        {
            if (id > 0 && name.Length > 3 && name.Length <= 20 && address.Length > 4 && address.Length <= 10 && phoneNumber.Length == 11)
                return true;
            else
                return false;
        }

        public static bool UniqueID(int id)
        {
            DataTable dataTable = Services.GetByID(id);
            if (dataTable.Rows.Count > 0)
                return false;
            else
                return true;
        }


    }
}
