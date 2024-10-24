using Golestan.Contracts;
using Golestan.DataBase;
using Golestan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Golestan.Repository
{
    public class UserRepository : IUserRepository
    { 
        public User GetCurrentUser()
        {
            return InMemorryDb.CurrentUser;
        }

        public void Register(User user)
        {
            InMemorryDb.Users.Add(user);
        }

        public List<User> GetUsers()
        {
            return InMemorryDb.Users;
        }

        public void Login(User user)
        {
            InMemorryDb.CurrentUser = user;
        }

        public void LogOut()
        {
            InMemorryDb.CurrentUser = null;
        }

        public void RemoveUser(User user)
        {
            InMemorryDb.Users.Remove(user);
        }
    }
}
