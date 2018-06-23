using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

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

        public static async Task<ObservableCollection<Ingredient>> GetAll(int recipeid)
        {
            ObservableCollection<Ingredient> r = new ObservableCollection<Ingredient>();
            String query = @"SELECT * FROM ingredients WHERE recipes_idrecipes = " + recipeid;
            await DBConnector.initAsync();
            MySqlCommand cmd = new MySqlCommand(query, DBConnector.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Ingredient i = new Ingredient();
                i.Name = reader["name"] + "";
                i.Amount = int.Parse(reader["amount"] + "");
                String units = reader["unit"] + "";
    
                switch (units)
                {
                    case "Liter":
                        i.Unit = new Units() { Name = "Liter", Short = "L", Unit = EUnit.Liter };
                        r.Add(i);
                        break;
                    case "Pieces":
                        i.Unit = new Units() { Name = "Pieces", Short = "P.", Unit = EUnit.Pieces };
                        r.Add(i);
                        break;
                    case "Spoons":
                        i.Unit = new Units() { Name = "Spoons", Short = "Spns.", Unit = EUnit.Spoons };
                        r.Add(i);
                        break;
                    case "Mililiter":
                        i.Unit = new Units() { Name = "Mililiter", Short = "ml", Unit = EUnit.Spoons };
                        r.Add(i);
                        break;
                    case "Kilogramm":
                        i.Unit = new Units() { Name = "Kilogramm", Short = "kg", Unit = EUnit.Kilogramm };
                        r.Add(i);
                        break;
                    case "Gram":
                        i.Unit = new Units() { Name = "Gramm", Short = "G", Unit = EUnit.Gramm };
                        r.Add(i);
                        break;
                    case "Miligram":
                        i.Unit = new Units() { Name = "Miligram", Short = "mg", Unit = EUnit.Milligramm };
                        r.Add(i);
                        break;

                    default:
                        break;
                }
            }

            return r;
        }
    }
}
