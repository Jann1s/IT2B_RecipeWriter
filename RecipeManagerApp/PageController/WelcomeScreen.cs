using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagerApp.PageController
{
    class WelcomeScreen
    {
        private RecipeManager recipeManager = RecipeManager.instance;

        public void LoginAsync(string name, string password)
        {
            recipeManager.LoginAsync(name, password);
        }

        public void RegisterAsync(string name, string password)
        {
            recipeManager.RegisterAsync(name, password);
        }
    }
}
