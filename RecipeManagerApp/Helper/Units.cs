using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagerApp.Helper
{
    public class Units
    {
        public Units(String name, String Short, EUnit unit)
        {
            this.Name = Name;
            this.Short = Short;
            this.Unit = unit;
        }

        public Units()
        {

        }
        public string Name { get; set; }
        public string Short { get; set; }
        public EUnit Unit { get; set; }
    }
}
