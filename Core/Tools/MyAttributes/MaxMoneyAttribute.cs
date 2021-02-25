using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tools.MyAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxMoneyAttribute : Attribute
    {
        private int _money;
        public MaxMoneyAttribute(int money)
        {
            _money = money;
        }
    }
}
