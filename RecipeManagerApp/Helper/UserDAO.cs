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

        public static async Task<bool> addUser(String username, String password)
        {
            String query = @"INSERT INTO users VALUES (NULL, '" + username + "', '" + password + "');";
            await DBConnector.initAsync();
            MySqlCommand cmd = new MySqlCommand(query, DBConnector.conn);
            cmd.ExecuteNonQuery();
            DBConnector.conn.Close();
            return true;

        }

        public static async Task<User> getUser(String username, String password)
        {
            User user = null;
            String query = @"SELECT * FROM Users WHERE username = '" + username + "' AND password = '" + password + "'";
            await DBConnector.initAsync();
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
