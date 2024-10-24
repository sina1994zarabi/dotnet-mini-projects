using Golestan.Contracts;
using Golestan.DataBase;
using Golestan.Entities;
using Golestan.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Golestan.Services
{
    public class UserServices
    {
        public IUserRepository _userRepository;
        

        public UserServices()
        {
            _userRepository = new UserRepository();
        }

        public Result Login(string userName,string passWord)
        {
            var users = _userRepository.GetUsers();
            foreach (var user in users)
            {
                if (user.Username == userName)
                {
                    if (user.Password == passWord)
                    {
                        _userRepository.Login(user);
                        return new Result(true, "Logged In Successfully");
                    }
                }
            }
            return new Result(false, "User Not Found");
        }

        public Result Register(User newUser)
        {
            _userRepository.Register(newUser);
            return new Result(true, "Successfully Registered");
        }

        public User GetCurrentUser()
        {
            return _userRepository.GetCurrentUser();
        }

        public List<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public void Logout()
        { 
            _userRepository.LogOut();
        }




    }
}
