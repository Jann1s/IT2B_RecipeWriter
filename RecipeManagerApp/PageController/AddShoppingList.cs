using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagerApp.PageController
{
    class AddShoppingList
    {
        private RecipeManager recipeManager = RecipeManager.instance;
        private Helper.ShoppingList tempShoppingList;
        public ObservableCollection<Helper.Recipe> recipe { get; }
        public ObservableCollection<Helper.Recipe> addedRecipes { get; }

        public AddShoppingList()
        {
            recipe = new ObservableCollection<Helper.Recipe>(recipeManager.GetCurrentUser().recipes);
            addedRecipes = new ObservableCollection<Helper.Recipe>();
            tempShoppingList = new Helper.ShoppingList(recipeManager.GetCurrentUser().shoppingLists.Count);
        }

        public void Add(int index)
        {
            if (index >= 0 && index < recipe.Count)
            {
                tempShoppingList.AddRecipe(recipe[index]);
                tempShoppingList.date = DateTime.Now;

                addedRecipes.Add(recipe[index]);
            }
        }

        public bool Save()
        {
            if (tempShoppingList.recipes.Count > 0)
            {
                recipeManager.GetCurrentUser().AddShoppingList(tempShoppingList);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Delete(int index)
        {
            if (index >= 0 && index < addedRecipes.Count)
            {
                tempShoppingList.RemoveRecipe(addedRecipes[index]);
                addedRecipes.RemoveAt(index);
            }
        }

        /*
        public void Back()
        {

        }

        public void Options()
        {

        }
        */
    }
}