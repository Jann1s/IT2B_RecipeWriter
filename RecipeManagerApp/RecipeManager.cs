using System;
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

            units.Add(new Units() { Name = "Milligramm", Unit = EUnit.Milligramm });
            units.Add(new Units() { Name = "Gramm", Unit = EUnit.Gramm });
            units.Add(new Units() { Name = "Kilogramm", Unit = EUnit.Kilogramm });
            units.Add(new Units() { Name = "Milliliter", Unit = EUnit.Milliliter });
            units.Add(new Units() { Name = "Liter", Unit = EUnit.Liter });
            units.Add(new Units() { Name = "Pieces", Unit = EUnit.Pieces });
            units.Add(new Units() { Name = "Spoons", Unit = EUnit.Spoons });
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
