using accountCreate.accountCredentials;
using accountCreate.connection;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace accountCreate {
    public partial class Form3 : Form {
        private MySqlConnection connection;
        private MySqlCommand command;

        private string query;
        private bool proceed;

        public Form3() {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e) {
            DBConnect connect = new DBConnect();
            connection = connect.databaseConnection();
        }

        private void button1_Click(object sender, EventArgs e) {
            accountData user = new accountData();

            // Initiate the validator methods
            
            //Set up the created query
            query = updateRecords(user);
            
            using (command = new MySqlCommand(query, connection)) {
                try {
                    command.Parameters.Add(new MySqlParameter("@ID_NUM", user.ID_num));
                    command.Parameters.Add(new MySqlParameter("@FIRST_NAME", user.first_name));
                    command.Parameters.Add(new MySqlParameter("@LAST_NAME", user.last_name));
                    command.Parameters.Add(new MySqlParameter("@AGE", user.age));
                    command.Parameters.Add(new MySqlParameter("@ADDRESS", user.address));
                    command.Parameters.Add(new MySqlParameter("@EMAIL", user.email));
                    command.Parameters.Add(new MySqlParameter("@CONTACT_NO", user.contact));

                    MessageBox.Show("Data Updated! \nRows Affected: " + command.ExecuteNonQuery());

                } catch (MySqlException sqlError) {
                    MessageBox.Show("There is something wrong with the query: \n" + sqlError.Message);
                    throw;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            Close();
        }

        private bool validateNumberInputs(accountData user) {

            user.ID_num = textBox1.Text;
            user.first_name = textBox2.Text;
            user.last_name = textBox3.Text;
            user.age = textBox4.Text;
            user.address = textBox5.Text;
            user.email = textBox6.Text;
            user.contact = textBox7.Text;

            //Validate the TextBox for ID is an integer
            if (string.IsNullOrWhiteSpace(user.ID_num) || !user.ID_num.All(char.IsDigit)) {
                MessageBox.Show("Please enter a valid ID number");
                return false; //break the process
            } 

            if (!user.age.All(char.IsDigit)) {
                MessageBox.Show("Please enter a valid Age");
                return false; //break the process
            }

            if (!user.contact.All(char.IsDigit)) {
                MessageBox.Show("Please enter a valid contact number");
                return false; //break the process
            }

            return true;
        }

        private string updateRecords(accountData user) {

            List<string> setUpdateColumns = new List<string>();

            proceed = validateNumberInputs(user);
            if (!proceed) {
                return null; // to break the process if number input validation fails
            }

            // if the number inputs are all valid, then proceed with validation of other details
            //Whole Validation starts
            if (!string.IsNullOrWhiteSpace(user.first_name)) {
                setUpdateColumns.Add(" FIRST_NAME = @FIRST_NAME ");
            } 
            
            if (!string.IsNullOrWhiteSpace(user.last_name)) {
                setUpdateColumns.Add(" LAST_NAME = @LAST_NAME");
            } 
            
            if (!string.IsNullOrWhiteSpace(user.age)) {
                setUpdateColumns.Add(" AGE = @AGE ");
            } 
            
            if (!string.IsNullOrWhiteSpace(user.address)) {
                setUpdateColumns.Add(" ADDRESS = @ADDRESS ");
            } 
            
            if (!string.IsNullOrWhiteSpace(user.email)) {
                setUpdateColumns.Add(" EMAIL = @EMAIL ");
            } 
            
            if (!string.IsNullOrWhiteSpace(user.contact)) {
                setUpdateColumns.Add(" CONTACT_NO = @CONTACT_NO ");
            } 
            
            if (setUpdateColumns.Count == 0){
                MessageBox.Show("Enter at least 1 on what you want to update!");
                return null;
            }

            query = "UPDATE acct SET " + string.Join(", ", setUpdateColumns) + " WHERE ID_NUM = @ID_NUM";

            return query;

        }

    }
}
