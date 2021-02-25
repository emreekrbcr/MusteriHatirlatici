using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using Microsoft.SqlServer.Server;

namespace Core.DataAccess.Concrete.AccessAdonet
{
    public class AccessEntityRepositoryBase<T> : IEntityRepository<T> where T : class, IEntity, new()
    {
        protected DBConnection dbConnection;

        public AccessEntityRepositoryBase()
        {
            dbConnection = DBConnection.GetInstance(); //Singleton Pattern ile bir kere oluşmasını garanti ettim
        }

        public void Insert(T entity)
        {
            var sqlString = InsertStringBuilder(entity, out var prmValues, out var prmPlaceHolders);
            OleDbCommand command = dbConnection.GetCommandAfterConCont(sqlString);
            for (int i = 0; i < prmPlaceHolders.Count; i++)
            {
                // Sql Injectiona maruz kalmamak için sorguya yazılacak değerleri stringleri concatenate ederek değil, bu şekilde parametre yoluyla eklemek çok önemli!!!
                command.Parameters.AddWithValue(prmPlaceHolders[i], prmValues[i]);
            }
            command.ExecuteNonQuery();
            command.Connection.Close(); // bağlantı işini görünce kapanıyor kontrol edildi, sıkıntı yok
        }

        public void Update(T entity)
        {
            var sqlString = UpdateStringBuilder(entity, out var prmValues, out var prmPlaceHolders);
            OleDbCommand command = dbConnection.GetCommandAfterConCont(sqlString);
            for (int i = 0; i < prmPlaceHolders.Count; i++)
            {
                command.Parameters.AddWithValue(prmPlaceHolders[i], prmValues[i]);
            }
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public void Delete(T entity)
        {
            var sqlString = DeleteStringBuilder(entity, out var prmValues, out var prmPlaceHolders);
            OleDbCommand command = dbConnection.GetCommandAfterConCont(sqlString);
            for (int i = 0; i < prmPlaceHolders.Count; i++)
            {
                command.Parameters.AddWithValue(prmPlaceHolders[i], prmValues[i]);
            }
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        private string InsertStringBuilder(T entity, out ArrayList prmValues, out List<string> prmPlaceHolders)
        {
            string sqlString = "Insert into [" + GetTableName() + "] (";
            var props = typeof(T).GetProperties();
            prmValues = new ArrayList();
            prmPlaceHolders = new List<string>();
            foreach (var prop in props)
            {
                if (IsPrimaryKey(prop))
                    continue; // eğer PrimaryKey geldiyse döngüyü 1 adım atlasın çünkü veritabanında otomatik artan olarak belirledik
                sqlString += prop.Name + ",";
            }

            sqlString = sqlString.Substring(0, sqlString.Length - 1) + ") values (";
            for (int i = 0; i < props.Length; i++)
            {
                var value = props[i].GetValue(entity); //karşılık geldiği sütunun değerini tutar
                if (IsPrimaryKey(props[i]))
                    continue; // eğer PrimaryKey geldiyse döngüyü 1 adım atlasın çünkü veritabanında otomatik artan olarak belirledik
                prmValues.Add(value); //sql kodu çalıştırırken birazdan lazım olacak
                prmPlaceHolders.Add("@p" + i.ToString()); //birazdan lazım olacak
                sqlString +=
                    "@p" + i.ToString() +
                    ","; // Insert into Musteriler (Column1,Column2) values (@p1,@p2) gibi oldu, ayrıca primarykey'i girmemize gerek olmadığı için atladı
            }

            sqlString = sqlString.Substring(0, sqlString.Length - 1) +
                        ")"; //en sonda bir virgül kalıyor, onu bu şekilde yok ettim ve parantez ekledim

            //artık sql kodunu, parametreleri, placeholder'ları elde ettik, bundan sonra normal insert işlemi
            return sqlString;
        }
        private string UpdateStringBuilder(T entity, out ArrayList prmValues, out List<string> prmPlaceHolders)
        {
            //Update [Musteriler] set Isim=@p1,Telefon=@p2,Adres=@p3,Aciklama=@p4 where MusteriID=@p0 olması lazım örneğin
            //ÖNEMLİ!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!ÖNEMLİ
            //yukarıdaki gibi olunca hata çıkıyor, kesinlikle yapma command.Parameters.AddWithValue ile yukarıda kullanırken
            //parametreler soldan sağa doğru olması lazım yani olması gereken format;
            //Update [Musteriler] set Isim=@p0,Telefon=@p1,Adres=@p2,Aciklama=@p3 where MusteriID=@p4
            string sqlString = "Update [" + GetTableName() + "] set ";
            var props = typeof(T).GetProperties();
            prmValues = new ArrayList();
            prmPlaceHolders = new List<string>();
            int afterPkIndex = 0; //primary key'leri atladıktan sonra hangi indexte kaldıysak onu tutacak. Örneğin bir tane var ve 1'i tuttu daha sonra diğer özellikleri eklerken i-afterPkIndex şeklinde kullanacağız
            int currentPlaceHolderIndex = 0; // Yukarıdaki açıklamada en sonki formatı yakalamak için placeholderlar @p0,@p1,@p2... gitsin diye where'den öncesine kadar hangi indexte kaldığını tutmak için
            
            for (int i = 0; i < props.Length; i++) //where'den öncesi
            {
                if (IsPrimaryKey(props[i]))
                {
                    afterPkIndex++;
                    continue;
                }
                var value = props[i].GetValue(entity);
                prmValues.Add(value);
                prmPlaceHolders.Add("@p" + (i - afterPkIndex).ToString()); //soldan itibaren 0'dan başlatmak için
                sqlString += props[i].Name + "=" + "@p" + (i - afterPkIndex).ToString() + ",";
                currentPlaceHolderIndex++;
            }

            sqlString = sqlString.Substring(0, sqlString.Length - 1) + " where ";

            for (int i = currentPlaceHolderIndex; i < props.Length; i++)//where'den sonrası
            {
                var value = props[i - currentPlaceHolderIndex].GetValue(entity);
                prmValues.Add(value);
                prmPlaceHolders.Add("@p"+i.ToString());
                sqlString += props[i - currentPlaceHolderIndex].Name + "=" + "@p" + i.ToString()+",";
            }

            sqlString = sqlString.Substring(0, sqlString.Length - 1);
            //Buradan sonra normal Update işlemi
            return sqlString;
        }
        private string DeleteStringBuilder(T entity, out ArrayList prmValues, out List<string> prmPlaceHolders)
        {
            //Delete from [Musteriler] where MusteriID=@p0 gibi olacak
            string sqlString = "Delete from [" + GetTableName() + "] where ";
            var props = typeof(T).GetProperties();
            prmValues = new ArrayList();
            prmPlaceHolders = new List<string>();

            for (int i = 0; i < props.Length; i++)
            {
                if (IsPrimaryKey(props[i]))
                {
                    var value = props[i].GetValue(entity);
                    prmValues.Add(value);
                    prmPlaceHolders.Add("@p" + i.ToString());
                    sqlString += props[i].Name + "=" + "@p" + i.ToString() + ",";
                }
            }

            sqlString = sqlString.Substring(0, sqlString.Length - 1);
            //sql stringi elde edildi bundan sonrası delete işlemi
            return sqlString;
        }
        private string GetTableName() //Gelen sınıf bilgisine tablo adını belirleyen metod (Tablo adları Türkçe olduğu için mecburen)
        {
            if (typeof(T).ToString().Contains("Customer"))
            {
                return "Musteriler";
            }

            if (typeof(T).ToString().Contains("Operation"))
            {
                return "Islemler";
            }
            return "";
        }
        private static bool IsPrimaryKey(PropertyInfo prop) //Gelen property'nin attribute'larına göre Primary key kontrolü yapar
        {
            var attributes = prop.GetCustomAttributes();
            string attributesString = "";
            foreach (var attribute in attributes)
            {
                attributesString += attribute.ToString();
            }
            if (attributesString.Contains("PrimaryKey"))
            {
                return true;
            }
            return false;
        }
    }
}
