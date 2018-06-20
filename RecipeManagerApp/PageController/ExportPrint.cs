using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagerApp.PageController
{
    class ExportPrint
    {
        private RecipeManager recipeManager = RecipeManager.instance;
        public ObservableCollection<Helper.ShoppingList> shoppingList { get; }
        public ObservableCollection<Helper.Recipe> recipeList { get; }
        //private PDFProcessor pdfProcessor;    //@TODO: !

        public ExportPrint()
        {
            shoppingList = new ObservableCollection<Helper.ShoppingList>(recipeManager.GetCurrentUser().shoppingLists);
            recipeList = new ObservableCollection<Helper.Recipe>(recipeManager.GetCurrentUser().recipes);
        }
    }
}
