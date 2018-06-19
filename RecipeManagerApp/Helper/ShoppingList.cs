using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagerApp.Helper
{
    public class ShoppingList
    {
        public List<Recipe> recipes { get; set; }
        public int id { get; }
        public DateTime date { get; set; }

        public ShoppingList(int id)
        {
            this.id = id;
        }

        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }
    }
}
