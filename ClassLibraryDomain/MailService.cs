using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain
{
    public class MailService
    {

        private static readonly MailService Instance=new MailService();

        public Mail MakeMail(MailUser to, MailUser from, String msg, String body, ISet<Classification> classification)
        {
            Mail mail = MailFactory.GetInstance().GetMail(from, to, DateTime.Now, msg, body,classification);
            return  Repository<Mail>.GetInstance().Add(mail);
        }


        public bool SendMAil(Mail mail)
        {
            return true;
        }


        public MailService GetInsTance()
        {
            return Instance;
        }
    }
}

