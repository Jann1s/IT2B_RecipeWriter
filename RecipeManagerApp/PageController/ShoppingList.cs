using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagerApp.PageController
{
    class ShoppingList
    {
        private RecipeManager recipeManager = RecipeManager.instance;
        public ObservableCollection<Helper.ShoppingList> shoppingList { get; }
        //private PDFProcessor pdfProcessor;    //@TODO: !

        public ShoppingList()
        {
            shoppingList = new ObservableCollection<Helper.ShoppingList>(recipeManager.GetCurrentUser().shoppingLists);
        }

        /// <summary>
        /// Delete the selected shoppinglist from User list & Database
        /// </summary>
        /// <param name="index">index of shoppinglist</param>
        public void Delete(int index)
        {
            if (index >= 0 && index < shoppingList.Count)
            {
                Helper.ShoppingListDAO.DeleteShoppingList(shoppingList[index]);
                shoppingList.RemoveAt(index);
                recipeManager.GetCurrentUser().RemoveShoppingList(index);
            }
        }
    }
}
