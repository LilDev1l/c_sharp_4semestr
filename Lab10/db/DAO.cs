using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10.db
{
    interface IDAO<T>
    {
        int Add(T obj);
        List<T> FindAll();
        T FindById(long id);
        bool Update(long id, T newValue);
        void RemoveAll();
        void RemoveById(long id);
    }
}
