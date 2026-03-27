using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using accountCreate.connection;
using MySql.Data.MySqlClient;
using accountCreate.accountCredentials;

namespace accountCreate {
    public partial class ConfirmDeleteForm : Form {
        private MySqlConnection connection;
        public bool confirmDelete { get; private set; }
        public ConfirmDeleteForm() {
            InitializeComponent();
        }

        private void ConfirmDeleteForm_Load(object sender, EventArgs e) {
            DBConnect connect = new DBConnect();
            connection = connect.databaseConnection();
        }

        private void button1_Click(object sender, EventArgs e) {
            accountData DeleteConfirm = new accountData();
            confirmDelete = true;

            Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            confirmDelete = false;
            Close(); // Close the confirmation window
        }

    }
}
