using NikosPetShop.Core.DomainServices;
using NikosPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NikosPetShop.InfraStructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private int id;
        private List<Owner> _owners = new List<Owner>();

        public OwnerRepository()
        {
            this.id = 0;
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
            var ownerFound = ReadOwnerById(id);
            if (ownerFound != null)
            {
                _owners.Remove(ownerFound);
                return ownerFound;
            }

            return null;
        }

        public IEnumerable<Owner> ReadAllOwners()
        {
            return _owners.AsReadOnly();
        }

        public IEnumerable<Owner> ReadAllOwnersWithFilter(Filter filter)
        {
            IEnumerable<Owner> owners = _owners.AsEnumerable();
            if (!string.IsNullOrEmpty(filter.Name))
            {
                owners = from x in owners where x.FirstName.ToLower().Contains(filter.Name.ToLower()) select x;
            }
            if (!string.IsNullOrEmpty(filter.Name))
            {
                owners = from x in owners where x.LastName.ToLower().Contains(filter.Owner.ToLower()) select x;
            }
            return owners.ToList();
        }

        public Owner UpdateOwner(Owner owner)
        {
            Owner ownerToUpdate = ((List<Owner>)_owners).Find((x) => { return x.Id == owner.Id; });
            if (ownerToUpdate != null)
            {
                ownerToUpdate.FirstName = owner.FirstName;
                ownerToUpdate.LastName = owner.LastName;
                ownerToUpdate.Address = owner.Address;
                ownerToUpdate.PhoneNumber = owner.PhoneNumber;
                ownerToUpdate.Email = owner.Email;

                return ownerToUpdate;
            }
            return null;
        }
    }
}
