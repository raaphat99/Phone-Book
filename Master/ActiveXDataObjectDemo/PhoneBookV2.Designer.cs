namespace ActiveXDataObjectDemo
{
    partial class PhoneBookV2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClear = new System.Windows.Forms.Button();
            this.label_PhoneNumber = new System.Windows.Forms.Label();
            this.label_Search = new System.Windows.Forms.Label();
            this.txtboxSearch = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.txtboxPhone = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnGetAll = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnGetByID = new System.Windows.Forms.Button();
            this.label_Address = new System.Windows.Forms.Label();
            this.label_Name = new System.Windows.Forms.Label();
            this.label_ID = new System.Windows.Forms.Label();
            this.txtboxAddress = new System.Windows.Forms.TextBox();
            this.txtboxName = new System.Windows.Forms.TextBox();
            this.txtboxID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(56, 331);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(279, 34);
            this.btnClear.TabIndex = 33;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label_PhoneNumber
            // 
            this.label_PhoneNumber.AutoSize = true;
            this.label_PhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_PhoneNumber.Location = new System.Drawing.Point(52, 276);
            this.label_PhoneNumber.Name = "label_PhoneNumber";
            this.label_PhoneNumber.Size = new System.Drawing.Size(55, 20);
            this.label_PhoneNumber.TabIndex = 32;
            this.label_PhoneNumber.Text = "Phone";
            // 
            // label_Search
            // 
            this.label_Search.AutoSize = true;
            this.label_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Search.Location = new System.Drawing.Point(428, 63);
            this.label_Search.Name = "label_Search";
            this.label_Search.Size = new System.Drawing.Size(60, 20);
            this.label_Search.TabIndex = 31;
            this.label_Search.Text = "Search";
            // 
            // txtboxSearch
            // 
            this.txtboxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxSearch.Location = new System.Drawing.Point(494, 60);
            this.txtboxSearch.Name = "txtboxSearch";
            this.txtboxSearch.Size = new System.Drawing.Size(409, 26);
            this.txtboxSearch.TabIndex = 30;
            this.txtboxSearch.TextChanged += new System.EventHandler(this.txtboxSearch_TextChanged);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(471, 324);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_RowHeaderMouseClick);
            // 
            // txtboxPhone
            // 
            this.txtboxPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxPhone.Location = new System.Drawing.Point(134, 276);
            this.txtboxPhone.Name = "txtboxPhone";
            this.txtboxPhone.Size = new System.Drawing.Size(166, 26);
            this.txtboxPhone.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView);
            this.panel1.Location = new System.Drawing.Point(432, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(471, 324);
            this.panel1.TabIndex = 29;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(246, 410);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(89, 33);
            this.btnDelete.TabIndex = 26;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnGetAll
            // 
            this.btnGetAll.Location = new System.Drawing.Point(198, 371);
            this.btnGetAll.Name = "btnGetAll";
            this.btnGetAll.Size = new System.Drawing.Size(137, 33);
            this.btnGetAll.TabIndex = 25;
            this.btnGetAll.Text = "GetAll";
            this.btnGetAll.UseVisualStyleBackColor = true;
            this.btnGetAll.Click += new System.EventHandler(this.btnGetAll_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(56, 410);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(89, 33);
            this.btnInsert.TabIndex = 27;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(151, 410);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(89, 33);
            this.btnUpdate.TabIndex = 28;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnGetByID
            // 
            this.btnGetByID.Location = new System.Drawing.Point(56, 371);
            this.btnGetByID.Name = "btnGetByID";
            this.btnGetByID.Size = new System.Drawing.Size(137, 33);
            this.btnGetByID.TabIndex = 24;
            this.btnGetByID.Text = "GetByID";
            this.btnGetByID.UseVisualStyleBackColor = true;
            this.btnGetByID.Click += new System.EventHandler(this.btnGetByID_Click);
            // 
            // label_Address
            // 
            this.label_Address.AutoSize = true;
            this.label_Address.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Address.Location = new System.Drawing.Point(52, 224);
            this.label_Address.Name = "label_Address";
            this.label_Address.Size = new System.Drawing.Size(68, 20);
            this.label_Address.TabIndex = 23;
            this.label_Address.Text = "Address";
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Name.Location = new System.Drawing.Point(52, 170);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(51, 20);
            this.label_Name.TabIndex = 21;
            this.label_Name.Text = "Name";
            // 
            // label_ID
            // 
            this.label_ID.AutoSize = true;
            this.label_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ID.Location = new System.Drawing.Point(52, 119);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(26, 20);
            this.label_ID.TabIndex = 20;
            this.label_ID.Text = "ID";
            // 
            // txtboxAddress
            // 
            this.txtboxAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxAddress.Location = new System.Drawing.Point(134, 224);
            this.txtboxAddress.Name = "txtboxAddress";
            this.txtboxAddress.Size = new System.Drawing.Size(166, 26);
            this.txtboxAddress.TabIndex = 19;
            // 
            // txtboxName
            // 
            this.txtboxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxName.Location = new System.Drawing.Point(134, 170);
            this.txtboxName.Name = "txtboxName";
            this.txtboxName.Size = new System.Drawing.Size(166, 26);
            this.txtboxName.TabIndex = 18;
            // 
            // txtboxID
            // 
            this.txtboxID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxID.Location = new System.Drawing.Point(134, 119);
            this.txtboxID.Name = "txtboxID";
            this.txtboxID.Size = new System.Drawing.Size(166, 26);
            this.txtboxID.TabIndex = 17;
            // 
            // PhoneBookV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 505);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label_PhoneNumber);
            this.Controls.Add(this.label_Search);
            this.Controls.Add(this.txtboxSearch);
            this.Controls.Add(this.txtboxPhone);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnGetAll);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnGetByID);
            this.Controls.Add(this.label_Address);
            this.Controls.Add(this.label_Name);
            this.Controls.Add(this.label_ID);
            this.Controls.Add(this.txtboxAddress);
            this.Controls.Add(this.txtboxName);
            this.Controls.Add(this.txtboxID);
            this.MaximumSize = new System.Drawing.Size(970, 544);
            this.MinimumSize = new System.Drawing.Size(970, 544);
            this.Name = "PhoneBookV2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PhoneBookV2";
            this.Load += new System.EventHandler(this.PhoneBookV2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label_PhoneNumber;
        private System.Windows.Forms.Label label_Search;
        private System.Windows.Forms.TextBox txtboxSearch;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox txtboxPhone;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnGetAll;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnGetByID;
        private System.Windows.Forms.Label label_Address;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.TextBox txtboxAddress;
        private System.Windows.Forms.TextBox txtboxName;
        private System.Windows.Forms.TextBox txtboxID;
    }
}