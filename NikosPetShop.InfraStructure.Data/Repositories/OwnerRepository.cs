using NikosPetShop.Core.DomainServices;
using NikosPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NikosPetShop.InfraStructure.Static.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private int id;
        private List<Owner> _owners;

        public OwnerRepository()
        {
            this.id = 0;
            this._owners = new List<Owner>();
        }

        public Owner CreateOwner(Owner owner)
        {
            owner.Id = id++;
            _owners.Add(owner);
            return owner;
        }

        public Owner ReadOwnerById(int id)
        {
            foreach (var owner in _owners)
            {
                if (owner.Id == id)
                {
                    return owner;
                }
            }

            return null;
        }

        public Owner DeleteOwner(int id)
        {
            var petFound = ReadOwnerById(id);
            if (petFound != null)
            {
                _owners.Remove(petFound);
                return petFound;
            }

            return null;
        }

        public IEnumerable<Owner> ReadAllOwners()
        {
            return _owners.AsReadOnly();
        }

        public Owner UpdateOwner(Owner ownerUpdate)
        {
            var ownerFromDB = this.ReadOwnerById(ownerUpdate.Id);
            if (ownerFromDB != null)
            {
                ownerFromDB.FirstName = ownerUpdate.FirstName;
                ownerFromDB.LastName = ownerUpdate.LastName;
                ownerFromDB.Address = ownerUpdate.Address;
                ownerFromDB.PhoneNumber = ownerUpdate.PhoneNumber;
                ownerFromDB.Email = ownerUpdate.Email;
                return ownerFromDB;
            }

            return null; ;
        }
    }
}
