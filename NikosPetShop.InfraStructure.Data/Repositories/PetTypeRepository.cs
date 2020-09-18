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
        private IEnumerable<PetType> _petTypes = new List<PetType>();

        public PetTypeRepository()
        {
            this.Id = 0;
        }

        public PetType AddPetType(PetType type)
        {
            Id++;
            type.Id = Id;
            ((List<PetType>)_petTypes).Add(type);
            return type;
        }

        public PetType DeletePetType(int ID)
        {
            PetType petType = _petTypes.Where((x) => { return x.Id == ID; }).FirstOrDefault();
            if (petType != null)
            {
                ((List<PetType>)_petTypes).Remove(petType);
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
            return _petTypes;
        }

        public IEnumerable<PetType> ReadAllPetTypesWithFilter(Filter filter)
        {
            IEnumerable<PetType> petTypes = _petTypes.AsEnumerable();
            if (!string.IsNullOrEmpty(filter.Name))
            {
                petTypes = from x in petTypes where x.NameOfPetType.ToLower().Contains(filter.Name.ToLower()) select x;
            }
            return petTypes.ToList();
        }

        public PetType UpdatePetType(PetType type)
        {
            PetType petType = ((List<PetType>)_petTypes).Find((x) => { return x.Id == type.Id; });
            if (petType != null)
            {
                petType.NameOfPetType = type.NameOfPetType;
                return petType;
            }
            return null;
        }
    }
}
