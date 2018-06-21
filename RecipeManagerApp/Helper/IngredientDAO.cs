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
                        i.Unit.Unit = EUnit.Liter;
                        i.Unit.Short = "L";
                        i.Unit.Name = "Liter";
                        r.Add(i);
                        break;
                    case "Pieces":
                        i.Unit.Unit = EUnit.Pieces;
                        i.Unit.Short = "P";
                        i.Unit.Name = "Pieces";
                        r.Add(i);
                        break;
                    case "Spoons":
                        i.Unit.Unit = EUnit.Spoons;
                        i.Unit.Short = "SP";
                        i.Unit.Name = "Spoons";
                        r.Add(i);
                        break;
                    case "Mililiter":
                        i.Unit.Unit = EUnit.Milliliter;
                        i.Unit.Short = "ml";
                        i.Unit.Name = "Mililiter";
                        r.Add(i);
                        break;
                    case "Kilogramm":
                        i.Unit.Unit = EUnit.Kilogramm;
                        i.Unit.Short = "KG";
                        i.Unit.Name = "Kilogramm";
                        r.Add(i);
                        break;
                    case "Gram":
                        i.Unit.Unit = EUnit.Gramm;
                        i.Unit.Short = "G";
                        i.Unit.Name = "Gramm";
                        r.Add(i);
                        break;
                    case "Miligram":
                        i.Unit.Unit = EUnit.Milligramm;
                        i.Unit.Short = "MG";
                        i.Unit.Name = "Miligram";
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
