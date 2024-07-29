using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.Common;
using System.Security.Cryptography;
using System.CodeDom;
using System.Net;
using System.Xml.Linq;
using System.Diagnostics.Eventing.Reader;
using System.Data.SqlTypes;

namespace ActiveXDataObjectDemo
{
    public partial class PhoneBookV1 : Form
    {
        public PhoneBookV1()
        {
            InitializeComponent();
        }
        private void PhoneBook_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = GetAllData();
        }

        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        /*#region Select Statement with Connected Mode
        // 1- Connect to DB with Connection String
        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-N05LLDH\\SQLEXPRESS;Initial Catalog=Firm;Integrated Security=True;");

        // 2- Create SQL Command
        //SqlCommand query = new SqlCommand($"select * from worker where id = {txtboxID.Text}");

        // Another way to do the same thing above
        SqlCommand query = new SqlCommand($"select * from worker where id = @_id");
        query.Parameters.AddWithValue("_id", txtboxID.Text);

        // 3- Bind Command with Connection
        query.Connection = sqlConnection;

        // 4- Open Connection
        sqlConnection.Open();

        // 5- Execute the Command using SqlDataReader (Connected Mode)
        SqlDataReader dataReader = query.ExecuteReader();
        if (!dataReader.HasRows)
        {
            int id = Convert.ToInt32(txtboxID.Text);
            txtboxID.Text = txtboxName.Text = txtboxAddress.Text = string.Empty;
            txtboxID.Focus();
            MessageBox.Show($"No data with ID: {id} is found!", "No Data!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            while (dataReader.Read())
            {
                txtboxName.Text = dataReader["Name"].ToString();
                txtboxAddress.Text = dataReader["City"].ToString();
            }
        }

        // 6- Close Connection
        sqlConnection.Close();
        #endregion*/

        /*#region Select Statement with Disconnected Mode
        // 1- Connect to DB with Connection String
        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-N05LLDH\\SQLEXPRESS;Initial Catalog=Firm;Integrated Security=True;");

        // 2- Create SQL Command
        SqlCommand command = new SqlCommand($"select * from worker where id = {txtboxID.Text}");

        // 3- Bind Command with Connection
        command.Connection = sqlConnection;

        // 4- Execute the Command using SqlDataAdapter (Disconnected Mode)
        // SqlDataAdapter opens and closes the connection for us (we don't have to worry about them)
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        DataTable dataTable = new DataTable();
        adapter.Fill(dataTable);

        if (dataTable.Rows.Count == 0 )
        {
            int id = Convert.ToInt32(txtboxID.Text);
            txtboxID.Text = txtboxName.Text = txtboxAddress.Text = string.Empty;
            txtboxID.Focus();
            MessageBox.Show($"No data with ID: {id} is found!", "No Data!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
                txtboxName.Text = dataTable.Rows[0]["Name"].ToString();
                txtboxAddress.Text = dataTable.Rows[0]["City"].ToString();
        }

        #endregion*/
        //}

