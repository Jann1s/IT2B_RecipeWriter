﻿using System;
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
    public sealed partial class ShoppingList// : Page
    {
        PageController.ShoppingList controller = new PageController.ShoppingList();

        public ShoppingList()
        {
            this.InitializeComponent();

            //init listbox
            listBox_recipeList.ItemsSource = controller.shoppingList;
        }

        private void optionsBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ExportPrint));
        }

        private void recipesBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RecipeList));
        }

        private void btn_deleteShoppingList_Click(object sender, RoutedEventArgs e)
        {
            controller.Delete(listBox_recipeList.SelectedIndex);
        }

        private void btn_addShoppingList_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddShoppingList));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {

            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }


        private void btn_export_Click(object sender, RoutedEventArgs e)
        {
            String[] parameter = new String[] { "Shopping" , listBox_recipeList.SelectedIndex.ToString() };
            Frame.Navigate(typeof(ExportPrint), parameter);
        }

        private void listBox_recipeList_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            String[] parameter = new String[] { "Edit", listBox_recipeList.SelectedIndex.ToString() };
            Frame.Navigate(typeof(AddShoppingList), parameter);
        }
    }
}
