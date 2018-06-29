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

        /// <summary>
        /// user login
        /// </summary>
        /// <param name="name">username</param>
        /// <param name="password">password</param>
        /// <returns>true = login successful; false = input combination wrong</returns>
        public bool Login(string name, string password)
        {
            return recipeManager.Login(name, password);
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="name">username</param>
        /// <param name="lastname">lastname</param>
        /// <param name="password">password</param>
        /// <returns>true = user created; false = input error</returns>
        public bool Register(string name, string lastname, string password)
        {
            return recipeManager.Register(name, lastname, password);
        }
    }
}
