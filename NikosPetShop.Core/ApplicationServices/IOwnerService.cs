using NikosPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NikosPetShop.Core.ApplicationServices
{
    public interface IOwnerService
    {
        //Create
        Owner newOwner(string FirstName, string LastName, 
            string Address, string PhoneNumber, string Email);
        Owner CreateOwner(Owner owner);
        //Read
        List<Owner> GetAllOwners();
        List<Owner> GetOwnersWithFilter(Filter filter);
        Owner GetOwnerById(int id);
        //Update
        Owner UpdateOwner(Owner owner, int id);
        //Delete
        Owner DeleteOwner(int id);
    }
}
