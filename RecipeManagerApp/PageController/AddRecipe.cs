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
        public ObservableCollection<Ingredient> ingredients { get; set; }
        public bool edit { get; set; }
        private int index = -1;
        
        public AddRecipe()
        {
            //init list & collection
            units = recipeManager.GetUnits();
            ingredients = new ObservableCollection<Ingredient>();
        }

        /// <summary>
        /// This will check if the input of the controls are correct. After this it will determine if the user
        /// edit an existing Recipe or is creating a new one and will add / "update" (delete and add) it to
        /// the specified database.
        /// </summary>
        /// <param name="name">Name / Title of the recipe</param>
        /// <param name="description">Description of the recipe</param>
        /// <returns>true = added the recipe to the database; false = input incorrect</returns>
        public bool AddDB(string name, string description)
        {
            if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(description) && ingredients.Count > 0)
            {
                tempRecipe.title = name;
                tempRecipe.description = description;
                tempRecipe.ingredients = ingredients;

                if (edit)
                {
                    RecipeDAO.DeleteRecipe(recipeManager.GetCurrentUser().recipes[index]);
                    tempRecipe.id = recipeManager.GetCurrentUser().recipes[index].id;
                    recipeManager.GetCurrentUser().recipes.RemoveAt(index);
                    recipeManager.GetCurrentUser().recipes.Insert(index, tempRecipe);

                    RecipeDAO.AddRecipeAsync(tempRecipe, tempRecipe.id);
                }
                else
                {
                    int result = RecipeDAO.AddRecipeAsync(tempRecipe);

                    if (result >= 0)
                    {
                        tempRecipe.id = result;
                    }

                    //Add it to running instance
                    recipeManager.GetCurrentUser().AddRecipe(tempRecipe);
                }
                
                return true;
            }
            else
            {
                return false;
            } 
        }
        
        /// <summary>
        /// Adds ingredients to the recipe
        /// </summary>
        /// <param name="name">Name of the ingredient</param>
        /// <param name="sAmount">Amount of the ingredient</param>
        /// <param name="index">index of the used unit</param>
        /// <returns>true = added ingridient; false = input incorrect</returns>
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

        /// <summary>
        /// Deletes the specified ingredient
        /// </summary>
        /// <param name="index">Index of the ingredient</param>
        public void DeleteIngredient(int index)
        {
            if (index >= 0 && index < ingredients.Count)
            {
                ingredients.RemoveAt(index);
            }
        }

        /// <summary>
        /// This will add all existing ingredients to the temporary recipe.
        /// Only used for editing page.
        /// </summary>
        /// <param name="index">index of the recipe that will be edit</param>
        public void SetIngredients(int index)
        {
            this.index = index;
            ingredients = recipeManager.GetCurrentUser().recipes[index].ingredients;
        }
    }
}
