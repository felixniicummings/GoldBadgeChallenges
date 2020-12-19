using _02_ClaimRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimConsole
{
    class ProgramUI
    {
        private ClaimRepo _claimRepo = new ClaimRepo();

        //private MenuItemRepo _menuItemRepo = new MenuItemRepo();
        public void Run()
        {
            SeedData();
            Menu();
        }

        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display our options to the user
                Console.WriteLine("Please select an option to continue.\n" +
                    "1. View Claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Add New Claim\n" +
                    "4. Exit");
                //Get the use's input
                string input = Console.ReadLine();

                //Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        //View all Claims
                        DisplayAllClaims();
                        break;
                    case "2":
                        //View Next Claim
                        DisplayNextClaim();
                        break;
                    case "3":
                        //Add New Claim
                        CreateNewClaim();
                        break;
                    case "4":
                        //Exit
                        Console.WriteLine("Good Bye!");
                        keepRunning = false;
                        break;
                    default:
                        // Please
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //Create New Menu Items
        private void CreateNewClaim()
        {
            Claim newItem = new Claim();

            Console.Clear();
            
            //Claim ID Number
            Console.WriteLine("Enter a Claim Number");
            string numberItemString = Console.ReadLine();
            newItem.ClaimID = int.Parse(numberItemString);

            //Claim Type
            Console.WriteLine("Enter Claim Type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            newItem.TypeOfClaim = (ClaimType)int.Parse(Console.ReadLine());

            //Description
            Console.WriteLine("Enter Claim Description");
            newItem.Description = Console.ReadLine();

            //Claim Amount
            Console.WriteLine("Enter the Amount ");
            //string priceString = Console.ReadLine();
            newItem.ClaimAmount = Double.Parse(Console.ReadLine());

            //Incident Date
            Console.WriteLine("Enter Date of Incident Like MM/DD/YYY");
            newItem.DateOfIncident = DateTime.Parse(Console.ReadLine());

            //Claim Date
            Console.WriteLine("Enter Date of Claim Like MM/DD/YYY");
            newItem.DateOfClaim = DateTime.Parse(Console.ReadLine());

            //IsValid
            //Console.WriteLine("Enter Date of Incident ");
            //newItem.IsValid = newItem.IsValid;
            if (newItem.IsValid)
            {
                //return "Valid";
                Console.WriteLine("Good News! Your Claim is Valid.");
            }
            else
            {
                //return false;
                Console.WriteLine("Sorry! Your Claim is being filed too late and is Invalid.");
            }

            _claimRepo.AddItem(newItem);
        }

        //View all Claims    
        public void DisplayAllClaims()
        {
            Console.Clear();
            Queue<Claim> claims = _claimRepo.GetClaims();

            Console.WriteLine(String.Format("{0,-8} {1,-6} {2,-25} {3,-8} {4,-15} {5,-15} {6,-8}\n", "ClaimID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid"));

            //Console.WriteLine("ClaimID", "Type", "Description", "Amount", "DateOfIncident", "DateOfClaim", "IsValid");

            foreach (Claim item in claims)
            {
                Console.WriteLine(String.Format("{0,-8} {1,-6} {2,-25} {3,-8} {4,-15} {5,-15} {6,-8}", item.ClaimID, item.TypeOfClaim, item.Description, item.ClaimAmount, item.DateOfIncident.ToShortDateString(), item.DateOfClaim.ToShortDateString(), item.IsValid));
            }
        }

        private void DisplayNextClaim()
        {
            Console.Clear();
            Claim claim = _claimRepo._claims.First();

            // Show claim
            Console.WriteLine($"ClaimID: {claim.ClaimID}\n" + $"Type: {claim.TypeOfClaim}\n" + $"Description: {claim.Description}\n" + $"DateOfAccident: {claim.DateOfIncident}\n" + $"DateOfClaim: {claim.DateOfClaim}\n" + $"IsValid: {claim.IsValid}\n");

            // Ask user to choose
            Console.WriteLine("Do you want to deal with this claim now(y/n)?");
            bool keepRunning = true;
            while (keepRunning)
            {
                string input = Console.ReadLine();
                if (input == "y")
                {
                    _claimRepo.RemoveItemFromTopOfQueue();
                    keepRunning = false;
                }
                else if (input == "n")
                {
                    _claimRepo.RemoveItemFromTopOfQueue();
                    _claimRepo.AddItem(claim);
                    keepRunning = false;
                }
                else
                {
                    Console.WriteLine("Please enter y or n");
                }
            }
        }

        // Seed data
        private void SeedData()
        {
            //Claim(int claimid, ClaimType typeofclaim, string description, Double claimamount, DateTime dateofincident, DateTime dateofclaim)

            Claim carClaim = new Claim(1,ClaimType.Car, "Car ran of road.", 10000.00, new DateTime(2020, 7, 10), new DateTime(2020, 7, 20));
            Claim homeClaim = new Claim(2,ClaimType.Home, "Garage door broke.", 3000.00, new DateTime(2020, 8, 20), new DateTime(2020, 9, 5));
            Claim theftClaim = new Claim(3,ClaimType.Theft, "Missing chicken.", 20.00, new DateTime(2020, 10, 20), new DateTime(2018, 10, 25));

            _claimRepo.AddItem(carClaim);
            _claimRepo.AddItem(homeClaim);
            _claimRepo.AddItem(theftClaim);
        }


    }
}
