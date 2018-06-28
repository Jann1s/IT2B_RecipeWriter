using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagerApp.Helper
{
    class ShoppingListDAO
    {

        public static bool AddShoppinglistAsync(ShoppingList sl)
        {
            foreach (Recipe r in sl.recipes)
            {
                string query = @"INSERT INTO shoppinglist VALUES ('NULL', 'NOW()', '" + r.id + "'";
                DBConnector.initAsync();
                MySqlCommand cmd = new MySqlCommand(query, DBConnector.conn);
                cmd.ExecuteNonQuery();
            }

            /*
            String query = @"INSERT INTO shoppinglist VALUES ('NULL', 'NOW()', ''";
            DBConnector.initAsync();
            MySqlCommand cmd = new MySqlCommand(query, DBConnector.conn);
            cmd.ExecuteNonQuery();
            

            foreach(Recipe r in sl.recipes)
            {
                IngredientDAO.AddIngredient((int)cmd.LastInsertedId, r);
            }
            */

            DBConnector.conn.Close();
            return true;

        }

        public static List<ShoppingList> GetAll(int shoppingid)
        {
            //have to use userid to get recipes and get recipe id 
            List<ShoppingList> sl = new List<ShoppingList>();
            String query = @"SELECT * FROM shoppinglist WHERE idshoppinglist = " + shoppingid;
            DBConnector.initAsync();
            MySqlCommand cmd = new MySqlCommand(query, DBConnector.conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            sl.Add(new ShoppingList(((int)reader["idshoppinglist"])))

            while (reader.Read())
            {
                sl.Add(new ShoppingList(((int)reader["idshoppinglist"])));
            }

            return sl;
        }

    }
}
