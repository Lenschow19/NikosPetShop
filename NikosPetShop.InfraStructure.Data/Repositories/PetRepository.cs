using System;
using System.Collections.Generic;
using System.Text;
using NikosPetShop.Core.DomainServices;
using NikosPetShop.Core.Entity;

namespace NikosPetShop.InfraStructure.Static.Data.Repositories
{
    public class PetRepository: IPetRepository
    {
        static int id = 1;
        private static List<Pet> _pets = new List<Pet>();

        public Pet Create(Pet pet)
        {
            pet.Id = id++;
            _pets.Add(pet);
            return pet;
        }

        public Pet ReadById(int id)
        {
            foreach (var pet in _pets)
            {
                if (pet.Id == id)
                {
                    return pet;
                }
            }

            return null;
        }

        public IEnumerable<Pet> ReadAllPets()
        {
            return _pets.AsReadOnly();
        }

        //Remove later when we use UOW
        public Pet Update(Pet petUpdate)
        {
            var petFromDB = this.ReadById(petUpdate.Id);
            if (petFromDB != null)
            {
                petFromDB.Name = petUpdate.Name;
                petFromDB.Color = petUpdate.Color;
                petFromDB.TypeOfSpecies = petUpdate.TypeOfSpecies;
                petFromDB.Birthdate = petUpdate.Birthdate;
                petFromDB.SoldDate = petUpdate.SoldDate;
                petFromDB.PreviousOwner = petUpdate.PreviousOwner;
                petFromDB.Price = petUpdate.Price;
                return petFromDB;
            }

            return null;
        }

        public Pet Delete(int id)
        {
            var petFound = ReadById(id);
            if (petFound != null)
            {
                _pets.Remove(petFound);
                return petFound;
            }

            return null;
        }
    }
}
