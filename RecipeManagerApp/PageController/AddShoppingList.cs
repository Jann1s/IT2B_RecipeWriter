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
        public ObservableCollection<Helper.Recipe> addedRecipes { get; set; }
        public bool edit { get; set; }
        private int index = -1;

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
                if (edit)
                {
                    Helper.ShoppingListDAO.DeleteShoppingList(recipeManager.GetCurrentUser().shoppingLists[index]);
                    recipeManager.GetCurrentUser().shoppingLists.RemoveAt(index);
                    recipeManager.GetCurrentUser().shoppingLists.Insert(index, tempShoppingList);

                    Helper.ShoppingListDAO.AddShoppinglistAsync(tempShoppingList, tempShoppingList.id);
                }
                else
                {
                    int result = Helper.ShoppingListDAO.AddShoppinglistAsync(tempShoppingList);

                    if (result >= 0)
                    {
                        tempShoppingList.id = result;
                    }

                    recipeManager.GetCurrentUser().AddShoppingList(tempShoppingList);
                }

                

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

        public void SetRecipes(int index)
        {
            this.index = index;
            tempShoppingList = recipeManager.GetCurrentUser().shoppingLists[index];
            addedRecipes = new ObservableCollection<Helper.Recipe>(tempShoppingList.recipes);
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