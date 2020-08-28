using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;
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

        }

        public void StartUI()
        {
            
            string[] menuItems =
            {
                "List All Pets",
                "Add Pet",
                "Delete Pet",
                "Edit Pet",
                "Search Pets by Species",
                "Sort Pets by Price",
                "See the 5 cheapest available",
                "Exit"
            };

            var selection = ShowMenu(menuItems);

            while (selection != (menuItems.Length))
            {
                switch (selection)
                {
                    case 1:
                        var pets = _petService.GetPets();
                        Console.WriteLine("\nHere's all our pets");
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
                    case 5:
                        Console.WriteLine("What species of pet are you looking for?\n");
                        Species chosenSpecies = ListSpecies();
                        var petSpecies = _petService.GetAllPetsBySpecies(chosenSpecies);
                        ListPets(petSpecies);
                        break;
                    case 6:
                        Console.WriteLine("Here are all our pets, sort by price:");
                        var petPrices = _petService.GetPets();
                        var sortedPetPrices = petPrices.OrderByDescending((x) => { return x.Price; }).ToList();
                        ListPets(sortedPetPrices);
                        break;
                    case 7:
                        Console.WriteLine("Top 5 cheapest pets:");
                        var petPrices5 = _petService.GetPets();
                        var sortedPetPrices5 = petPrices5.OrderBy((x) => { return x.Price; }).ToList();
                        if (sortedPetPrices5.Count > 5)
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                Pet petP = sortedPetPrices5[i];
                                Console.WriteLine($"\nID: {petP.Id} Name: {petP.Name} \nColor: {petP.Color} \nSpecies: {petP.TypeOfSpecies}" +
                                                    $"\nBirthDate: {petP.Birthdate.ToString("dd/MM/yyyy")} \nSold status: {((petP.SoldDate.Equals(new DateTime())) ? "Not yet sold" : $"Sold on the {petP.SoldDate.ToString("dd/MM/yyyy")}")} " +
                                                    $"\nPrevious Owner: {petP.PreviousOwner}" +
                                                    $"\nPrice: {petP.Price.ToString("n2")} KR.");
                            } 
                        } else
                        {
                            ListPets(sortedPetPrices5);
                        }
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
                Console.WriteLine("Hello and welcome to my wonderful and amazing pet store.\nIn a short time you will have found the perfect pet for you to bring home and love.\nLet's get started. Make a selection from the menu.\n");

                for (int i = 0; i < menuItems.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {menuItems[i]}");
                }

                int selection;
                while (!int.TryParse(Console.ReadLine(), out selection)
                       || selection < 1
                       || selection > menuItems.Length)
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
                
                foreach (var pet in pets)
                {
                    Console.WriteLine($"\nID: {pet.Id} Name: {pet.Name} \nColor: {pet.Color} \nSpecies: {pet.TypeOfSpecies}" +
                        $"\nBirthDate: {pet.Birthdate.ToString("dd/MM/yyyy")} \nSold status: {((pet.SoldDate.Equals(new DateTime())) ? "Not yet sold" : $"Sold on the {pet.SoldDate.ToString("dd/MM/yyyy")}")} " +
                        $"\nPrevious Owner: {pet.PreviousOwner}" +
                        $"\nPrice: {pet.Price.ToString("n2")} KR.");
                }

                Console.WriteLine(" ");
            }

            Species ListSpecies()
            {
                Array petTypes = Enum.GetValues(typeof(Species));
                int selection;

                for (int i = 0; i < petTypes.Length; i++)
                {
                    Console.WriteLine((i + 1) + ": " + petTypes.GetValue(i));
                }
                while (!int.TryParse(Console.ReadLine(), out selection)
                                        || selection < 1
                                        || selection > petTypes.Length)
                {
                    Console.WriteLine($"Please pick an option between 1-{petTypes.Length}");
                }
                Species species = (Species)petTypes.GetValue(selection - 1);
                return species;
            };

            Pet PetCreation()
            {
                var name = AskQuestion("\nName: ");
                var color = AskQuestion("\nColor: ");

                var birthDateStr = AskQuestion("\nBirthdate (DD-MM-YYYY): ");
                DateTime birthDate;
                DateTime.TryParse(birthDateStr, out birthDate);

                Console.WriteLine("\nChoose what type of species the pet is: \n");
                Species species = ListSpecies();

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
                Price = 150
            };
            _petService.CreatePet(pet2);

            var pet3 = new Pet()
            {
                Name = "Bille",
                Color = "Brown",
                TypeOfSpecies = Species.Chinchillas,
                Birthdate = DateTime.Parse("02-02-2018"),
                PreviousOwner = "Enk",
                Price = 100
            };
            _petService.CreatePet(pet3);

            var pet4 = new Pet()
            {
                Name = "Finn",
                Color = "Orange",
                TypeOfSpecies = Species.Rabbit,
                Birthdate = DateTime.Parse("05-06-2006"),
                PreviousOwner = "Egg",
                Price = 15648
            };
            _petService.CreatePet(pet4);

            var pet5 = new Pet()
            {
                Name = "Jens",
                Color = "Black",
                TypeOfSpecies = Species.Piglet,
                Birthdate = DateTime.Parse("05-12-2019"),
                PreviousOwner = "Bent",
                Price = 999
            };
            _petService.CreatePet(pet5);

            var pet6 = new Pet()
            {
                Name = "Abracadabra",
                Color = "Rainbow",
                TypeOfSpecies = Species.Guinea_Pig,
                Birthdate = DateTime.Parse("02-02-2020"),
                PreviousOwner = "Egoin",
                Price = 1555550
            };
            _petService.CreatePet(pet6);
        }
        #endregion
    }
}
