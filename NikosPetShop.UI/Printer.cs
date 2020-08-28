using System;
using System.Collections.Generic;
using System.Text;
using NikosPetShop.Core.ApplicationServices;
using NikosPetShop.Core.ApplicationServices.Impl;
using NikosPetShop.Core.DomainServices;
using NikosPetShop.Core.Entity;
using NikosPetShop.InfraStructure.Static.Data.Repositories;

namespace NikosPetShop.UI
{
    public class Printer: IPrinter
    {
        #region Repostitory Area
        IPetService _petService;
        #endregion

        public Printer(IPetService petService)
        {
            _petService = petService;
            InitData();

            StartUI();
            
        }


        public void StartUI()
        {
            
            string[] menuItems =
            {
                "List All Pets",
                "Add Pet",
                "Delete Pet",
                "Edit Pet",
                "Exit"
            };

            var selection = ShowMenu(menuItems);

            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        var pets = _petService.GetPets();
                        ListPets(pets);
                        break;
                    case 2:
                        _petService.CreatePet(PetCreation());
                        break;
                    case 3:
                        var idForDelete = PrintFindPetByID();
                        var petForDelete = _petService.FindPetById(idForDelete);
                        Console.WriteLine("Now deleted: " + petForDelete.Name);

                        _petService.DeletePet(idForDelete);
                        break;
                    case 4:
                        var idForEdit = PrintFindPetByID();
                        var petToEdit = _petService.FindPetById(idForEdit);
                        Console.WriteLine("Updating " + petToEdit.Name);

                        var pet = PetCreation();
                        pet.Id = idForEdit;

                        _petService.UpdatePet(pet);
                        break;
                    default:
                        break;
                }

                selection = ShowMenu(menuItems);
            }
            //Farewell text
            Console.WriteLine("Thanks for stopping by! See you soon");

            Console.ReadLine();

            #region Menu Initializing

            int ShowMenu(string[] menuItems)
            {
                //Welcoming text
                Console.WriteLine("Hello and welcome to my wonderful and amazing pet store.\nIn a short time you will have found the perfect pet for you to bring home and love.\nLet's get started. Make a selection from the menu.");

                for (int i = 0; i < menuItems.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {menuItems[i]}");
                }

                int selection;
                while (!int.TryParse(Console.ReadLine(), out selection)
                       || selection < 1
                       || selection > 5)
                {
                    Console.WriteLine("Please use numbers to select.");
                }

                return selection;
            }
            #endregion

            //UI specific methods
            int PrintFindPetByID()
            {
                Console.WriteLine("Insert the ID of the pet you're looking for:");
                int id;
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Please type a number.");
                }

                return id;
            }

            string AskQuestion(string question)
            {
                Console.WriteLine(question);
                return Console.ReadLine();
            }

            void ListPets(List<Pet> pets)
            {
                Console.WriteLine("\nHere's all our pets");
                foreach (var pet in pets)
                {
                    Console.WriteLine($"\nID: {pet.Id} Name: {pet.Name} \nColor: {pet.Color} \nSpecies: {pet.TypeOfSpecies}" +
                        $"\nBirthDate: {pet.Birthdate.ToString("dd/MM/yyyy")} \nSold status: {((pet.SoldDate.Equals(new DateTime())) ? "Not yet sold" : $"Sold on the {pet.SoldDate.ToString("dd/MM/yyyy")}")} " +
                        $"\nPrevious Owner: {pet.PreviousOwner}" +
                        $"\nPrice: {pet.Price.ToString("n2")} KR.");
                }

                Console.WriteLine(" ");
            }

            Pet PetCreation()
            {
                Array petTypes = Enum.GetValues(typeof(Species));

                var name = AskQuestion("\nName: ");
                var color = AskQuestion("\nColor: ");

                var birthDateStr = AskQuestion("\nBirthdate (DD-MM-YYYY): ");
                DateTime birthDate;
                DateTime.TryParse(birthDateStr, out birthDate);

                Console.WriteLine("\nChoose what type of species the pet is: \n");
                int selection;

                for (int i = 0; i < petTypes.Length; i++)
                {
                    Console.WriteLine((i+1) + ": " + petTypes.GetValue(i));
                }
                while (!int.TryParse(Console.ReadLine(), out selection) 
                                        || selection < 1 
                                        || selection > petTypes.Length)
                {
                    Console.WriteLine($"Please pick an option between 1-{petTypes.Length}");
                }
                Species species = (Species)petTypes.GetValue(selection - 1);

                var soldDateStr = AskQuestion("\nSoldDate (DD-MM-YYYY): ");
                DateTime soldDate;
                DateTime.TryParse(soldDateStr, out soldDate);
                  
                var previousOwner = AskQuestion("\nWho has owned the pet previously: ");
                
                var priceStr = AskQuestion("\nHow much is the price of the pet: ");
                double price;
                double.TryParse(priceStr, out price);

                var pet = _petService.NewPet(name, color, birthDate, species, soldDate, previousOwner, price);
                return pet;
            }

            
        }

        #region InitData
        void InitData()
        {
            var pet1 = new Pet()
            {
                Name = "Bob",
                Color = "Black",
                TypeOfSpecies = Species.Cat,
                Birthdate = DateTime.Parse("02-02-2002"),
                PreviousOwner = "Egoin",
                Price = 1000000
            };
            _petService.CreatePet(pet1);

            var pet2 = new Pet()
            {
                Name = "Gunnar",
                Color = "Orange",
                TypeOfSpecies = Species.Guinea_Pig,
                Birthdate = DateTime.Parse("12-12-2012"),
                SoldDate = DateTime.Parse("12-02-2013"),
                PreviousOwner = "Henning",
                Price = 100
            };
            _petService.CreatePet(pet2);

        }
        #endregion
    }
}
