using MySql.Data.MySqlClient;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Data;
using accountCreate.connection;
using accountCreate.accountCredentials;

namespace accountCreate {
    public partial class Form1 : Form {

        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private string query;

        private bool proceed;

        public Form1() {
            InitializeComponent();
        }

        // Pre-connection setup
        private void Form1_Load(object sender, EventArgs e) {
            DBConnect connect = new DBConnect();
            connection = connect.databaseConnection();
        }

        // Create the specific data in the table
        private void button1_Click(object sender, EventArgs e) {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        // Read the Table specific Data
        private void button2_Click(object sender, EventArgs e) {

            accountData user = new accountData();

            //proceed = validateInputs(user);

            //if (!proceed) {
            //    return; // break the process if validation fails
            //}

            user.ID_num = textBox1.Text;
            user.last_name = textBox2.Text;
            user.email = textBox3.Text;
            user.contact = textBox4.Text;

            query = "SELECT * FROM acct " +
                    "WHERE ID_NUM = @ID_NUM " +
                    "OR LAST_NAME = @LAST_NAME " +
                    "OR EMAIL = @EMAIL " +
                    "OR CONTACT_NO = @CONTACT_NO";

            using (command = new MySqlCommand(query, connection)) {
                try {

                    command.Parameters.Add(new MySqlParameter("@ID_NUM", user.ID_num));
                    command.Parameters.Add(new MySqlParameter("@LAST_NAME", user.last_name));
                    command.Parameters.Add(new MySqlParameter("@EMAIL", user.email));
                    command.Parameters.Add(new MySqlParameter("@CONTACT_NO", user.contact));

                    LoadDataGridView(command);

                } catch (MySqlException sqlError) {
                    MessageBox.Show("An error occurred while executing the query: \n" + sqlError.Message);
                    throw;
                }
            }
        }

        // Update the specific data in the table
        private void button3_Click(object sender, EventArgs e) {
            Form3 form3 = new Form3();
            form3.ShowDialog();
            //Open Update Window
        }

        // Delete the specific data in the table
        private void button4_Click(object sender, EventArgs e) {
            Form4 form4 = new Form4();
            form4.ShowDialog();
            //Open Delete Window
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            LoadDataGridView(command);
        }

        // Show database tables and data within in the DataGridView UI
        private void LoadDataGridView(MySqlCommand cmd) {

            DataTable DBdata = new DataTable();

            try {
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(DBdata);
            } catch (MySqlException sqlError) {
                MessageBox.Show("An error occurred while loading the data from the database => \n" + sqlError);
                throw;
            }

            dataGridView1.DataSource = DBdata;
        }

        //private bool validateInputs(accountData user) {

        //    // Set proceed to false by default, and only set it to true if all validations pass
        //    proceed = false;

        //    user.ID_num = textBox1.Text;
        //    user.last_name = textBox2.Text;
        //    user.email = textBox3.Text;
        //    user.contact = textBox4.Text;

        //    //Validate ID textbox is an integer
        //    if (string.IsNullOrWhiteSpace(user.ID_num) || !user.ID_num.All(char.IsDigit)) {
        //        MessageBox.Show("Please enter valid ID number to filter the data.");
        //        return false; //break the process
        //    } 

        //    // Validate if Contact textbox is an integer
        //    if (string.IsNullOrWhiteSpace(user.contact) || !user.contact.All(char.IsDigit)) {
        //        MessageBox.Show("Please enter a contact number to filter the data.");
        //        return false;
        //    } 

        //    //Validation of Last name and Email
        //    if (string.IsNullOrWhiteSpace(user.last_name)) {
        //        MessageBox.Show("Please enter a last name to filter the data.");
        //        return false; 
        //    } 
            
        //    if (string.IsNullOrWhiteSpace(user.email)) {
        //        MessageBox.Show("Please enter an email to filter the data.");
        //        return false; 
        //    }
        
        //    return true;
        //}
    }
}
