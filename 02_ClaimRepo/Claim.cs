using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimRepo
{
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }
    //POCO
    public class Claim
    {
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public Double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claim() { }

        public Claim(int claimid, ClaimType typeofclaim, string description, Double claimamount, DateTime dateofincident, DateTime dateofclaim, bool isvalid)
        {
            ClaimID = claimid;
            TypeOfClaim = typeofclaim;
            Description = description;
            ClaimAmount = claimamount;
            DateOfIncident = dateofincident;
            DateOfClaim = dateofclaim;
            IsValid = isvalid;
        }

    }
}
