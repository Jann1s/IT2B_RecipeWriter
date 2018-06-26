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
            String query = @"INSERT INTO shoppinglist VALUES (NULL, NOW(), ";//TODO: add ids of all ingredients or recipes contained from DB
            DBConnector.initAsync();
            MySqlCommand cmd = new MySqlCommand(query, DBConnector.conn);
            cmd.ExecuteNonQuery();

            foreach(Recipe r in sl.recipes)
            {
                IngredientDAO.AddIngredient((int)cmd.LastInsertedId, r);
            }

            DBConnector.conn.Close();
            return true;

        }

        public static List<ShoppingList> GetAll(int userid)
        {
            /*
             * @TODO:!!!
            List<ShoppingList> sl = new List<ShoppingList>();
            String query = @"SELECT * FROM shoppinglist WHERE users_id = " + userid;
            DBConnector.initAsync();
            MySqlCommand cmd = new MySqlCommand(query, DBConnector.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                sl.Add(new ShoppingList(1));

            }

            return sl;
            */
            return null;
        }

    }
}
