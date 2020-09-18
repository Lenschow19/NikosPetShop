using NikosPetShop.Core.DomainServices;
using NikosPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NikosPetShop.Core.ApplicationServices.Impl
{
    public class OwnerService : IOwnerService
    {
        readonly IOwnerRepository _ownerRepo;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepo = ownerRepository;
        }
        
        public Owner newOwner(string FirstName, string LastName, string Address, string PhoneNumber, string Email)
        {
            var owner = new Owner()
            {
                FirstName = FirstName,
                LastName = LastName,
                Address = Address,
                PhoneNumber = PhoneNumber,
                Email = Email
            };

            return owner; ;
        }

        public Owner CreateOwner(Owner owner)
        {
            return _ownerRepo.CreateOwner(owner);
        }

        

        public List<Owner> GetAllOwners()
        {
            return _ownerRepo.ReadAllOwners().ToList();
        }

        public Owner GetOwnerById(int id)
        {
            return _ownerRepo.ReadOwnerById(id);
        }

        public Owner DeleteOwner(int id)
        {
            return _ownerRepo.DeleteOwner(id);
        }

        public Owner UpdateOwner(Owner owner, int id)
        {
            if (GetOwnerById(id) == null)
            {
                throw new ArgumentException("Owner with entered ID not found.");
            }
            if (owner == null)
            {
                throw new ArgumentException("Can't find owner with entered ID.");
            }
            owner.Id = id;
            return _ownerRepo.UpdateOwner(owner);
        }

        public List<Owner> GetOwnersWithFilter(Filter filter)
        {
            return _ownerRepo.ReadAllOwnersWithFilter(filter).ToList();
        }
    }
}
