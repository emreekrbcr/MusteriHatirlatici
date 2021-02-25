using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace BusinessLogic.Abstract
{
    public interface IOperationService
    {
        List<Operation> GetOperationsByCustomerID(int customerID);
        List<Operation> SortOperationsByName(int customerID);
        List<Operation> SortOperationsByRemainingDay(int customerID);
        void Insert(Operation operation);
        void Update(Operation operation);
        void Delete(Operation operation);
    }
}
