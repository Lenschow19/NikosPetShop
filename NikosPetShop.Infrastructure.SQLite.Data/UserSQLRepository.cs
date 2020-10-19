using Microsoft.EntityFrameworkCore;
using NikosPetShop.Core.DomainServices;
using NikosPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NikosPetShop.Infrastructure.SQLite.Data
{
    public class UserSQLRepository: IUserRepository
    {
        private NikosPetShopLiteContext ctx;

        public UserSQLRepository(NikosPetShopLiteContext ctx)
        {
            this.ctx = ctx;
        }

        public User AddUser(User user)
        {
            ctx.Attach(user).State = EntityState.Added;
            ctx.SaveChanges();
            return user;
        }
        public IEnumerable<User> ReadUsers()
        {
            return ctx.Users.AsEnumerable();
        }

        public User GetUserByID(int ID)
        {
            return ctx.Users.AsNoTracking().FirstOrDefault(x => x.UserID == ID);
        }
        public User UpdateUser(User user)
        {
            ctx.Attach(user).State = EntityState.Modified;
            ctx.SaveChanges();
            return user;
        }
        public User DeleteUser(int ID)
        {
            var deletedUser = ctx.Users.Remove(GetUserByID(ID));
            ctx.SaveChanges();
            return deletedUser.Entity;
        }
    }
}
