using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimRepo
{
    public class ClaimRepo
    {
        public Queue<Claim> _claims = new Queue<Claim>();
        //Create Claim
        public void AddItem(Claim item)
        {
            _claims.Enqueue(item);
        }

        //Read
        public Claim GetClaimById(int itemnumber)
        {
            foreach (Claim item in _claims)
            {
                if (item.ClaimID == itemnumber)
                {
                    return item;
                }
            }

            return null;
        }

        public Queue<Claim> GetClaims()
        {
            return _claims;
        }

        //Delete
        public bool RemoveItemFromTopOfQueue()
        {
            int initialCount = _claims.Count;
            _claims.Dequeue();
            return initialCount > _claims.Count;
        }

        //Helper Method
        public Claim GetClaimByIdNumber(int itemnumber)
        {
            foreach (Claim item in _claims)
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
