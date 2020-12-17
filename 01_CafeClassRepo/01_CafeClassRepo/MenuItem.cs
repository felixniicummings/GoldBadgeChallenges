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
        //public List<string> ListOfIngredients { get; set; } = new List<string>();
        public Double Price { get; set; }

        public MenuItem() { }

        //public MenuItem(int menuitemnumber, string name, string description, List<string> listofingredients, Double price)

        public MenuItem(int menuitemnumber, string name, string description,Double price)
        {
            MenuItemNumber = menuitemnumber;
            Name = name;
            Description = description;
            //ListOfIngredients = listofingredients;
            Price = price;
        }


    }
}
