using NikosPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NikosPetShop.Core.ApplicationServices
{
    public interface IPetTypeService
    {
        PetType CreatePetType(string type);
        PetType AddPetType(PetType petType);
        List<PetType> GetAllPetTypes();
        List<PetType> GetPetTypesWithFilter(Filter filter);
        PetType GetPetTypeByID(int ID);
        PetType UpdatePetType(PetType type, int ID);
        PetType DeletePetType(int ID);
    }
}
