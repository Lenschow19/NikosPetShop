using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NikosPetShop.Core.DomainServices;
using NikosPetShop.Core.Entity;

namespace NikosPetShop.InfraStructure.Data.Repositories
{
    public class PetRepository: IPetRepository
    {
        static int id = 1;
        private static List<Pet> _pets = new List<Pet>();

        public Pet CreatePet(Pet pet)
        {
            pet.Id = id++;
            _pets.Add(pet);
            return pet;
        }

        public Pet ReadPetById(int id)
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

        public IEnumerable<Pet> ReadAllPetsWithFilter(Filter filter)
        {
            IEnumerable<Pet> pets = _pets.AsEnumerable();
            if (!string.IsNullOrEmpty(filter.Name))
            {
                pets = from x in pets where x.Name.ToLower().Contains(filter.Name.ToLower()) select x;
            }
            if (!string.IsNullOrEmpty(filter.Owner))
            {
                pets = from x in pets where x.Owner != null && x.Owner.FirstName.ToLower().Contains(filter.Owner.ToLower()) select x;
            }
            if (!string.IsNullOrEmpty(filter.Color))
            {
                pets = from x in pets where x.Color.ToLower().Contains(filter.Color.ToLower()) select x;
            }
            if (!string.IsNullOrEmpty(filter.PetType))
            {
                pets = from x in pets where x.PetType != null && x.PetType.NameOfPetType.ToLower().Contains(filter.PetType.ToLower()) select x;
            }
            return pets.ToList();
        }

        //Remove later when we use UOW
        public Pet UpdatePet(Pet petUpdate)
        {
            var petFromDB = this.ReadPetById(petUpdate.Id);
            if (petFromDB != null)
            {
                petFromDB.Name = petUpdate.Name;
                petFromDB.Color = petUpdate.Color;
                petFromDB.PetType = petUpdate.PetType;
                petFromDB.Birthdate = petUpdate.Birthdate;
                petFromDB.SoldDate = petUpdate.SoldDate;
                petFromDB.Owner = petUpdate.Owner;
                petFromDB.Price = petUpdate.Price;
                return petFromDB;
            }

            return null;
        }

        public Pet DeletePet(int id)
        {
            var petFound = ReadPetById(id);
            if (petFound != null)
            {
                _pets.Remove(petFound);
                return petFound;
            }

            return null;
        }

       
    }
}