        private void btnGetByID_Click(object sender, EventArgs e)
        {
            int _id = Convert.ToInt32(txtboxID.Text);
            DataTable result = GetDataByID(_id);
            if (result.Rows.Count > 0)
            {
                dataGridView.DataSource = result;
                txtboxName.Text = result.Rows[0]["Name"].ToString();
                txtboxAddress.Text = result.Rows[0]["City"].ToString();
                txtboxPhone.Text = result.Rows[0]["Phone"].ToString();
            }
            else
            {
                ClearFields();
                txtboxID.Focus();
                MessageBox.Show($"No data with ID: {_id} is found!", "No data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView.DataSource = GetAllData();
            }
        }
        private void btnGetAll_Click(object sender, EventArgs e)
        {
            if (GetAllData().Rows.Count > 0)
                dataGridView.DataSource = GetAllData();
            else
                MessageBox.Show("No data is found!", "No data", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            bool success = true;
            bool status = ValidateEntries(Convert.ToInt32(txtboxID.Text), txtboxName.Text, txtboxAddress.Text, txtboxPhone.Text) && UniqueID(Convert.ToInt32(txtboxID.Text));

            if (status)
            {
                SqlConnection connection = EstaplishDBConnection();
                SqlCommand command = new SqlCommand($"insert into worker values(@id, @name, @address, @phoneNumber)");
                command.Parameters.AddWithValue("id", Convert.ToInt32(txtboxID.Text));
                command.Parameters.AddWithValue("name", txtboxName.Text);
                command.Parameters.AddWithValue("address", txtboxAddress.Text);
                command.Parameters.AddWithValue("phoneNumber", txtboxPhone.Text);
                command.Connection = connection;
                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected < 1)
                    success = false;
      
                connection.Close();   
            }

            if(success && status)
                MessageBox.Show($"Insertion has been done successfully!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                ClearFields();
                txtboxID.Focus();
                MessageBox.Show($"Insertion Failed!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataGridView.DataSource = GetAllData();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            bool success = true;
            int id = Convert.ToInt32(txtboxID.Text);
            DataTable user = GetDataByID(id);
            string name = txtboxName.Text == string.Empty ? user.Rows[0]["Name"].ToString() : txtboxName.Text;
            string address = txtboxAddress.Text == string.Empty ? user.Rows[0]["City"].ToString() : txtboxAddress.Text;
            string phoneNumber = txtboxPhone.Text == string.Empty ? user.Rows[0]["Phone"].ToString() : txtboxPhone.Text;
            bool validData = ValidateEntries(id, name, address, phoneNumber);

            if (validData)
            {
                SqlConnection connection = EstaplishDBConnection();
                SqlCommand command = new SqlCommand($"UPDATE Worker SET Name = @name, City = @address, Phone = @phoneNumber WHERE ID = @id;");
                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("address", address);
                command.Parameters.AddWithValue("phoneNumber", phoneNumber);

                command.Connection = connection;
                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected < 1)
                    success = false;

                connection.Close();
            }

            if (success && validData)
                MessageBox.Show($"Updation has been done successfully!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                ClearFields();
                txtboxID.Focus();
                MessageBox.Show($"Updation Failed!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataGridView.DataSource = GetAllData();

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection connection = EstaplishDBConnection();
            SqlCommand command = new SqlCommand("Delete from worker where id=@id");
            command.Parameters.AddWithValue("id", Convert.ToInt32(txtboxID.Text));

            command.Connection = connection;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            if(rowsAffected > 0)
                MessageBox.Show($"Deletion has been done successfully!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);   
             else
                MessageBox.Show($"Deletion Failed!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            dataGridView.DataSource = GetAllData();
            connection.Close();
        }
        private void txtboxSearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection connection = EstaplishDBConnection();

            SqlCommand query = new SqlCommand(
                $"Select * From Worker Where ID Like '%{txtboxSearch.Text}%' " +
                $"OR Name Like '%{txtboxSearch.Text}%' " +
                $"OR City Like '%{txtboxSearch.Text}%' " +
                $"OR Phone Like '%{txtboxSearch.Text}%'");

            query.Connection = connection;

            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query);
            adapter.Fill(dataTable);

            dataGridView.DataSource = dataTable;
        }
        private SqlConnection EstaplishDBConnection()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-N05LLDH\\SQLEXPRESS;Initial Catalog=Firm;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            return sqlConnection;
        }
        private DataTable GetDataByID(int id)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-N05LLDH\\SQLEXPRESS;Initial Catalog=Firm;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            SqlCommand cmd = new SqlCommand("select * from worker where id = @_id");
            cmd.Parameters.AddWithValue("_id", id);
            cmd.Connection = sqlConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
        private DataTable GetAllData()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-N05LLDH\\SQLEXPRESS;Initial Catalog=Firm;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            SqlCommand cmd = new SqlCommand("select * from worker");
            cmd.Connection = sqlConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
               
        }
        private bool ValidateEntries(int id, string name, string address, string phoneNumber)
        {
            if (id > 0 && name.Length > 3 && name.Length <= 20 && address.Length > 4 && address.Length <= 10 && phoneNumber.Length == 11)
                return true;
            else
                return false;
        }
        private bool UniqueID(int id)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-N05LLDH\\SQLEXPRESS;Initial Catalog=Firm;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            SqlCommand cmd = new SqlCommand("select id from worker where id = @_id");
            cmd.Parameters.AddWithValue("_id", id);
            cmd.Connection = sqlConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
                return false;
            else
                return true;
        }
        private void ClearFields()
        {
            txtboxID.Text = txtboxName.Text = txtboxAddress.Text = txtboxPhone.Text = string.Empty;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            dataGridView.DataSource = GetAllData();
        }
        private void dataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtboxID.Text = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtboxName.Text = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtboxAddress.Text = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtboxPhone.Text = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
    }
}
