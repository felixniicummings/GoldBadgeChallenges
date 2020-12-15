using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeClassRepo
{
    //POCO
    public class MenuItem
    {
        public int MenuItemNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> ListOfIngredients { get; set; } = new List<string>();
        public Double Price { get; set; }

        public MenuItem() { }

    }
}
