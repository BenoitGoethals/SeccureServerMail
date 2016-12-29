using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain
{
    public class Mail
    {
        public Mail( MailUser from, MailUser to, DateTime dateTime, string message, string body )
        {
            From = from;
            To = to;
            DateTime = dateTime;
            Message = message;
            Body = body;
           
            Classifications = new SortedClassifications();
        }

        public SortedClassifications Classifications { get; set; }

        public MailUser From { get; set; }

        public MailUser To { get; set; }

        public DateTime DateTime { get; set; }

        public string Message { get; set; }

        public string Body { get; set; }

        public DateTime ReadDateTime { get; set; }


        public void AddClasification(Classification classification)
        {
            Classifications.Add(classification);
        }
    }
}
