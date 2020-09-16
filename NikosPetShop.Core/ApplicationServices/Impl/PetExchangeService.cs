using NikosPetShop.Core.DomainServices;
using NikosPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NikosPetShop.Core.ApplicationServices.Impl
{
    public class PetExchangeService : IPetExchangeService
    {
        private IPetRepository PetRepository;

        public PetExchangeService(IPetRepository petRepository)
        {
            this.PetRepository = petRepository;
        }

        public List<Pet> ListAllPetsRegisteredToOwner(int ID)
        {
            IEnumerable<Pet> pets = from x in PetRepository.ReadAllPets() where x.Owner != null select x;
            return (from x in pets where x.Owner.Id == ID select x).ToList();
        }

        public List<Pet> ListAllPetsWithOwner()
        {
            return (from x in PetRepository.ReadAllPets() where x.Owner != null select x).ToList();
        }

        public Pet RegisterPet(Pet pet, Owner owner)
        {
            if (pet != null || owner != null)
            {
                pet.Owner = owner;
                pet.SoldDate = DateTime.Now;
                return PetRepository.UpdatePet(pet);
            }
            else
            {
                throw new ArgumentException("The entered Pet- or Owner-ID wasn't found.");
            }
        }

        public Pet UnregisterPet(Pet pet)
        {
            if (pet != null)
            {
                pet.Owner = null;
                return PetRepository.UpdatePet(pet);
            }
            else
            {
                throw new ArgumentException("This Pet don't seem to be associated with this owner.");
            }
        }
    }
}
