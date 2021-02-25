using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Abstract;
using Core.Tools.MyExceptions;
using DataAccess.Abstract;
using DataAccess.Concrete.AccessAdonet;
using Entities.Concrete;

namespace BusinessLogic.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal; //Projeyi yarın bir gün Adonet'ten Entity Framework'a geçirirsek mesela kodda bir değişiklik yapmamıza gerek kalmayacak 

        //public CustomerManager(ICustomerDal customerDal)
        //{
        //    _customerDal = customerDal;
        //}

        public CustomerManager()
        {
            _customerDal = new AccessCustomerDal();
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerDal.GetAllCustomers();
        }

        public List<Customer> GetCustomerByName(string searchingKey)
        {
            return _customerDal.GetCustomerByName(searchingKey);
        }

        public List<Customer> SortCustomersByName()
        {
            return _customerDal.SortCustomersByName();
        }

        public void Insert(Customer customer)
        {
            //Buradaki kontrollerin class'ın içine koyduğumuz attributelara, reflection ile ulaşarak yapılması ileride müşterinin
            //ihtiyaçlarının değişme ihtimaline karşı daha iyi olur ve entities katmanında attributelarda bir değişiklik yapıldığında
            //buraları da değiştirmeye gerek kalmaz ama bu projede bunu yapmaya pek gerek yok
            CustomerValidation(customer);
            _customerDal.Insert(customer); //Hatasız kul olmaz ama hatasız çalışma durumu :) Ayrıca yukarıdaki hataları front end'de de kontrol altına alacağım
        }

        public void Update(Customer customer)
        {
            CustomerValidation(customer);
            _customerDal.Update(customer); //Hatasız kul olmaz ama hatasız çalışma durumu :) Ayrıca yukarıdaki hataları front end'de de kontrol altına alacağım

        }

        public void Delete(Customer customer)
        {
            _customerDal.Delete(customer);
        }

        private static void CustomerValidation(Customer customer)
        {
            if (customer.Isim.Length > 50)
            {
                throw new StringLengthTooLongException("Müşteri adı 50 karakterden fazla olamaz");
            }

            if (customer.Isim.Length == 0)
            {
                throw new ParameterNullException("Müşteri adı boş olamaz");
            }

            if (customer.Telefon.Length > 20)
            {
                throw new StringLengthTooLongException("Telefon numarası 20 karakterden fazla olamaz");
            }

            if (customer.Adres.Length > 150)
            {
                throw new StringLengthTooLongException("Adres 150 karakterden fazla olamaz");
            }

            if (customer.Aciklama.Length > 255)
            {
                throw new StringLengthTooLongException("Müşteri açıklaması 255 karakterden fazla olamaz");
            }
        }
    }
}