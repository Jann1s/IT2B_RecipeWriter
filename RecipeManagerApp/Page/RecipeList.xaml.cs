using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace RecipeManagerApp.Page
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class RecipeList// : Page
    {
        PageController.RecipeList controller = new PageController.RecipeList();

        public RecipeList()
        {
            this.InitializeComponent();

            //init listbox
            listBox_recipes.ItemsSource = controller.recipe;
            listBox_recipes.DisplayMemberPath = "title";
        }

        private void addRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddRecipe));
        }

        private void optionsBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ExportPrint));
        }

        private void shoppingListBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ShoppingList));
        }

        private void btn_deleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            controller.Delete(listBox_recipes.SelectedIndex);
        }

        private void homeBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(WelcomeScreen));
        }

        private void btn_export_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ExportPrint), "Recipe");
        }
    }
}
