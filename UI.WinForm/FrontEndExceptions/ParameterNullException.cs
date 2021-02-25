using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Tools.MyAttributes;

namespace UI.WinForm.FrontEndExceptions
{
    [KnownException]
    class ParameterNullException:Exception
    {
        public ParameterNullException(string message):base(message)
        {
        }
    }
}
