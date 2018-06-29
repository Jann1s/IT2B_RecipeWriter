using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagerApp.Helper
{
    /**
     * Ingredients class will contain
     * a name - String
     * amount - float
     * unit - an enum that will determine the unit that the amount will be counted in
     * */
    public class Ingredient
    {
        public string Name { get; set; }
        public float Amount { get; set; }
        public Units Unit { get; set; }
    }
}
