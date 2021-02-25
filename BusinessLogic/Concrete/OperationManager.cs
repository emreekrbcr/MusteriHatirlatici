using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BusinessLogic.Abstract;
using Core.Tools.MyExceptions;
using DataAccess.Abstract;
using DataAccess.Concrete.AccessAdonet;
using Entities.Concrete;

namespace BusinessLogic.Concrete
{
    public class OperationManager : IOperationService
    {
        private IOperationDal _operationDal;

        //public OperationManager(IOperationDal operationDal)
        //{
        //    _operationDal = operationDal;
        //}
        public OperationManager()
        {
            _operationDal = new AccessOperationDal();
        }

        public List<Operation> GetOperationsByCustomerID(int customerID)
        {
            return _operationDal.GetOperationsByCustomerID(customerID);
        }

        public List<Operation> SortOperationsByName(int customerID)
        {
            return _operationDal.SortOperationsByName(customerID);
        }

        public List<Operation> SortOperationsByRemainingDay(int customerID)
        {
            return _operationDal.SortOperationsByRemainingDay(customerID);
        }

        public void Insert(Operation operation)
        {
            OperationValidation(operation);
            operation.Borc = operation.Tutar - operation.Odenen; //Borcu hesaplattım
            _operationDal.Insert(operation);
        }

        public void Update(Operation operation)
        {
            OperationValidation(operation);
            operation.Borc = operation.Tutar - operation.Odenen; //Borcu hesaplattım
            _operationDal.Update(operation);
        }

        public void Delete(Operation operation)
        {
            _operationDal.Delete(operation);
        }

        private static void OperationValidation(Operation operation)
        {
            if (operation.MusteriID.ToString().Length == 0)
            {
                throw new ParameterNullException("Müşteri ID'si boş olamaz(Programla alakalı)");
            }

            if (operation.Islem.Length > 255)
            {
                throw new StringLengthTooLongException("İşlem 255 karakterden fazla olamaz");
            }

            if (operation.Islem.Length == 0)
            {
                throw new ParameterNullException("İşlem adı boş bırakılamaz");
            }

            if (operation.Tutar > 999999)
            {
                throw new MoneyTooMuchException("Tutar miktarı 999999'dan büyük olamaz");
            }

            if (operation.Tutar < 0)
            {
                throw new CanNotNegativeException("Tutar negatif olamaz");
            }

            if (operation.Odenen > 999999)
            {
                throw new MoneyTooMuchException("Ödenen miktarı 999999'dan büyük olamaz");
            }

            if (operation.Odenen < 0)
            {
                throw new CanNotNegativeException("Ödenen negatif olamaz");
            }

            if (operation.Tutar - operation.Odenen < 0)
            {
                throw new CanNotNegativeException("Ödenen para miktarı tutardan büyük olamaz");
            }

            if (operation.IslemTarihi.Date.ToString("dd.MM.yyyy").Length == 0)
            {
                throw new ParameterNullException("İşlem tarihi boş bırakılamaz(Programla alakalı)");
            }

            if (operation.HatirlatmaTarihi.Date.ToString("dd.MM.yyyy").Length == 0)
            {
                throw new ParameterNullException("Hatırlatma tarihi boş bırakılamaz(Programla alakalı)");
            }

            if ((operation.HatirlatmaTarihi - operation.IslemTarihi).TotalDays < 0
            ) //Tarih farkı bir TimeSpan class'ı üyesi olduğu için TotalDays
            {
                throw new CanNotNegativeException("Hatırlatma tarihi, işlem tarihinden daha ileride olmalıdır");
            }
        }
    }
}
