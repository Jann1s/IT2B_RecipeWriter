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

        public void Delete(int index)
        {
            if (index >= 0 && index < shoppingList.Count)
            {
                shoppingList.RemoveAt(index);
                recipeManager.GetCurrentUser().RemoveShoppingList(index);
            }
        }

        /*
        public void Add()
        {

        }

        public void Back()
        {

        }

        public void Recipes()
        {

        }

        public void Options()
        {

        }

        public void Print()
        {

        }

        public void ExportPDF()
        {

        }
        */
    }
}
