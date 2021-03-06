﻿using System;
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

        public Pet NewPet(string name, string color, DateTime birthDate, PetType petType, DateTime soldDate, Owner owner, double price)
        {
            var pet = new Pet()
            {
                Name = name,
                Color = color,
                Birthdate = birthDate,
                PetType = petType,
                SoldDate = soldDate,
                Owner = owner,
                Price = price
            };

            return pet;
        }


        public Pet CreatePet(Pet pet)
        {
            if (_petRepo == null)
            {
                return null;
            }
            return _petRepo.CreatePet(pet);
        }

        public List<Pet> GetPets()
        {
            return _petRepo.ReadAllPets().ToList();
        }

        public List<Pet> GetPetsWithFilter(Filter filter)
        {
            return _petRepo.ReadAllPetsWithFilter(filter).ToList();
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
            return _petRepo.ReadPetById(id);
        }

        public Pet UpdatePet(Pet petUpdate)
        {
            var pet = FindPetById(petUpdate.Id);
            pet.Name = petUpdate.Name;
            pet.Color = petUpdate.Color;
            pet.PetType = petUpdate.PetType;
            pet.Birthdate = petUpdate.Birthdate;
            pet.SoldDate = petUpdate.SoldDate;
            pet.Owner = petUpdate.Owner;
            pet.Price = petUpdate.Price;
            return pet;
        }

        public Pet DeletePet(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Please enter valid ID.");
            }
            if (FindPetById(id) == null)
            {
                throw new ArgumentException("Entered ID does not match with a pet.");
            }
            else 
            {
                return _petRepo.DeletePet(id);
            }
        }

        public List<Pet> GetAllPetsBySpecies(PetType petType)
        {
            var list = _petRepo.ReadAllPets();
            var queryContinued = list.Where(pet => pet.PetType.Id == petType.Id);
            queryContinued.OrderBy(pet => pet.Name);
            return queryContinued.ToList();
        }

        
    }
}
