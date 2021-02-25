using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations; //Validation yapmak için
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;
using Core.Tools.MyAttributes;

namespace Entities.Concrete
{
    public class Operation:IEntity
    { 
        [PrimaryKey]
        public int IslemID { get; set; }
        [Required]
        public int MusteriID { get; set; }
        [Required][MaxLength(255)]
        public string Islem { get; set; }
        [Required][MaxMoney(999999)]
        public double Tutar { get; set; } //Bunları double yaptım çünkü decimal olunca textboxta 15,43 gibi ,'lü yazsan mesela 1543 gibi algılıyor
        [Required][MaxMoney(999999)]
        public double Odenen { get; set; } //Tutardan küçük olmak zorunda
        [Required] [MaxMoney(999999)]
        public double Borc { get; set; }
        [Required]
        public DateTime IslemTarihi { get; set; }
        [Required]
        public DateTime HatirlatmaTarihi { get; set; } //Islem tarihinden ileride olmak zorunda :)
    }
}
