using System;
using System.Collections.Generic;
using System.Text;
using NikosPetShop.Core.Entity;

namespace NikosPetShop.Core.DomainServices

{
    public interface IPetRepository
    {
        

        //Create Data
        Pet Create(Pet pet);
        //Read Data
        Pet ReadById(int id);
        IEnumerable<Pet> ReadAllPets();
        //Update Data
        Pet Update(Pet petUpdate);
        //Delete Data
        Pet Delete(int id);
    }
}
