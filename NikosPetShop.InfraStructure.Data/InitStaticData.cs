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
        #endregion

        public InitStaticData(IPetRepository petRepository)
        {
            this.PetRepository = petRepository;
        }

        #region InitData
        public void InitData()
        {
            PetRepository.Create(new Pet
            {
                Name = "Bob",
                Color = "Black",
                TypeOfSpecies = Species.Cat,
                Birthdate = DateTime.Parse("02-02-2002"),
                PreviousOwner = "Egoin",
                Price = 1000000
            });


            PetRepository.Create(new Pet
            {
                Name = "Gunnar",
                Color = "Orange",
                TypeOfSpecies = Species.Guinea_Pig,
                Birthdate = DateTime.Parse("12-12-2012"),
                SoldDate = DateTime.Parse("12-02-2013"),
                PreviousOwner = "Henning",
                Price = 150
            });


            PetRepository.Create(new Pet
            {
                Name = "Bille",
                Color = "Brown",
                TypeOfSpecies = Species.Chinchillas,
                Birthdate = DateTime.Parse("02-02-2018"),
                PreviousOwner = "Enk",
                Price = 100
            });

            PetRepository.Create(new Pet
            {
                Name = "Finn",
                Color = "Orange",
                TypeOfSpecies = Species.Rabbit,
                Birthdate = DateTime.Parse("05-06-2006"),
                PreviousOwner = "Egg",
                Price = 15648
            });

            PetRepository.Create(new Pet
            {
                Name = "Jens",
                Color = "Black",
                TypeOfSpecies = Species.Piglet,
                Birthdate = DateTime.Parse("05-12-2019"),
                PreviousOwner = "Bent",
                Price = 999
            });

            PetRepository.Create(new Pet
            {
                Name = "Abracadabra",
                Color = "Rainbow",
                TypeOfSpecies = Species.Guinea_Pig,
                Birthdate = DateTime.Parse("02-02-2020"),
                PreviousOwner = "Egoin",
                Price = 1555550
            });
        }
        #endregion
    }
}
