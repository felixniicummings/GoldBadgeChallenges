﻿using _02_ClaimRepo;
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
                    "1. Add a New Claim\n" +
                    "2. View Claims\n" +
                    "3. View Claim\n" +
                    "4. Delete Claim\n" +
                    "5. Exit");
                //Get the use's input
                string input = Console.ReadLine();

                //Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        //Create new MenuItem
                        CreateNewClaim();
                        break;
                    case "2":
                        //View all MenuItems
                        DisplayAllClaims();
                        break;
                    //case "3":
                        // View Content By ID
                        //DisplayClaimById();
                        //break;
                    case "4":
                        // Delete Existing MenuItem 
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

            //List of ingredients
            //Console.WriteLine("Enter Description for the Menu Item");

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
            Console.WriteLine("Enter Date of Incident ");
            newItem.IsValid = true;

            _claimRepo.AddItemToList(newItem);
        }

        
        //View all Claims    
        /*public void DisplayAllClaims()
        {
            Console.Clear();
            List<Claim> listOfClaim = _menuItemRepo.

            foreach (MenuItem item in listOfMenuItems)
            {
                Console.WriteLine($"#{item.MenuItemNumber} {item.Name}\n, Description: {item.Description}\n, Price: ${item.Price}");
                //Console.WriteLine($"#:{item.MenuItemNumber}\n, Name: {item.Name}\n, Description: {item.Description}\n, Price: {item.Price}");
            }
        }*/

        //Delelete Existing Claim
        public void DeleteExistingClaim()
        {
            DisplayAllMenuItems();
            //Get the Menu Item 
            Console.WriteLine("\nPlease Enter the Number of the Menu Item you want to delete");
            string itemInputstring = Console.ReadLine();
            int itemToRemove = int.Parse(itemInputstring);
            bool wasDeleted = _menuItemRepo.RemoveItemFromList(itemToRemove);

            //Confirm Deletion
            if (wasDeleted)
            {
                Console.WriteLine("Menu Item was deleted.");
            }
            else
            {
                Console.WriteLine("Menu Item could NOT be deleted.");
            }
        }
    }
}
