using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mailing.FakeMail
{
    public class FakeMailService : IMailService
    {
        public void SendMail(Mail mail)
        {
            throw new NotImplementedException();
        }
    }
}
