using System;
using System.Collections.Generic;

namespace ClassLibraryDomain
{
    public interface IRepository<T>
    {
        T Add(T t);
        bool Delete(T t);

        T Update(T t);
        IList<T> All();


        void Initdb();
        

    }
}