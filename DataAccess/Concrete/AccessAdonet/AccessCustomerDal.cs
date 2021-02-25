using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Concrete.AccessAdonet;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.AccessAdonet
{
    public class AccessCustomerDal:AccessEntityRepositoryBase<Customer>,ICustomerDal
    {
        public List<Customer> GetAllCustomers()
        {
            OleDbCommand command = dbConnection.GetCommandAfterConCont("Select * from Musteriler order by MusteriID");
            //sanırım access'ten dolayı manuel eklenenleri sonra getiriyor, MusteriID'ye göre sıralamasını garanti altına aldım
            OleDbDataReader reader = command.ExecuteReader();
            List<Customer> customers=new List<Customer>();
            while (reader.Read())
            {
                Customer customer=new Customer()
                {
                    MusteriID = (int)reader["MusteriID"], //reader object döndürdüğü için cast ettim
                    Isim = (string)reader["Isim"],
                    Telefon = (string)reader["Telefon"],
                    Adres = (string)reader["Adres"],
                    Aciklama = (string)reader["Aciklama"]
                };
                customers.Add(customer);
            }
            reader.Close();
            command.Connection.Close();
            return customers;
        }

        public List<Customer> GetCustomerByName(string searchingKey)
        {
            //linq ile direk yukarıdaki sorgunun sonucuna filtre attım
            //artık listeye döndükten sonra c# case-sensitive old.için iki taraftada harfi küçük yaptım
            return GetAllCustomers().Where(c => c.Isim.ToLower().Contains(searchingKey.ToLower())).ToList();
        }

        public List<Customer> SortCustomersByName()
        {
            return GetAllCustomers().OrderBy(c => c.Isim).ToList();
        }
    }
}
