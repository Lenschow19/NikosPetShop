using NikosPetShop.Core.DomainServices;
using NikosPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NikosPetShop.InfraStructure.Data.Repositories
{
    public class PetTypeRepository : IPetTypeRepository
    {
        private int Id;
        private IEnumerable<PetType> PetTypes;

        public PetTypeRepository()
        {
            this.Id = 0;
            this.PetTypes = new List<PetType>();
        }

        public PetType AddPetType(PetType type)
        {
            Id++;
            type.Id = Id;
            ((List<PetType>)PetTypes).Add(type);
            return type;
        }

        public PetType DeletePetType(int ID)
        {
            PetType petType = PetTypes.Where((x) => { return x.Id == ID; }).FirstOrDefault();
            if (petType != null)
            {
                ((List<PetType>)PetTypes).Remove(petType);
                return petType;
            }
            return null;
        }

        public PetType GetPetTypeByID(int Id)
        {
            return ReadTypes().Where((x) => { return x.Id == Id; }).FirstOrDefault();
        }

        public IEnumerable<PetType> ReadTypes()
        {
            return PetTypes;
        }

        public PetType UpdatePetType(PetType type)
        {
            PetType petType = ((List<PetType>)PetTypes).Find((x) => { return x.Id == type.Id; });
            if (petType != null)
            {
                petType.NameOfPetType = type.NameOfPetType;
                return petType;
            }
            return null;
        }
    }
}
