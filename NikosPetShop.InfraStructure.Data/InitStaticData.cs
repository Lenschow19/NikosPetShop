using NikosPetShop.Core.ApplicationServices;
using NikosPetShop.Core.DomainServices;
using NikosPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NikosPetShop.InfraStructure.Static.Data
{
    public class InitStaticData
    {
        #region Repostitory Area
        IPetRepository PetRepository;
        IOwnerRepository OwnerRepository;
        #endregion

        public InitStaticData(IPetRepository petRepository, IOwnerRepository ownerRepository)
        {
            this.PetRepository = petRepository;
            this.OwnerRepository = ownerRepository;
        }

        #region InitData
        public void InitData()
        {
            PetRepository.CreatePet(new Pet
            {
                Name = "Bob",
                Color = "Black",
                TypeOfSpecies = Species.Cat,
                Birthdate = DateTime.Parse("02-02-2002"),
                PreviousOwner = "Egoin",
                Price = 1000000
            });


            PetRepository.CreatePet(new Pet
            {
                Name = "Gunnar",
                Color = "Orange",
                TypeOfSpecies = Species.Guinea_Pig,
                Birthdate = DateTime.Parse("12-12-2012"),
                SoldDate = DateTime.Parse("12-02-2013"),
                PreviousOwner = "Henning",
                Price = 150
            });


            PetRepository.CreatePet(new Pet
            {
                Name = "Bille",
                Color = "Brown",
                TypeOfSpecies = Species.Chinchillas,
                Birthdate = DateTime.Parse("02-02-2018"),
                PreviousOwner = "Enk",
                Price = 100
            });

            PetRepository.CreatePet(new Pet
            {
                Name = "Finn",
                Color = "Orange",
                TypeOfSpecies = Species.Rabbit,
                Birthdate = DateTime.Parse("05-06-2006"),
                PreviousOwner = "Egg",
                Price = 15648
            });

            PetRepository.CreatePet(new Pet
            {
                Name = "Jens",
                Color = "Black",
                TypeOfSpecies = Species.Piglet,
                Birthdate = DateTime.Parse("05-12-2019"),
                PreviousOwner = "Bent",
                Price = 999
            });

            PetRepository.CreatePet(new Pet
            {
                Name = "Abracadabra",
                Color = "Rainbow",
                TypeOfSpecies = Species.Guinea_Pig,
                Birthdate = DateTime.Parse("02-02-2020"),
                PreviousOwner = "Egoin",
                Price = 1555550
            });

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

            OwnerRepository.CreateOwner(new Owner
            {
                FirstName = "Henning",
                LastName = "Andersen",
                Address = "Aldervej 4",
                PhoneNumber = "12345687",
                Email = "Henning@Andersen.dk"
            });

        }
        #endregion
    }
}
