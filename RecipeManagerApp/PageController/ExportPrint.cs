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
        public ObservableCollection<Helper.Recipe> shoppingList { get; set; }
        public ObservableCollection<Helper.Ingredient> recipeList { get; set; }
        //private PDFProcessor pdfProcessor;    //@TODO: !

        public ExportPrint()
        {
            //shoppingList = new ObservableCollection<Helper.ShoppingList>(recipeManager.GetCurrentUser().shoppingLists);
            //recipeList = new ObservableCollection<Helper.Recipe>(recipeManager.GetCurrentUser().recipes);
        }

        public void FillRecipe(int index)
        {
            shoppingList = new ObservableCollection<Helper.Recipe>(recipeManager.GetCurrentUser().shoppingLists[index].recipes);
        }

        public void FillIngredients(int index)
        {
            recipeList = new ObservableCollection<Helper.Ingredient>(recipeManager.GetCurrentUser().recipes[index].ingredients);
        }
    }
}
