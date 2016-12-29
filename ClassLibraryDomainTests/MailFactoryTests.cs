using System;
using System.Collections.Generic;
using ClassLibraryDomain;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassLibraryDomainTests
{
    [TestClass()]
    public class MailFactoryTests
    {
        [TestMethod() ]

        [ExpectedException(typeof(ValidationException))]
        public void ValidateTest()
        {
            IMailFactory factory = new MailFactory();
            MailUser mailUser = null;
            MailUser user2 = new MailUser();

           

          Mail  mail = factory.GetMail(mailUser, user2, new DateTime(), "test", "test", new SortedSet<Classification>() { ClassificationPool.GetInstance().GetClassification(ClassType.NATOSECRET), ClassificationPool.GetInstance().GetClassification(ClassType.EUSECRET) });

            Assert.AreEqual(2, mail.Classifications.Count);
        }

        [TestMethod()]
        public void GetMailTest()
        {
            IMailFactory factory=new MailFactory();
            MailUser mailUser=new MailUser();
            MailUser user2=new MailUser();
           
           
           Mail mail= factory.GetMail(mailUser, user2,new DateTime(),"test","test",null);
            mail.AddClasification(ClassificationPool.GetInstance().GetClassification(ClassType.ATOML));
            Assert.IsNotNull(mail.Classifications);
        }



        [TestMethod()]
        public void GetMailClassificationTest()
        {
            IMailFactory factory = new MailFactory();
            MailUser mailUser = new MailUser();
            MailUser user2 = new MailUser();


            Mail mail = factory.GetMail(mailUser, user2, new DateTime(), "test", "test", new SortedSet<Classification>() { ClassificationPool.GetInstance().GetClassification(ClassType.ATOML) , ClassificationPool.GetInstance().GetClassification(ClassType.ATOML) });
           
           Assert.AreEqual(1,mail.Classifications.Count);



            mail = factory.GetMail(mailUser, user2, new DateTime(), "test", "test", new SortedSet<Classification>() { ClassificationPool.GetInstance().GetClassification(ClassType.NATOSECRET), ClassificationPool.GetInstance().GetClassification(ClassType.EUSECRET) });
            
            Assert.AreEqual(2, mail.Classifications.Count);
        }
    }
}