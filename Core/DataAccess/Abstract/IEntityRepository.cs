using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace Core.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T:class,IEntity,new ()
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity); //int değil de class olarak parametre göndermemin sebebi farklı tablolarda id'nin yani primary key'in farklı isimlerle tutulabiliyor olma ihtimali
                               //ayrıca ufak ihtimalde olsa primary key birden fazla olabilir(normal koşullarda olmuyor)
                               //daha sonra reflection ile ulaşıp, ilgili class'ın primary key olan property'sini çekeceğim
    }
}
