using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ActiveXDataObjectDemo.BL;

namespace ActiveXDataObjectDemo
{
    public partial class PhoneBookV2 : Form
    {
        public PhoneBookV2()
        {
            InitializeComponent();
        }
        private void PhoneBookV2_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = Services.GetAll();
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = Services.GetAll();
        }

        private void btnGetByID_Click(object sender, EventArgs e)
        {
            int _id = -1; bool success = true;
            DataTable result = null;
            try
            {
                _id = Convert.ToInt32(txtboxID.Text);
                result = Services.GetByID(_id);
            }
            catch (Exception)
            {
                success = false;
            }
            
            if (success && result.Rows.Count > 0)
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
                dataGridView.DataSource = Services.GetAll();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int _id = -1, rowsAffected = -1; bool success = true;
            try
            {
                _id = Convert.ToInt32(txtboxID.Text);
                rowsAffected = Services.DeleteEntry(_id);
            }
            catch (Exception)
            {
                success = false;
            }
  
            if (success & rowsAffected > 0)
                MessageBox.Show($"Deletion has been done successfully!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show($"Deletion Failed!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            dataGridView.DataSource = Services.GetAll();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtboxID.Text = txtboxName.Text = txtboxAddress.Text = txtboxPhone.Text = string.Empty;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int rowsAffected = -1;
            bool validData;
            try
            {
                validData = Services.ValidateEntries(Convert.ToInt32(txtboxID.Text), txtboxName.Text, txtboxAddress.Text, txtboxPhone.Text);
            }
            catch (Exception)
            {
                validData = false;
            }

            if (validData)
            {
                rowsAffected = Services.InsertEntry(Convert.ToInt32(txtboxID.Text), txtboxName.Text, txtboxAddress.Text, txtboxPhone.Text);
            }
            
            if (!validData || rowsAffected <= 0)
            {
                ClearFields();
                txtboxID.Focus();
                MessageBox.Show($"Insertion Failed!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
            else
            {
                MessageBox.Show($"Insertion has been done successfully!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dataGridView.DataSource = Services.GetAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool validData = false, success = true;
            int id= -1;
            string name = "", address = "", phoneNumber = "";
            try
            {
                id = Convert.ToInt32(txtboxID.Text);
                DataTable user = Services.GetByID(id);
                name = txtboxName.Text == string.Empty ? user.Rows[0]["Name"].ToString() : txtboxName.Text;
                address = txtboxAddress.Text == string.Empty ? user.Rows[0]["City"].ToString() : txtboxAddress.Text;
                phoneNumber = txtboxPhone.Text == string.Empty ? user.Rows[0]["Phone"].ToString() : txtboxPhone.Text;
                validData = Services.ValidateEntries(id, name, address, phoneNumber);
            }
            catch (Exception)
            {
                success = false;
            }

            if (validData)
            {
                int rowsAffected = Services.UpdateEntry(id, name, address, phoneNumber);
                if (rowsAffected <= 0)
                    success = false;
            }

            if (success && validData)
                MessageBox.Show($"Updation has been done successfully!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                ClearFields();
                txtboxID.Focus();
                MessageBox.Show($"Updation Failed!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataGridView.DataSource = Services.GetAll();
        }

        private void txtboxSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable dataTable = Services.Search(txtboxSearch.Text);
            dataGridView.DataSource = dataTable;
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
