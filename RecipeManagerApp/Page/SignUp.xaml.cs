﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class SignUp //: Page
    {
        public SignUp()
        {
            this.InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(login));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {

            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            /*
            bool reg = false;
            try
            {
                reg = RecipeManager.instance.RegisterAsync(firstName_txtbox.Text, password_txtBox.Password);
            } catch (MySqlException mse)
            {
                //@TODO: await new MessageDialog("Error registering").ShowAsync();
            }
            if (reg)
            {
                //@TODO: await new MessageDialog("User registered").ShowAsync();
                Frame.Navigate(typeof(login));
            }
            */
        }
    }
}
