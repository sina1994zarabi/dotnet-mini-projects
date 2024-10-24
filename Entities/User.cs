using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Golestan.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; } = false;

        public User(string firstname,string lastname,string email)
        {
            Firstname = firstname;
            Lastname = lastname;
            Username = email;
        }

        public override string ToString()
        {
            return $"Id: {Id} - UserName {Username}";
        }

        public virtual void SetId()
        {
            Random random = new Random();
            int id = random.Next(0, 100);
            Id = id;
        }

        public void SetActive()
        {
            Active = true;
        }

        public Result SetPassword(string password)
        {
            if (!string.IsNullOrEmpty(password) && password.Length >= 8 && IsComplex(password))
            {
                Password = password;
                return new Result(true, "Password Set Successfully");
            }
            else
            {
                return new Result(false, "Password Empty Or Not Complex Enough (Hint: Password Must Contain At Least one special character,upper and lower case)");
            }
        }

        public Result ChangePassword(string newPass,string currentPass)
        {
            if (!string.IsNullOrEmpty(newPass))
            {
                if (newPass != currentPass)
                {
                    if (IsComplex(newPass))
                    {
                        Password = newPass;
                        return new Result(true, "Password Changed Successfully");
                    }
                    else
                    {
                        return new Result(false, "Password Not Complex Enough");
                    }
                }
                else
                {
                    return new Result(false, "New Password The Same as the Old One");
                }
            }
            else
            {
                return new Result(false,"Password Empty");
            }
        }

        public Result ChangeUsername(string newUsername)
        {
            if (!string.IsNullOrEmpty(newUsername) && Username.Length >= 10)
            {
                Username = newUsername;
                return new Result(true, "Username changed successfully");
            }
            else
            {
                return new Result(false, "UserName Empty or Too Short");
            }
        }

        public bool IsComplex(string password)
        {
            Char[] specialChar = {'.','@','-','_','$','%','&','*'};
            bool HasUpper = false;
            bool HasLower = false;
            bool HasSpecial = false;
            foreach (char c in password)
            {
                if (Char.IsLower(c)) HasUpper = true;
                if (Char.IsUpper(c)) HasLower = true;
                if (specialChar.Contains(c)) HasSpecial = true;
            }
            return HasUpper && HasLower && HasSpecial;
        }
    }
}
