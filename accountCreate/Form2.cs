using accountCreate.accountCredentials;
using accountCreate.connection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace accountCreate {
    public partial class Form2 : Form {
        private string query;
        private MySqlCommand command;
        private MySqlConnection connection;

        private bool proceed;

        public Form2() {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e) {
            DBConnect connect = new DBConnect();
            connection = connect.databaseConnection();
        }

        private void button1_Click(object sender, EventArgs e) {

            accountData user = new accountData();

            //Set up the created query
            query = insertRecord(user);

            using (command = new MySqlCommand(query, connection)) {
                try {
                    command.Parameters.Add(new MySqlParameter("@FIRST_NAME", user.first_name));
                    command.Parameters.Add(new MySqlParameter("@LAST_NAME", user.last_name));
                    command.Parameters.Add(new MySqlParameter("@AGE", user.age));
                    command.Parameters.Add(new MySqlParameter("@ADDRESS", user.address));
                    command.Parameters.Add(new MySqlParameter("@EMAIL", user.email));
                    command.Parameters.Add(new MySqlParameter("@CONTACT_NO", user.contact));

                    // Initiate the query
                    command.ExecuteNonQuery();
                    MessageBox.Show("Account created successfully!");

                } catch (MySqlException sqlError) {
                    MessageBox.Show("There is something wrong with the inputs or the query: \n" + sqlError.Message);
                    throw;
                }
            }
        }

        private bool validateNumInputs(accountData user) {
            // Validate if age textbox is an integer
            if (string.IsNullOrWhiteSpace(user.age) || !user.age.All(char.IsDigit)) {
                MessageBox.Show("Please enter your Age.");
                return false; // to break the process
            }

            // Validate if Contact textbox is an integer
            if (string.IsNullOrWhiteSpace(user.contact) || !user.contact.All(char.IsDigit)) {
                MessageBox.Show("Please enter a contact number.");
                return false;
            }

            return true;
        }

        private string insertRecord(accountData user) {

            user.first_name = textBox1.Text;
            user.last_name = textBox2.Text;
            user.age = textBox3.Text;
            user.address = textBox4.Text;
            user.email = textBox5.Text;
            user.contact = textBox6.Text;

            proceed = validateNumInputs(user);

            if (!proceed) {
                return null; // to break the process if number input validation fails
            }

            // if the number inputs are all valid, then proceed with validation of other details
            if (string.IsNullOrWhiteSpace(user.first_name)) {
                MessageBox.Show("Please enter a first name to create the account.");
                return null;
            } 
            
            if (string.IsNullOrWhiteSpace(user.last_name)) {
                MessageBox.Show("Please enter a last name to create the account.");
                return null;
            } 

            if (string.IsNullOrWhiteSpace(user.address)) {
                MessageBox.Show("Please enter an address to create the account.");
                return null;
            } 
                
            if (string.IsNullOrWhiteSpace(user.email)) {
                MessageBox.Show("Please enter an email to create the account.");
                return null;
            }

            query = "INSERT INTO acct (ID_NUM, FIRST_NAME, LAST_NAME, AGE, ADDRESS, EMAIL, CONTACT_NO) " +
                            "VALUES " +
                            "(FLOOR(999999999 + RAND()*(10000000000)), @FIRST_NAME, @LAST_NAME, @AGE, @ADDRESS, @EMAIL, @CONTACT_NO)";

            return query; //If all validation passes, then return true to proceed
        }

        // Close the window
        private void button2_Click(object sender, EventArgs e) {
            Close();
        }

        
    }
}
