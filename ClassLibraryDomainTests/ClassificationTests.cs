using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain.Tests
{
    [TestClass()]
    public class ClassificationTests
    {
        [TestMethod()]
        public void CompareToTest()
        {
            Classification classification = ClassificationPool.GetInstance()
                .GetClassification(ClassType.NATOSECRET);
            Classification classification2= ClassificationPool.GetInstance()
                .GetClassification(ClassType.EUSECRET);

            Assert.AreNotEqual(classification,classification2);


            SortedClassifications sortedClassifications=new SortedClassifications();
            sortedClassifications.Add(classification);
            sortedClassifications.Add(classification2);

            Assert.AreEqual(2, sortedClassifications.Count);
        }
    }
}