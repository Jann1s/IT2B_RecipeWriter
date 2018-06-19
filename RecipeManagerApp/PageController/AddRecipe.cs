using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeManagerApp.Helper;

namespace RecipeManagerApp.PageController
{
    class AddRecipe
    {
        private RecipeManager recipeManager = RecipeManager.instance;
        private Recipe tempRecipe = new Recipe("placeholder", "placeholder");
        public List<Units> units { get; }
        public ObservableCollection<Ingredient> ingredients { get; }
        
        public AddRecipe()
        {
            units = recipeManager.GetUnits();
            ingredients = new ObservableCollection<Ingredient>();
        }

        public void Add(string name, string description)
        {
            tempRecipe.title = name;
            tempRecipe.description = description;
            tempRecipe.ingredients = ingredients.ToList<Ingredient>();

            recipeManager.GetCurrentUser().AddRecipe(tempRecipe);
        }
        
        public void AddIngredient(string name, float amount, Units unit)
        {
            Ingredient tempIngredient = new Ingredient();
            tempIngredient.Name = name;
            tempIngredient.Amount = amount;
            tempIngredient.Unit = unit;

            ingredients.Add(tempIngredient);
        }

        public void DeleteIngredient(int index)
        {
            if (index >= 0 && index < ingredients.Count)
            {
                ingredients.RemoveAt(index);
            }
        }

        /*
        public void Back()
        {

        }
        
        public void ShoppingList()
        {

        }

        public void Options()
        {

        }
        */
    }
}
