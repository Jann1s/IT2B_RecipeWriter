using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeManagerApp.Helper;

namespace RecipeManagerApp.PageController
{
    class RecipeList
    {
        private RecipeManager recipeManager = RecipeManager.instance;
        public ObservableCollection<Recipe> recipe { get; }

        public RecipeList()
        {
            recipe = new ObservableCollection<Recipe>(recipeManager.GetCurrentUser().recipes);
        }

        public void Add()
        {

        }

        public void Delete()
        {

        }

        public void ShoppingList()
        {

        }

        public void Options()
        {

        }
    }
}
