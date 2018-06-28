using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        PageController.WelcomeScreen controller = new PageController.WelcomeScreen();

        public login()
        {
            this.InitializeComponent();
        }

        

        private void signUpBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SignUp));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {

            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void btn_login_ClickAsync(object sender, RoutedEventArgs e)
        {
            bool result = controller.Login(logInUsername_txtBox.Text, loginPassword_txtBox.Password);
            if (result)
            {
                Frame.Navigate(typeof(RecipeList));
            }
            else
            {
                logInUsername_txtBox.Text = "";
                loginPassword_txtBox.Password = "";
                ShowLoginError();
            }
        }

        private async void ShowLoginError()
        {
            ContentDialog inputErrorDialog = new ContentDialog
            {
                Title = "Error",
                Content = "username and/or password wrong!",
                CloseButtonText = "Try again"
            };

            ContentDialogResult result = await inputErrorDialog.ShowAsync();
        }
    }
}
