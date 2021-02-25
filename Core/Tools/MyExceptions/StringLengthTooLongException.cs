using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.MyAttributes;

namespace Core.Tools.MyExceptions
{
    [KnownException]
    public class StringLengthTooLongException:Exception
    {
        //public override string Message //bu da bir yöntem
        //{
        //    get { return "Given string is too long"; }
        //}

        public StringLengthTooLongException(string message):base(message) { }
    }
}
