using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NikosPetShop.Core.DomainServices;
using NikosPetShop.Core.Entity;

namespace NikosPetShop.Core.ApplicationServices.Impl
{
    public class PetService : IPetService
    {
        readonly IPetRepository _petRepo;

        public PetService(IPetRepository petRepository)
        {
            _petRepo = petRepository;
        }

        public Pet NewPet(string name, string color, DateTime birthDate, Species species, DateTime soldDate, string previousOwner, double price)
        {
            var pet = new Pet()
            {
                Name = name,
                Color = color,
                TypeOfSpecies = species,
                Birthdate = birthDate,
                SoldDate = soldDate,
                PreviousOwner = previousOwner,
                Price = price
            };

            return pet;
        }


        public Pet CreatePet(Pet pet)
        {
            return _petRepo.Create(pet);
        }

        public List<Pet> GetPets()
        {
            return _petRepo.ReadAllPets().ToList();
        }

        public List<Pet> GetAllPetsByName(string name)
        {
            var list = _petRepo.ReadAllPets();
            var queryContinued = list.Where(pet => pet.Name.Equals(name));
            queryContinued.OrderBy(pet => pet.Name);
            return queryContinued.ToList();
        }

        public Pet FindPetById(int id)
        {
            return _petRepo.ReadById(id);
        }

        public Pet UpdatePet(Pet petUpdate)
        {
            var pet = FindPetById(petUpdate.Id);
            pet.Name = petUpdate.Name;
            pet.Color = petUpdate.Color;
            pet.TypeOfSpecies = petUpdate.TypeOfSpecies;
            pet.Birthdate = petUpdate.Birthdate;
            pet.SoldDate = petUpdate.SoldDate;
            pet.PreviousOwner = petUpdate.PreviousOwner;
            pet.Price = petUpdate.Price;
            return pet;
        }

        public Pet DeletePet(int id)
        {
            return _petRepo.Delete(id);
        }

      
    }
}
