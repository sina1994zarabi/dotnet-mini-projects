using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Golestan.Entities;

namespace Golestan.Contracts
{
    public interface IUserRepository
    {
        public User GetCurrentUser();

        public void Register(User user);

        public List<User> GetUsers();

        public void Login(User user);

        public void LogOut();

        public void RemoveUser(User user);

    }
}
