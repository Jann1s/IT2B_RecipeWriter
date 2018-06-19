using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagerApp.Helper
{
    public class Recipe
    {
        public string description { get; set; }
        public List<Ingredient> ingredients { get; set; }
        public string title { get; set; }

        public Recipe(string description, string title)
        {
            this.description = description;
            this.title = title;
        }

        public void AddIngredient(Ingredient ingredient)
        {
            ingredients.Add(ingredient);
        }
    }
}
