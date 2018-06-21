using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagerApp.Helper
{
    class IngredientDAO
    {

        public static async Task<bool> AddIngredient(int id, Recipe r)
        {
           foreach (Ingredient i in r.ingredients)
            {
                String query = @"INSERT INTO ingredients VALUES (NULL, '" + i.Name + "', " + i.Amount + " , '" + i.Unit.Name + "' , " + id + ");";
                await DBConnector.initAsync();
                MySqlCommand cmd = new MySqlCommand(query, DBConnector.conn);
                cmd.ExecuteNonQuery();
                DBConnector.conn.Close();
            }
            return true;

        }

        //public static async Task<ObservableCollection<Ingredient>> GetAll(int recipeid)
        //{
        //    ObservableCollection<Ingredient> r = new ObservableCollection<Ingredient>();
        //    String query = @"SELECT * FROM ingredients WHERE recipes_idrecipes = " + recipeid;
        //    await DBConnector.initAsync();
        //    MySqlCommand cmd = new MySqlCommand(query, DBConnector.conn);
        //    MySqlDataReader reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        r.Add(new Ingredient(reader["description"] + "", reader["title"] + ""));
        //    }

        //    return r;
        //}
    }
}
