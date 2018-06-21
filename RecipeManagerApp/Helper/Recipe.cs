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
        public int id { get; set; }
        public List<Ingredient> ingredients { get; set; }
        public string title { get; set; }

        public Recipe(int id,string description, string title)
        {
            this.id = id;
            this.description = description;
            this.title = title;
            ingredients = new List<Ingredient>();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            ingredients.Add(ingredient);
        }
    }
}
