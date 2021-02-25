using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Tools.Feedback.Abstract;
using Core.Tools.Feedback.Abstract;
using Core.Tools.Feedback.Concrete;

namespace BusinessLogic.Tools.Feedback.Concrete
{
    public class BusinessLogSender:IBusinessMailSender
    {
        private IMailSender _mailSender;

        public BusinessLogSender()
        {
            _mailSender = new LogSender();
        }
        public void SendMail()
        {
            _mailSender.SendMail();
        }

    }
}
