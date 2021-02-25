using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Tools.Logger.Abstract;
using Core.Tools.Logger.Abstract;
using Core.Tools.Logger.Concrete;

namespace BusinessLogic.Tools.Logger.Concrete
{
    public class BusinessFileLogger : IBusinessLogger
    {
        private ILogger _logger;

        public BusinessFileLogger()
        {
            _logger=new FileLogger();
        }

        public void Log(Exception exception)
        {
            _logger.Log(exception);
        }
    }
}
