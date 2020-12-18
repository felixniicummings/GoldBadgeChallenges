using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimRepo
{
    public class ClaimRepo
    {
        private List<Claim> _listOfClaims = new List<Claim>();
        //Create Claim
        public void AddItemToList(Claim item)
        {
            _listOfClaims.Add(item);
        }

        //Read
        public List<Claim> GetClaimItems()
        {
            return _listOfClaims;
        }

        //Update

        //Delete
        public bool RemoveItemFromList(int itemnumber)
        {
            Claim item = GetClaimByIdNumber(itemnumber);

            if (item == null)
            {
                return false;
            }

            int initialCount = _listOfClaims.Count;
            _listOfClaims.Remove(item);

            if (initialCount > _listOfClaims.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper Method
        public Claim GetClaimByIdNumber(int itemnumber)
        {
            foreach (Claim item in _listOfClaims)
            {
                if (item.ClaimID == itemnumber)
                {
                    return item;
                }
            }

            return null;
        }

    }
}
