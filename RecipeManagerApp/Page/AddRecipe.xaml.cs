using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace RecipeManagerApp.Page
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class AddRecipe// : Page
    {
        PageController.AddRecipe controller = new PageController.AddRecipe();

        public AddRecipe()
        {
            this.InitializeComponent();
            
            //init combobox
            comboBox_Unit.ItemsSource = controller.units;
            comboBox_Unit.DisplayMemberPath = "Name";

            //init listbox
            listBox_Ingredients.ItemsSource = controller.ingredients;
            listBox_Ingredients.DisplayMemberPath = "Name";
        }

        private void recipesBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RecipeList));
        }

        private void shoppingListBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ShoppingList));
        }

        private void cancelRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RecipeList));
        }

        private void btn_AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            controller.AddIngredient(textBox_ingredientName.Text, float.Parse(textBox_amount.Text), controller.units[comboBox_Unit.SelectedIndex]);
            //listBox_Ingredients.ItemsSource = controller.ingredients;
        }

        private void saveRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            controller.Add(textBox_name.Text, textBox_description.Text);
            Frame.Navigate(typeof(RecipeList));
        }

        private void btn_DeleteIngredient_Click(object sender, RoutedEventArgs e)
        {
            controller.DeleteIngredient(listBox_Ingredients.SelectedIndex);
        }

        private async void btn_addPhoto_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");

            StorageFile file = await openPicker.PickSingleFileAsync();

            if (file != null)
            {
                var brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri(file.Path, UriKind.Absolute));
                btn_addPhoto.Background = brush;
                //@TODO: NOT WORKING!
            }
            else
            {
                //OutputTextBlock.Text = "Operation cancelled.";
            }
        }
    }
}
