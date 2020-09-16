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
        private IPetTypeRepository PetTypeRepository;

        public PetTypeService(IPetTypeRepository petTypeRepository)
        {
            this.PetTypeRepository = petTypeRepository;
        }

        public PetType AddPetType(PetType petType)
        {
            if (petType != null)
            {
                if ((from x in GetAllPetTypes() where x.NameOfPetType.ToLower().Equals(petType.NameOfPetType.ToLower()) select x).Count() > 0)
                {
                    throw new ArgumentException("Pet type already exists");
                }
                return PetTypeRepository.AddPetType(petType);
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
            return PetTypeRepository.DeletePetType(Id); ;
        }

        public List<PetType> GetAllPetTypes()
        {
            return PetTypeRepository.ReadTypes().ToList();
        }

        public PetType GetPetTypeByID(int ID)
        {
            return PetTypeRepository.GetPetTypeByID(ID);
        }

        public List<PetType> GetPetTypeByName(string searchTitle)
        {
            return SearchEngine.Search<PetType>(GetAllPetTypes(), searchTitle);
        }

        public List<PetType> GetPetTypesFilterSearch(Filter filter)
        {
            throw new NotImplementedException();
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
            return PetTypeRepository.UpdatePetType(type);
        }
}
