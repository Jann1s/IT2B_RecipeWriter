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

        public async Task LoginAsync(string name, string password)
        {
            //await RecipeManager.LoginAsync(name, password);
        }

        public async Task RegisterAsync(string name, string password)
        {
            await recipeManager.RegisterAsync(name, password);
        }
    }
}
