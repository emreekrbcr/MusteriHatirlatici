using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.MyAttributes;

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        [PrimaryKey] //Primarykey ile bir kontrol yapacağım
        public int MusteriID { get; set; }
        [Required][MaxLength(50)] //Gerekli ve maksimum 50 karakter
        public string Isim { get; set; }
        [MaxLength(20)]
        public string Telefon { get; set; }
        [MaxLength(150)]
        public string Adres { get; set; }
        [MaxLength(255)]
        public string Aciklama { get; set; }
    }
}
