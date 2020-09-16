using NikosPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NikosPetShop.Core.DomainServices
{
    public interface IPetTypeRepository
    {
        PetType AddPetType(PetType type);
        IEnumerable<PetType> ReadTypes();
        PetType GetPetTypeByID(int ID);
        PetType UpdatePetType(PetType type);
        PetType DeletePetType(int ID);
    }
}
