using System;
using System.Collections.Generic;
using System.Text;
using NikosPetShop.Core.Entity;

namespace NikosPetShop.Core.ApplicationServices
{
    public interface IPetService
    {
        Pet NewPet(string name, string color, DateTime birthDate,
            PetType petType, DateTime soldDate, Owner owner, double price);

        //CRUD
        Pet CreatePet(Pet pet);
        List<Pet> GetPets();
        List<Pet> GetPetsWithFilter(Filter filter);
        List<Pet> GetAllPetsByName(string name);
        List<Pet> GetAllPetsBySpecies(PetType petType);
        Pet FindPetById(int id);
        Pet UpdatePet(Pet petUpdate);
        Pet DeletePet(int id);
    }
}
