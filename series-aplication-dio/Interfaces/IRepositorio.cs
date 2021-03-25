using System.Collections.Generic;

namespace series_aplication_dio
{
    interface IRepositorio<T>
    {
        List<T> List();
        T ReturnById(int id);
        void Insert(T entity);
        void Delete(int id);
        void Update(int id, T entity);
    }
}
