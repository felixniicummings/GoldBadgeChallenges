using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeClassRepo
{
    public class MenuItemRepo
    {
        private List<MenuItem> _listOfMenuItems = new List<MenuItem>();

        //Create
        public void AddItemToList(MenuItem item)
        {
            _listOfMenuItems.Add(item);
        }

        //Read
        public List<MenuItem> GetMenuItems()
        {
            return _listOfMenuItems;
        }

        //Update

        //Delete
        public bool RemoveItemFromList(int itemnumber)
        {
            MenuItem item = GetMenuItemByNumber(itemnumber);

            if(item == null)
            {
                return false;
            }

            int initialCount = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(item);

            if(initialCount > _listOfMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        //Helper Method
        public MenuItem GetMenuItemByNumber(int itemnumber )
        {
            foreach (MenuItem item in _listOfMenuItems)
            {
                if(item.MenuItemNumber == itemnumber)
                {
                    return item;
                }
            }

            return null;
        }

    }
}
