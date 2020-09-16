using NikosPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NikosPetShop.Core.ApplicationServices
{
    interface IPetTypeService
    {
        PetType CreatePetType(string type);
        PetType AddPetType(PetType petType);
        List<PetType> GetAllPetTypes();
        PetType GetPetTypeByID(int ID);
        PetType UpdatePetType(PetType type, int ID);
        PetType DeletePetType(int ID);
    }
}
