using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagerApp.PageController
{
    class WelcomeScreen
    {
        //private RecipeManager recipeManager;

        public void Login(string name, string password)
        {
            RecipeManager.Login(name, password);
        }

        public void Register(string name, string password)
        {
            RecipeManager.Register(name, password);
        }
    }
}
