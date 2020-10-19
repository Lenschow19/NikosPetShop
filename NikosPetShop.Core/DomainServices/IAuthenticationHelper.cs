using NikosPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NikosPetShop.Core.DomainServices
{
    public interface IAuthenticationHelper
    {
        public string GenerateJWTToken(User user);
        public void ValidateLogin(User userToValidate, LoginInputModel inputModel);
        public byte[] GenerateHash(string password, byte[] salt);
        public byte[] GenerateSalt();
    }
}
