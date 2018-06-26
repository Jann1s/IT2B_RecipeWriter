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
            recipe = RecipeManagerApp.Page.login.recp;
        }
        
        public void Delete(int index)
        {
            if (index >= 0 && index < recipe.Count)
            {
                recipe.RemoveAt(index);
                recipeManager.GetCurrentUser().RemoveRecipe(index);
            }
        }

        /*
        public void Add()
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
