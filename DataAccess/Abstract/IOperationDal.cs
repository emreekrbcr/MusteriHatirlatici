using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IOperationDal:IEntityRepository<Operation>
    {
        List<Operation> GetOperationsByCustomerID(int customerID);
        List<Operation> SortOperationsByName(int customerID);
        List<Operation> SortOperationsByRemainingDay(int customerID);
    }
}
