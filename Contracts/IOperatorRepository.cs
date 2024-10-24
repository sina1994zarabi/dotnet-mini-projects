using Golestan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Golestan.Contracts
{
    public interface IOperatorRepository
    {
        public void AddOperator(Operator @operator);

        public List<Operator> GetOperators();

        public void UpdateOperator(Operator @operator);

        public void RemoveOperator(Operator @operator);
    }
}
