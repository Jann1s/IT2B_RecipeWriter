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

        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        public void RemoveRecipe(Recipe recipe)
        {
            recipes.Remove(recipe);
        }
    }
}
