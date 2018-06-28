using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagerApp.Helper
{
    class UserDAO
    {

        public static bool addUser(string username, string lastname, string password)
        {
            string query = @"INSERT INTO users VALUES (NULL, '" + username + "', '" + password + "', '" + lastname + "');";
            DBConnector.initAsync();
            MySqlCommand cmd = new MySqlCommand(query, DBConnector.conn);
            cmd.ExecuteNonQuery();
            DBConnector.conn.Close();
            return true;
        }

        public static User getUser(string username, string password)
        {
            User user = null;
            string query = @"SELECT * FROM users WHERE username = '" + username + "' AND password = '" + password + "'";
            DBConnector.initAsync();
            MySqlCommand cmd = new MySqlCommand(query, DBConnector.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                user = new User(int.Parse(reader["id"] + "") , reader["username"] + "");
            }

            return user;
        }

    }
}
