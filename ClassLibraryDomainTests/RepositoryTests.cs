using System;
using System.Data.SQLite;
using ClassLibraryDomain;
using Db4objects.Db4o;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassLibraryDomainTests
{
    [TestClass()]
    public class RepositoryTests
    {
        [TestMethod()]
        public void AddTest()
        {
            Repository<MailUser>.GetInstance().DeleteAll();
            for (int i = 0; i < 20; i++)
            {
                
          
            Repository<MailUser>.GetInstance().Add(new MailUser()
            
            {
                Id = 1+i,
                Classification = ClassificationPool.GetInstance().GetClassification(ClassType.BELGIUMEYESONLY),
                Address = "beoit",
                forName = "fsdfsdf",
                Name = "sfsdfs",
                RankNbr = "679",
                Unit = "JLKL"

            });
            }
            Assert.AreEqual(20, Repository<MailUser>.GetInstance().All().Count) ;
            
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Repository<MailUser>.GetInstance().DeleteAll();
          var ret=  Repository<MailUser>.GetInstance().Add(new MailUser()
            {
                Id = 1,
                Classification = ClassificationPool.GetInstance().GetClassification(ClassType.BELGIUMEYESONLY),
                Address = "beoit",
                forName = "fsdfsdf",
                Name = "sfsdfs",
                RankNbr = "679",
                Unit = "JLKL"

            });
            Repository<MailUser>.GetInstance().Delete(ret);
            Assert.AreEqual(1, Repository<MailUser>.GetInstance().All().Count)
            ;
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Repository<MailUser>.GetInstance().DeleteAll();
          var ret=  Repository<MailUser>.GetInstance().Add(new MailUser()
            {
                Id = 1,
                Classification = ClassificationPool.GetInstance().GetClassification(ClassType.BELGIUMEYESONLY),
                Address = "beoit",
                forName = "fsdfsdf",
                Name = "sfsdfs",
                RankNbr = "679",
                Unit = "JLKL"

            });
            Repository<MailUser>.GetInstance().Update(ret);
            Assert.AreEqual(1, Repository<MailUser>.GetInstance().All().Count)
            ;
        }


      
    }
}