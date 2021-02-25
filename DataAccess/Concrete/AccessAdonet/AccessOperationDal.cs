using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Concrete.AccessAdonet;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.AccessAdonet
{
    public class AccessOperationDal:AccessEntityRepositoryBase<Operation>,IOperationDal
    {
        public List<Operation> GetOperationsByCustomerID(int customerID)
        {
            OleDbCommand command = dbConnection.GetCommandAfterConCont("select * from Islemler where MusteriID=@musteriID");
            command.Parameters.AddWithValue("@musteriID", customerID);
            //stringleri concatenate ederek değil de parametre kullanarak sorgu yapılmasının sebebi sql injection saldırısına maruz kalmamaktır!
            OleDbDataReader reader = command.ExecuteReader();
            List<Operation> operations=new List<Operation>();
            while (reader.Read())
            {
                Operation operation=new Operation()
                {
                    IslemID = (int)reader["IslemID"],
                    MusteriID = (int)reader["MusteriID"],
                    Islem = (string)reader["Islem"],
                    Tutar = Convert.ToDouble(reader["Tutar"]),
                    Odenen = Convert.ToDouble(reader["Odenen"]),
                    Borc = Convert.ToDouble(reader["Borc"]),
                    IslemTarihi = (DateTime)reader["IslemTarihi"],
                    HatirlatmaTarihi = (DateTime)reader["HatirlatmaTarihi"]
                };
                operations.Add(operation);
            }
            reader.Close();
            command.Connection.Close();
            return operations;
        }

        public List<Operation> SortOperationsByName(int customerID)
        {
            return GetOperationsByCustomerID(customerID).OrderBy(o => o.Islem).ToList();
        }

        public List<Operation> SortOperationsByRemainingDay(int customerID)
        {
            return GetOperationsByCustomerID(customerID).OrderBy(o=>o.HatirlatmaTarihi-DateTime.Now).ToList();
        }
    }
}
