using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;

namespace ClassLibraryDomain
{
    public class Repository<T> : IRepository<T>
    {

        private static readonly Repository<T> Instance = new Repository<T>();

        private Repository()
        {


        }


        public T Add(T t)
        {
            IObjectContainer db =
                Db4oFactory.OpenFile(Resource.db40);
           
            try
            {

                db.Store(t);


                db.Commit();
            }
            catch
            {
                db.Rollback();
            }
            finally
            {
                // Close the db cleanly
                db.Close();
            }
            return default(T);
        }

        public bool Delete(T t)
        {
          
            IObjectContainer db =
                Db4oFactory.OpenFile(Resource.db40);
            try
            {

                db.Delete(t);


                db.Commit();
            }
            catch
            {
                db.Rollback();
                return false;
            }
            finally
            {
                // Close the db cleanly
                db.Close();
            }
            return true;
        }

        public T Update(T t)
        {
            IObjectContainer db =
                Db4oFactory.OpenFile(Resource.db40);
            try
            {

                db.Store(t);


                db.Commit();
            }
            catch
            {
                db.Rollback();
            }
            finally
            {
                // Close the db cleanly
                db.Close();
            }
            return default(T);
        }

        public IList<T> All()
        {
            IList<T> ret = null;
            IObjectContainer db =
                Db4oFactory.OpenFile(Resource.db40);
            try
            {
                ret = db.Query<T>().ToList();

            }
            catch
            {
                db.Rollback();
            }
            finally
            {
                // Close the db cleanly
                db.Close();
            }
         return ret;
        }

        public void Initdb()
        {



        }

        public static Repository<T> GetInstance()
        {
            return Instance;
            ;
        }


        public void DeleteAll()
        {
           
            IObjectContainer db =
                Db4oFactory.OpenFile(Resource.db40);
            try
            {
                foreach (var var in db.Query<T>())
                {
                    db.Delete(var);
                }
                db.Commit();
            }
            catch
            {
                db.Rollback();
            }
            finally
            {
                // Close the db cleanly
                db.Close();
            }
           
        }

        public MailUser GetUser(string serialNbr)
        {
            IObjectContainer db =
               Db4oFactory.OpenFile(Resource.db40);
            MailUser ret;

            try
            {

                 ret = (from MailUser m in db
                    where m.RankNbr.Contains(serialNbr)
                    select m).Single();


                db.Commit();
            }
            catch
            {
                db.Rollback();
                return null;
            }
            finally
            {
                // Close the db cleanly
                db.Close();
            }
            return ret;
        }
    }
}
