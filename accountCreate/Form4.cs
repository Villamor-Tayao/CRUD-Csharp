using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using accountCreate.connection;
using accountCreate.accountCredentials;

namespace accountCreate {
    public partial class Form4 : Form {
        private MySqlConnection connection;
        private MySqlDataAdapter adapter;
        private MySqlCommand command;

        private string query;
        private bool PrepToDelete;
        public Form4() {
            InitializeComponent();
        }
        private void Form4_Load(object sender, EventArgs e) {
            DBConnect connect = new DBConnect();
            connection = connect.databaseConnection();
        }

        private void button1_Click(object sender, EventArgs e) {
            accountData user = new accountData();

            query = checkRecord(user);

            if (query == null) {
                PrepToDelete = false;
                return; // break the process
            }

            using (command  = new MySqlCommand(query, connection)) {
                try {
                    command.Parameters.Add(new MySqlParameter("@ID_NUM", user.ID_num));

                    showRecord(command);
                } catch (MySqlException sqlError){
                    MessageBox.Show("There is something wrong, Try Again!\n" + sqlError.Message);
                    throw;
                }
            }

            PrepToDelete = true;
        }

        // Delete Confirmation
        private void button2_Click(object sender, EventArgs e) {
            accountData user = new accountData();

            ConfirmDeleteForm form = new ConfirmDeleteForm(); 
            form.ShowDialog();

            if (!PrepToDelete) {
                MessageBox.Show("Please enter an ID number first to proceed!");
                return;
            }

            if (!form.confirmDelete) {
                return; //Stop the code if the bool is false
            }

            query = "DELETE FROM ACCT WHERE ID_NUM = @ID_NUM";

            using (command = new MySqlCommand(query, connection)) {
                try {
                    user.ID_num = textBox1.Text;

                    command.Parameters.Add(new MySqlParameter("@ID_NUM", user.ID_num));

                    command.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted Successfully!");

                } catch (MySqlException sqlError){
                    MessageBox.Show("There is something wrong, Try Again!\n" + sqlError.Message);
                    throw;
                }
            }
        }

        // Closes the window
        private void button3_Click(object sender, EventArgs e) {
            Close();
        }
        private string checkRecord(accountData user) {

            user.ID_num = textBox1.Text;

            if (string.IsNullOrWhiteSpace(user.ID_num) || !user.ID_num.All(char.IsDigit)) {
                MessageBox.Show("Please enter a valid ID number!");
                return null; //break the process
            }

            query = "SELECT * FROM acct WHERE ID_NUM = @ID_NUM;";

            return query;
        }

        //Generate record on DataGridView
        public void showRecord(MySqlCommand command) {
            DataTable data = new DataTable();

            using (adapter = new MySqlDataAdapter(command)) {
                try {
                    adapter.Fill(data);
                } catch (MySqlException sqlError){
                    MessageBox.Show("There is something wrong, Try Again!\n" + sqlError.Message);
                    throw;
                }
            }

            //Display the collected data into DataGridView
            dataGridView1.DataSource = data;
        }
    }
}
