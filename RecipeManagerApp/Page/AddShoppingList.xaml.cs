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
    public sealed partial class AddShoppingList// : Page
    {
        PageController.AddShoppingList controller = new PageController.AddShoppingList();

        public AddShoppingList()
        {
            this.InitializeComponent();

            //init listbox
            listBox_recipeList.ItemsSource = controller.recipe;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {

            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void recipesBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RecipeList));
        }

        private void shoppingListBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ShoppingList));
        }

        private void optionsBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ExportPrint));
        }

        private void btn_saveShoppingList_Click(object sender, RoutedEventArgs e)
        {
            if (controller.Save())
            {
                Frame.Navigate(typeof(ShoppingList));
            }
            else
            {
                ShowInputError();
            }
        }

        private void btn_addShoppingList_Click(object sender, RoutedEventArgs e)
        {
            controller.Add(listBox_recipeList.SelectedIndex);
            
        }

        private void btn_deleteShoppingList_Click(object sender, RoutedEventArgs e)
        {
            controller.Delete(listBox_addedList.SelectedIndex);
        }

        private async void ShowInputError()
        {
            ContentDialog inputErrorDialog = new ContentDialog
            {
                Title = "Shopping list empty",
                Content = "Please add at least one recipe to the shopping list!",
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await inputErrorDialog.ShowAsync();
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

            if (origin == "Edit")
            {
                controller.edit = true;
                controller.SetRecipes(index);
            }
            else
            {
                controller.edit = false;
            }

            //init listbox
            listBox_addedList.ItemsSource = controller.addedRecipes;
        }
    }
}
