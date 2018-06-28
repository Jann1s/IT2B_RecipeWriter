using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace RecipeManagerApp.PageController
{
    class WelcomeScreen
    {
        private RecipeManager recipeManager = RecipeManager.instance;

        public bool Login(string name, string password)
        {
            return recipeManager.Login(name, password);
        }

        public bool Register(string name, string lastname, string password)
        {
            return recipeManager.Register(name, lastname, password);
        }
    }
}
