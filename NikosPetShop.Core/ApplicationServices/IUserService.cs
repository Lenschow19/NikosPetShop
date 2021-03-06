﻿using NikosPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NikosPetShop.Core.ApplicationServices
{
    public interface IUserService
    {
        User Login(LoginInputModel inputModel);

        User CreateUser(string userName, string password, string userRole);

        User AddUser(User user);

        List<User> GetAllUsers();

        User GetUserByID(int ID);

        User UpdateUser(User user, int ID);

        User DeleteUser(int ID);
    }
}
