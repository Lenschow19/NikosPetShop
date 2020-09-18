using System;
using System.Collections.Generic;
using System.Text;
using NikosPetShop.Core.Entity;

namespace NikosPetShop.Core.DomainServices

{
    public interface IPetRepository
    {
        

        //Create Data
        Pet CreatePet(Pet pet);
        //Read Data
        Pet ReadPetById(int id);
        IEnumerable<Pet> ReadAllPets();
        IEnumerable<Pet> ReadAllPetsWithFilter(Filter filter);
        //Update Data
        Pet UpdatePet(Pet petUpdate);
        //Delete Data
        Pet DeletePet(int id);
    }
}
