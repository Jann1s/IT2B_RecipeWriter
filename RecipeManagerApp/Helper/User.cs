using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagerApp.Helper
{
    public class User
    {
        public int id { get; }
        public string username { get; }
        public List<ShoppingList> shoppingLists { get; }
        public List<Recipe> recipes { get; }
        public List<Recipe> favRecipes { get; }

        public User(int id, string username)
        {
            shoppingLists = new List<ShoppingList>();
            recipes = new List<Recipe>();
            favRecipes = new List<Recipe>();

            this.id = id;
            this.username = username;
        }

        //add shopping lsit to user
        public void AddShoppingList(ShoppingList shoppingList)
        {
            shoppingLists.Add(shoppingList);
        }

        //remove shopping list from user
        public void RemoveShoppingList(int index)
        {
            shoppingLists.RemoveAt(index);
        }

        public void AddAllRecipes(List<Recipe> recipes)
        {
            if (recipes != null)
            {
                foreach (Recipe rec in recipes)
                {
                    AddRecipe(rec);
                }
            }
            
        }

        public void AddAllShoppingLists(List<ShoppingList> shoppingLists)
        {
            if (shoppingLists != null)
            {
                foreach (ShoppingList shop in shoppingLists)
                {
                    AddShoppingList(shop);
                }
            }
        }

        //add recipe to user
        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        //remove recipe from user
        public void RemoveRecipe(int index)
        {
            recipes.RemoveAt(index);
        }

        public void AddFavRecipe()
        {
            //@TODO: adding fav button and option
        }
    }
}
