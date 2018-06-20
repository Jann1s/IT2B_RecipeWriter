﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeManagerApp.Helper;

namespace RecipeManagerApp
{
    public class RecipeManager
    {
        public static RecipeManager instance { get; set; }
        private User currentUser;
        private List<Units> units;

        public RecipeManager()
        {
            //instance = (RecipeManager)Activator.CreateInstance(typeof(RecipeManager));

            currentUser = new User(1, "Bob");
            units = new List<Units>();

            units.Add(new Units() { Name = "Milligramm", Short = "mg", Unit = EUnit.Milligramm });
            units.Add(new Units() { Name = "Gramm", Short = "g", Unit = EUnit.Gramm });
            units.Add(new Units() { Name = "Kilogramm", Short = "kg", Unit = EUnit.Kilogramm });
            units.Add(new Units() { Name = "Milliliter", Short = "ml", Unit = EUnit.Milliliter });
            units.Add(new Units() { Name = "Liter", Short = "l", Unit = EUnit.Liter });
            units.Add(new Units() { Name = "Pieces", Short = "Pcs.", Unit = EUnit.Pieces });
            units.Add(new Units() { Name = "Spoons", Short = "Spns.", Unit = EUnit.Spoons });

            Recipe recipe1 = new Recipe("This is an awesome description! WOw. just awesome", "Awesome-O");
            recipe1.AddIngredient(new Ingredient() { Name = "Eggs", Amount = 2, Unit = units[5] });

            Recipe recipe2 = new Recipe("And for the second time: This is an awesome description! WOw. just awesome", "Pizza");
            recipe2.AddIngredient(new Ingredient() { Name = "pizza", Amount = 1, Unit = units[5] });

            currentUser.AddRecipe(recipe1);
            currentUser.AddRecipe(recipe2);
        }

        public void Login(string name, string password)
        {

        }

        public void Register(string name, string password)
        {

        }

        public User GetCurrentUser()
        {
            return currentUser;
        }

        public List<Units> GetUnits()
        {
            return units;
        }
    }
}
