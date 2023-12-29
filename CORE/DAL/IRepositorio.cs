using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL
{
    interface IRepositorio<T>
    {
        void New(T item);
        void Save(T item);
        void Delete(T item);
        List<T> GetAll();
    }
}
