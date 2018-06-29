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

        }

        /// <summary>
        /// set the listbox with recipes
        /// </summary>
        /// <param name="index">index of shoppinglist</param>
        public void FillRecipe(int index)
        {
            shoppingList = new ObservableCollection<Helper.Recipe>(recipeManager.GetCurrentUser().shoppingLists[index].recipes);
        }

        /// <summary>
        /// set the listbox with ingredients
        /// </summary>
        /// <param name="index">index of recipe</param>
        public void FillIngredients(int index)
        {
            recipeList = new ObservableCollection<Helper.Ingredient>(recipeManager.GetCurrentUser().recipes[index].ingredients);
        }
    }
}
