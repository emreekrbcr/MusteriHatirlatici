using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.MyAttributes;

namespace Core.Tools.MyExceptions
{
    [KnownException]
    public class ParameterNullException:Exception
    {
        public ParameterNullException(string message):base(message) { }
    }
}
