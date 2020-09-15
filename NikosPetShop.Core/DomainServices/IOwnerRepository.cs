using NikosPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NikosPetShop.Core.DomainServices
{
    public interface IOwnerRepository
    {
        //Create Data
        Owner CreateOwner(Owner owner);
        //Read Data
        Owner ReadOwnerById(int id);
        IEnumerable<Owner> ReadAllOwners();
        //Update Data
        Owner UpdateOwner(Owner ownerUpdate);
        //Delete Data
        Owner DeleteOwner(int id);
    }
}
