﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeManagerApp.Helper;

namespace RecipeManagerApp.PageController
{
    class RecipeList
    {
        private RecipeManager recipeManager = RecipeManager.instance;
        public ObservableCollection<Recipe> recipe { get; }

        public RecipeList()
        {
            recipe = new ObservableCollection<Recipe>(recipeManager.GetCurrentUser().recipes);
        }
        
        public void Delete(int index)
        {
            if (index >= 0 && index < recipe.Count)
            {
                recipe.RemoveAt(index);
            }
        }

        /*
        public void Add()
        {

        }

        public void ShoppingList()
        {

        }

        public void Options()
        {

        }
        */
    }
}
