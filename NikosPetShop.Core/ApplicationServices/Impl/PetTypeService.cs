using NikosPetShop.Core.DomainServices;
using NikosPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NikosPetShop.Core.ApplicationServices.Impl
{
    public class PetTypeService : IPetTypeService
    {
        private IPetTypeRepository _petTypeRepository;

        public PetTypeService(IPetTypeRepository petTypeRepository)
        {
            this._petTypeRepository = petTypeRepository;
        }

        public PetType AddPetType(PetType petType)
        {
            if (petType != null)
            {
                if ((from x in GetAllPetTypes() where x.NameOfPetType.ToLower().Equals(petType.NameOfPetType.ToLower()) select x).Count() > 0)
                {
                    throw new ArgumentException("Pet type already exists");
                }
                return _petTypeRepository.AddPetType(petType);
            }
            return null;
        }

        public PetType CreatePetType(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                throw new ArgumentException("Pet type name is too short.");
            }
            return new PetType { NameOfPetType = type };
        }

        public PetType DeletePetType(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException("Please enter a valid ID.");
            }
            if (GetPetTypeByID(Id) == null)
            {
                throw new ArgumentException("Can't find pet type with entered ID.");
            }
            return _petTypeRepository.DeletePetType(Id); ;
        }

        public List<PetType> GetAllPetTypes()
        {
            return _petTypeRepository.ReadTypes().ToList();
        }

        public PetType GetPetTypeByID(int ID)
        {
            return _petTypeRepository.GetPetTypeByID(ID);
        }

        public List<PetType> GetPetTypesWithFilter(Filter filter)
        {
            return _petTypeRepository.ReadAllPetTypesWithFilter(filter).ToList();
        }

        public PetType UpdatePetType(PetType type, int Id)
        {
            if (GetPetTypeByID(Id) == null)
            {
                throw new ArgumentException("Entered ID does not match a pet type.");
            }
            if (type == null)
            {
                throw new ArgumentException("Can't find pet type to update on the entered ID.");
            }
            type.Id = Id;
            return _petTypeRepository.UpdatePetType(type);
        }
    }
}
