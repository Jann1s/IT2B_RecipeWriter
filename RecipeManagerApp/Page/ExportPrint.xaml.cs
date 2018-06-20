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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RecipeManagerApp.Page
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ExportPrint //: Page
    {
        PageController.ExportPrint controller = new PageController.ExportPrint();

        public ExportPrint()
        {
            this.InitializeComponent();

            //init listbox
            /*
            if (origin == "Recipe")
            {
                listBox_shoppingList.ItemsSource = controller.recipeList;
                listBox_shoppingList.DisplayMemberPath = "title";
            }
            else if (origin == "Shopping")
            {
                listBox_shoppingList.ItemsSource = controller.shoppingList;
                listBox_shoppingList.DisplayMemberPath = "date";
            }*/
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            String origin = String.Empty;
            int index = -1;

            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                origin = ((String[])e.Parameter)[0];
                index = int.Parse(((String[])e.Parameter)[1]);
            }

            if (origin == "Recipe")
            {
                controller.FillIngredients(index);
                listBox_ingredientList.ItemsSource = controller.recipeList;
                listBox_ingredientList.Visibility = Visibility.Visible;
            }
            else if (origin == "Shopping")
            {
                controller.FillRecipe(index);
                listBox_recipeList.ItemsSource = controller.shoppingList;
                listBox_recipeList.Visibility = Visibility.Visible;
            }
        }

        private void recipesBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RecipeList));
        }

        private void shoppingListBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ShoppingList));
        }

        private void homeBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(WelcomeScreen));
        }
    }
}
