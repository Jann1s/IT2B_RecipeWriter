﻿using MySql.Data.MySqlClient;
using System;
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
    public sealed partial class login //: Page
    {
        public login()
        {
            this.InitializeComponent();
        }

        private void signUpBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SignUp));
        }

        private async void btn_login_ClickAsync(object sender, RoutedEventArgs e)

        {
            bool log;
            try
            {
                log = await RecipeManager.instance.LoginAsync(logInUsername_txtBox.Text, loginPassword_txtBox.Text);
            } catch (MySqlException mse)
            {
                await new MessageDialog(mse.ToString()).ShowAsync();
                log = false;
                await new MessageDialog("Invalid username or password.").ShowAsync();
            }
            if (log)
            {
                Frame.Navigate(typeof(RecipeList));
            }
        }
    }
}
