using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tools.Feedback.Abstract
{
    public interface IMailSender
    {
        void SendMail();
    }
}
