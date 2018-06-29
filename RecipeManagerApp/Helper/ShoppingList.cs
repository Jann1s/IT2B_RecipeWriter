using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagerApp.Helper
{
    public class ShoppingList
    {
        public List<Recipe> recipes { get; }
        public int id { get; set; }
        public DateTime date { get; set; }

        public ShoppingList(int id)
        {
            this.id = id;
            recipes = new List<Recipe>();
        }

        //add a recipe to the shopping list
        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        //remove recipe from the shopping list
        public void RemoveRecipe(Recipe recipe)
        {
            recipes.Remove(recipe);
        }
    }
}
