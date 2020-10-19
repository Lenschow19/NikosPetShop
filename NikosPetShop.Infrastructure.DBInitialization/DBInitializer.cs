using NikosPetShop.Core.ApplicationServices;
using NikosPetShop.Core.ApplicationServices.Impl;
using NikosPetShop.Core.DomainServices;
using NikosPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NikosPetShop.Infrastructure.DBInitialization
{
    public class DBInitializer
    {
        #region Repostitory Area
        IPetRepository PetRepository;
        IOwnerRepository OwnerRepository;
        IPetTypeRepository PetTypeRepository;
        IUserService UserService;
        IUserRepository UserRepository;
        #endregion

        public DBInitializer(IPetRepository petRepository, IOwnerRepository ownerRepository, IPetTypeRepository petTypeRepository, IUserRepository userRepository, IUserService userService)
        {
            this.PetRepository = petRepository;
            this.OwnerRepository = ownerRepository;
            this.PetTypeRepository = petTypeRepository;
            this.UserService = userService;
            this.UserRepository = userRepository;
        }

        #region InitData
        public void InitData()
        {

            PetType dog = new PetType { NameOfPetType = "Dog" };
            PetType cat = new PetType { NameOfPetType = "Cat" };
            PetType tarantula = new PetType { NameOfPetType = "Tarantula" };
            PetType snake = new PetType { NameOfPetType = "Snake" };
            PetType mouse = new PetType { NameOfPetType = "Mouse" };
            PetType hamster = new PetType { NameOfPetType = "Hamster" };
            PetType rabbit = new PetType { NameOfPetType = "Rabbit" };
            PetType chincilla = new PetType { NameOfPetType = "Chinchilla" };
            PetType guineaPig = new PetType { NameOfPetType = "Guinea Pig" };
            PetType piglet = new PetType { NameOfPetType = "Piglet" };
            PetType fish = new PetType { NameOfPetType = "Fish" };


            PetTypeRepository.AddPetType(dog);
            PetTypeRepository.AddPetType(cat);
            PetTypeRepository.AddPetType(tarantula);
            PetTypeRepository.AddPetType(snake);
            PetTypeRepository.AddPetType(mouse);
            PetTypeRepository.AddPetType(hamster);
            PetTypeRepository.AddPetType(rabbit);
            PetTypeRepository.AddPetType(chincilla);
            PetTypeRepository.AddPetType(guineaPig);
            PetTypeRepository.AddPetType(piglet);
            PetTypeRepository.AddPetType(fish);


            OwnerRepository.CreateOwner(new Owner
            {
                FirstName = "Mia",
                LastName = "Andersen",
                Address = "Aldervej 4",
                PhoneNumber = "36665496",
                Email = "Mia.Andersen@Hotmail.com"
            });

            OwnerRepository.CreateOwner(new Owner
            {
                FirstName = "Bent",
                LastName = "Petersen",
                Address = "Gl. Kongevej 96",
                PhoneNumber = "96385215",
                Email = "BP96@gmail.com"
            });

            Owner henning = OwnerRepository.CreateOwner(new Owner
            {
                FirstName = "Henning",
                LastName = "Andersen",
                Address = "Aldervej 4",
                PhoneNumber = "12345687",
                Email = "Henning@Andersen.dk"
            });


            PetRepository.CreatePet(new Pet
            {
                Name = "Bob",
                Color = "Black",
                PetType = cat,
                Birthdate = DateTime.Parse("02-02-2002"),
                Price = 1000000
            });

            PetRepository.CreatePet(new Pet
            {
                Name = "Gunnar",
                Color = "Orange",
                PetType = guineaPig,
                Birthdate = DateTime.Parse("12-12-2012"),
                SoldDate = DateTime.Parse("12-02-2013"),
                Owner = henning,
                Price = 150
            });


            PetRepository.CreatePet(new Pet
            {
                Name = "Bille",
                Color = "Brown",
                PetType = chincilla,
                Birthdate = DateTime.Parse("02-02-2018"),
                Price = 100
            });

            PetRepository.CreatePet(new Pet
            {
                Name = "Finn",
                Color = "Orange",
                PetType = rabbit,
                Birthdate = DateTime.Parse("05-06-2006"),
                Price = 15648
            });

            PetRepository.CreatePet(new Pet
            {
                Name = "Jens",
                Color = "Black",
                PetType = piglet,
                Birthdate = DateTime.Parse("05-12-2019"),
                Price = 999
            });

            PetRepository.CreatePet(new Pet
            {
                Name = "Abracadabra",
                Color = "Rainbow",
                PetType = guineaPig,
                Birthdate = DateTime.Parse("02-02-2020"),
                Price = 1555550
            });

            UserRepository.AddUser(UserService.CreateUser("Bent", "Ersej", "Admin"));
            UserRepository.AddUser(UserService.CreateUser("Pia", "Harpigelus", "User"));

        }
        #endregion

    }
}
