using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace accountCreate.connection {
    internal class DBConnect {
        MySqlConnection connection;
        public MySqlConnection databaseConnection() {
            const string connectionString = "Server=localhost;Database=accounts;Uid=root;Pwd=;";

            try {
                connection = new MySqlConnection(connectionString);
                connection.Open();
            } catch (MySqlException sqlError) {
                MessageBox.Show("An error occurred while connecting to the database");
                throw sqlError;
            }

            return connection;
        }
    }
}
