using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Tools.MyAttributes;

namespace UI.WinForm.FrontEndExceptions
{
    //bunu public yapmaya gerek yok, internal kalsın, çünkü zaten kullanıcıya olan en uç katmanda(Uç Beyi)
    //Bir şeyin ihtiyacı ne kadarsa o kadar ver(Least Privilege)
    [KnownException]
    class DgwItemNotSelectedException : Exception
    {
        public DgwItemNotSelectedException(string message) : base(message)
        {
        }
    }
}
