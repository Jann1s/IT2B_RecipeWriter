using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagerApp.Helper
{
    public class Ingredient
    {
        public string Name { get; set; }
        public float Amount { get; set; }
        public Units Unit { get; set; }
    }
}
