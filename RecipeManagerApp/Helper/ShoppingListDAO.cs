﻿using MySql.Data.MySqlClient;
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

        public static int AddShoppinglistAsync(ShoppingList sl)
        {
            int usedId = 0;
            bool added = false;
            Dictionary<int, int> recipeList = new Dictionary<int, int>();


            for (int i = 0; i < sl.recipes.Count; i++)
            {
                int amountOne = 0;

                for (int y = 0; y < sl.recipes.Count; y++)
                {
                    if (sl.recipes[i].id == sl.recipes[y].id)
                    {
                        amountOne++;
                    }
                }

                if (!recipeList.ContainsKey(sl.recipes[i].id))
                {
                    recipeList.Add(sl.recipes[i].id, amountOne);
                }
            }

            foreach (KeyValuePair<int, int> item in recipeList)
            {
                if (item.Value > 0)
                {
                    string query = @"INSERT INTO shoppinglist VALUES (" + RecipeManager.instance.lastShoppingID + ", 'NOW()', " + item.Key + ", " + RecipeManager.instance.GetCurrentUser().id + ", " + item.Value + ")";
                    DBConnector.initAsync();
                    MySqlCommand cmd = new MySqlCommand(query, DBConnector.conn);
                    cmd.ExecuteNonQuery();
                    added = true;
                    DBConnector.conn.Close();
                }
            }

            if (added)
            {
                usedId = RecipeManager.instance.lastShoppingID;
                RecipeManager.instance.lastShoppingID++;
                return usedId;
            }
            else
            {
                return -1;
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

            

        }

        public static List<ShoppingList> GetAll(int userid)
        {
            List<ShoppingList> sl = new List<ShoppingList>();
            String query = @"SELECT * FROM shoppinglist WHERE user_id = '" + userid + "'";
            DBConnector.initAsync();
            MySqlCommand cmd = new MySqlCommand(query, DBConnector.conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            //sl.Add(new ShoppingList(((int)reader["idshoppinglist"])))

            while (reader.Read())
            {
                int sId = (int)reader["idshoppinglist"];
                int rId = (int)reader["recipe_id"];
                int amount = (int)reader["amount"];
                bool addRecipe = true;
                bool addShoppingList = true;
                
                for (int i = 0; i < sl.Count; i++)
                {
                    if (sl[i].id == sId)
                    {
                        addShoppingList = false;

                        for (int j = 0; j < sl[i].recipes.Count; j++)
                        {
                            if (sl[i].recipes[j].id == rId)
                            {
                                addRecipe = false;
                            }
                        }

                        if (addRecipe)
                        {
                            foreach (Recipe r in RecipeManager.instance.GetCurrentUser().recipes)
                            {
                                if (r.id == rId)
                                {
                                    for (int k = 0; k < amount; k++)
                                    {
                                        sl[sl.Count - 1].AddRecipe(r);
                                    }
                                }
                            }
                        }
                    }
                }

                if (addShoppingList)
                {
                    sl.Add(new ShoppingList((sId)));

                    foreach (Recipe r in RecipeManager.instance.GetCurrentUser().recipes)
                    {
                        if (r.id == rId)
                        {
                            for (int k = 0; k < amount; k++)
                            {
                                sl[sl.Count - 1].AddRecipe(r);
                            }
                            
                            sl[sl.Count - 1].date = DateTime.Now; //TODO: NEEDS TO BE THE DB DATE!
                        }
                    }
                }
            }

            DBConnector.conn.Close();

            String queryMax = @"SELECT MAX(idshoppinglist) AS SINDEX FROM shoppinglist";
            DBConnector.initAsync();
            MySqlCommand cmdMax = new MySqlCommand(queryMax, DBConnector.conn);
            MySqlDataReader readerMax = cmdMax.ExecuteReader();

            while (readerMax.Read())
            {
                RecipeManager.instance.lastShoppingID = (int)readerMax["SINDEX"] + 1;
            }

            return sl;
        }

    }
}
