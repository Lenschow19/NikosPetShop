using NikosPetShop.Core.DomainServices;
using NikosPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NikosPetShop.Infrastructure.SQLite.Data.Repositories
{
    public class PetSQLiteRepository : IPetRepository
    {
        private NikosPetShopLiteContext _ctx;

        public PetSQLiteRepository(NikosPetShopLiteContext ctx)
        {
            _ctx = ctx;
        }

        public Pet CreatePet(Pet pet)
        {
            var petEntry = _ctx.Add(pet);
            _ctx.SaveChanges();
            return petEntry.Entity;
        }

        public Pet DeletePet(int id)
        {
            var removedPet = _ctx.pets.Remove(ReadPetById(id));
            _ctx.SaveChanges();
            return removedPet.Entity;
        }

        public IEnumerable<Pet> ReadAllPets()
        {
            return _ctx.pets.AsEnumerable();
        }

        public IEnumerable<Pet> ReadAllPetsWithFilter(Filter filter)
        {
            throw new NotImplementedException();
        }

        public Pet ReadPetById(int id)
        {
            return _ctx.pets.FirstOrDefault(p => p.Id == id);
        }

        public Pet UpdatePet(Pet petUpdate)
        {
            var updatedPet = _ctx.pets.Update(petUpdate);
            _ctx.SaveChanges();
            return updatedPet.Entity;
        }
    }
}
