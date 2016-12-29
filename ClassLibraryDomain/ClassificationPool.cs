using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain
{
    public class ClassificationPool
    {

        private static readonly  ClassificationPool Instance=new ClassificationPool();
        private readonly IDictionary<String,Classification> _dictionary=new ConcurrentDictionary<String,Classification>();

        public ClassificationPool()
        {
         //   Classification classification=new Classification(1,1,"sd",Organisation.EU);
            _dictionary.Add("BELGIUMEYESONLY", new Classification(1, "BELGIUMEYESONLY", Organisation.BE));
            _dictionary.Add("RESTRICTED", new Classification(2, "RESTRICTED", Organisation.BE));
            _dictionary.Add("CONFIDENTIAL", new Classification(3, "CONFIDENTIAL", Organisation.BE));
            _dictionary.Add("SECRET", new Classification(4, "SECRET", Organisation.BE));
            _dictionary.Add("TOPSECRET", new Classification(5, "TOPSECRET", Organisation.BE));
            _dictionary.Add("ATOML", new Classification(6, "ATOML", Organisation.BE));

            _dictionary.Add("COSMICTOPSECRET", new Classification(5, "COSMICTOPSECRET", Organisation.NATO));
            _dictionary.Add("NATOSECRET", new Classification(4, "NATOSECRET", Organisation.NATO));
            _dictionary.Add("NATOCONFIDENTIAL", new Classification(2, "NATOCONFIDENTIAL", Organisation.NATO));
            _dictionary.Add("NATORESTRICTED", new Classification(1, "NATORESTRICTED", Organisation.NATO));

            _dictionary.Add("EUTOPSECRET", new Classification(5, "EUTOPSECRET", Organisation.EU));
            _dictionary.Add("EUSECRET", new Classification(4, "EUSECRET", Organisation.EU));
            _dictionary.Add("EUCONFIDENTIAL", new Classification(3, "EUCONFIDENTIAL", Organisation.EU));
            _dictionary.Add("EURESTRICTED", new Classification(2, "EURESTRICTED", Organisation.EU));


        }

        public IList<Classification> GetClassifications()
        {
            return _dictionary.Values.ToList();
        }

        public Classification GetClassification(ClassType classType)
        {
            return _dictionary.ContainsKey(classType.ToString()) ? _dictionary[classType.ToString()] : null;
        }


        public static ClassificationPool GetInstance()
        {
            return Instance;
        }
    }
}
