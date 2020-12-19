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
                    "3. View Claim\n" +
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
                        // Delete Existing Claim 
                        DeleteExistingClaim();
                        break;
                    case "5":
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
            Console.WriteLine("Enter a Number for The Menu Item");
            string numberItemString = Console.ReadLine();
            newItem.ClaimID = int.Parse(numberItemString);

            //Claim Type
            Console.WriteLine("Enter the Genre Number:\n" +
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
            Console.WriteLine("Enter Date of Incident ");
            newItem.DateOfIncident = DateTime.Parse(Console.ReadLine());

            //Claim Date
            Console.WriteLine("Enter Date of Claim ");
            newItem.DateOfClaim = DateTime.Parse(Console.ReadLine());

            //IsValid
            //Console.WriteLine("Enter Date of Incident ");
            //newItem.IsValid = newItem.IsValid;
            if (newItem.IsValid)
            {
                //return "Valid";
                Console.WriteLine("Valid Claim.");
            }
            else
            {
                //return false;
                Console.WriteLine("Invalid Claim.");
            }

            _claimRepo.AddItemToList(newItem);
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
                //Console.WriteLine($"#{item.ClaimID} {item.TypeOfClaim}, Description: {item.Description}, Amount: ${item.ClaimAmount} DateOfAccident: {item.DateOfIncident} DateofClaim: {item.DateOfClaim} IsValid: {item.IsValid}");
                //Console.WriteLine(, item.TypeOfClaim, item.Description, item.ClaimAmount, item.DateOfIncident, item.DateOfClaim, item.DateOfClaim, item.IsValid);
                Console.WriteLine(String.Format("{0,-8} {1,-6} {2,-25} {3,-8} {4,-15} {5,-15} {6,-8}", item.ClaimID, item.TypeOfClaim, item.Description, item.ClaimAmount, item.DateOfIncident.ToShortDateString(), item.DateOfClaim.ToShortDateString(), item.IsValid));
            }
        }

    }
}
