using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.Logger.Abstract;

namespace BusinessLogic.Tools.Logger.Abstract
{
    public interface IBusinessLogger
    {
        void Log(Exception exception);
    }
}
