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

        public Owner UpdateOwner(Owner ownerUpdate)
        {
            var owner = GetOwnerById(ownerUpdate.Id);
            owner.FirstName = ownerUpdate.FirstName;
            owner.LastName = ownerUpdate.LastName;
            owner.Address = ownerUpdate.Address;
            owner.PhoneNumber = ownerUpdate.PhoneNumber;
            owner.Email = ownerUpdate.Email;            
            return owner;
        }
        public Owner DeleteOwner(int id)
        {
            return _ownerRepo.DeleteOwner(id);
        }
    }
}
