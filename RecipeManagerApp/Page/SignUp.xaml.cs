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
    public sealed partial class SignUp //: Page
    {
        PageController.WelcomeScreen controller = new PageController.WelcomeScreen();

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
            if (!String.IsNullOrEmpty(firstName_txtbox.Text) && !String.IsNullOrEmpty(lastName_txtbox.Text) && !String.IsNullOrEmpty(password_txtBox.Password))
            {
                bool result = controller.Register(firstName_txtbox.Text, lastName_txtbox.Text, password_txtBox.Password);
                if (result)
                {
                    ShowSuccessMessage();
                }
            }
            else
            {
                ShowInputError();
            }
        }

        private async void ShowInputError()
        {
            ContentDialog inputErrorDialog = new ContentDialog
            {
                Title = "Error",
                Content = "Please fill in all boxes!",
                CloseButtonText = "Try again"
            };

            ContentDialogResult result = await inputErrorDialog.ShowAsync();
        }

        private async void ShowSuccessMessage()
        {
            ContentDialog inputErrorDialog = new ContentDialog
            {
                Title = "Success",
                Content = "Your account is now registered. Please login.",
                CloseButtonText = "Login now."
            };

            ContentDialogResult result = await inputErrorDialog.ShowAsync();

            if (result == ContentDialogResult.None)
            {
                Frame.Navigate(typeof(login));
            }
        }
    }
}
