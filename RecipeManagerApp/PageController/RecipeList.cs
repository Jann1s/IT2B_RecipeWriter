using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using RecipeManagerApp.Helper;
using Windows.Storage;
using Windows.UI.Popups;

namespace RecipeManagerApp.PageController
{
    class RecipeList
    {
        private RecipeManager recipeManager = RecipeManager.instance;
        public  ObservableCollection<Recipe> recipe { get; set; }

        public RecipeList()
        {
            //init collection for listbox
            recipe = new ObservableCollection<Helper.Recipe>(recipeManager.GetCurrentUser().recipes);
        }
        
        /// <summary>
        /// Delete the selected recipe from User list & Database
        /// </summary>
        /// <param name="index">index of recipe</param>
        public void Delete(int index)
        {
            if (index >= 0 && index < recipe.Count)
            {
                RecipeDAO.DeleteRecipe(recipe[index]);
                recipe.RemoveAt(index);
                recipeManager.GetCurrentUser().RemoveRecipe(index);
            }
        }
    }
}
