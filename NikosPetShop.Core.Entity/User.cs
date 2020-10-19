using System;
using System.Collections.Generic;
using System.Text;

namespace NikosPetShop.Core.Entity
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }
        public string UserRole { get; set; }
    }
}
