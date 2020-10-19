using Microsoft.EntityFrameworkCore;
using NikosPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NikosPetShop.Infrastructure.SQLite.Data
{
    public class NikosPetShopLiteContext: DbContext
    {
        public NikosPetShopLiteContext(DbContextOptions<NikosPetShopLiteContext> opt) : base(opt) { }

        public DbSet<Pet> pets { get; set; }
        public DbSet<PetType> petTypes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
