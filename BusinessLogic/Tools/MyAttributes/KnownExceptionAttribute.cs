using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tools.MyAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class KnownExceptionAttribute:Attribute
    {
    }
}
