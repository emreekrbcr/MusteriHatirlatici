using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tools.MyAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKeyAttribute:Attribute
    {
    }
}
