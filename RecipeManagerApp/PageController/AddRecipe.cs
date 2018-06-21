using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using RecipeManagerApp.Helper;
using Windows.Storage;
using Windows.Storage.Streams;

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

        public async Task<bool> AddAsync(string name, string description)
        {
            if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(description) && ingredients.Count > 0)
            {
                tempRecipe.title = name;
                tempRecipe.description = description;
                tempRecipe.ingredients = ingredients.ToList<Ingredient>();

               

                recipeManager.GetCurrentUser().AddRecipe(tempRecipe);

                await RecipeDAO.AddRecipeAsync(tempRecipe);

                return true;
            }
            else
            {
                return false;
            } 
        }

        
        
        public bool AddIngredient(string name, string sAmount, int index)
        {
            float amount = -1;

            if (!String.IsNullOrEmpty(name) && float.TryParse(sAmount, out amount) && index >= 0 && index < units.Count)
            {
                Ingredient tempIngredient = new Ingredient();
                tempIngredient.Name = name;
                tempIngredient.Amount = amount;
                tempIngredient.Unit = units[index];

                ingredients.Add(tempIngredient);

                return true;
            }
            else
            {
                return false;
            }
            
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
