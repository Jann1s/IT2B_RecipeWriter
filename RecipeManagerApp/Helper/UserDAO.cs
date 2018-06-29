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
        /**
         * Add new user
         * @Param username - username
         * @Param lastname - lastname of user
         * @Param password - password of user
         * */
        public static bool addUser(string username, string lastname, string password)
        {
            string query = @"INSERT INTO users VALUES (NULL, '" + username + "', '" + password + "', '" + lastname + "');";
            DBConnector.initAsync();
            MySqlCommand cmd = new MySqlCommand(query, DBConnector.conn);
            cmd.ExecuteNonQuery();
            DBConnector.conn.Close();
            return true;
        }

        /**
         * get user by username and pass
         * */
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
