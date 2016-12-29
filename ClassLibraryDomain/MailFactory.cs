using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClassLibraryDomain
{
    public class MailFactory : IMailFactory
    {

        private static MailFactory Instance = new MailFactory();

        private MailFactory()
        {
            
        }
    

    private readonly MailValidator _mailValidator=new MailValidator();
       public string Encode(string message)
       {
           throw new NotImplementedException();
       }


       public Mail GetMail(MailUser fromMailUser, MailUser toMailUser, DateTime dateTime, string message, string body,ISet<Classification> classifications)
       {
           Mail mail = new Mail(fromMailUser, toMailUser, dateTime, message, body);
           if (classifications != null) classifications.ToList().ForEach(m => mail.AddClasification(m));
           
               _mailValidator.MailValide(mail);
          
       
           
           return mail;
       }

        public static MailFactory  GetInstance()
        {
            return Instance;
        }
    }

    public interface IMailFactory
    {
      String Encode(String message);
        Mail GetMail(MailUser fromMailUser, MailUser toMailUser, DateTime dateTime, string message, string body,ISet<Classification> classifications);
        



    }
}
