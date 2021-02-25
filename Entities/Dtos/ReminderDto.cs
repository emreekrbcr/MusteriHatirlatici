using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace Entities.Dtos
{
    public class ReminderDto:IEntity
    {
        public string Isim { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string Aciklama { get; set; }
        public string Islem { get; set; }
        public double Borc { get; set; }
        public int KalanGun { get; set; }
    }
}
