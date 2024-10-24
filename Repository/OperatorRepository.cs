using Golestan.Contracts;
using Golestan.DataBase;
using Golestan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golestan.Repository
{
    public class OperatorRepository : IOperatorRepository
    {
        public void AddOperator(Operator @operator)
        {
            InMemorryDb.Users.Add(@operator);
        }

        public List<Operator> GetOperators()
        {
            List<Operator> result = new List<Operator>();
            var users = InMemorryDb.Users;
            foreach (User user in users)
            {
                if (user is Operator)
                {
                    result.Add((Operator)user);
                }
            }
            return result;
        }

        public void UpdateOperator(Operator @operator)
        {
            
        }

        public void RemoveOperator(Operator @operator)
        {
            InMemorryDb.Users.Remove(@operator);
        }
    }
}
