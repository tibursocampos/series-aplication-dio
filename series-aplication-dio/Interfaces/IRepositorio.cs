using System.Collections.Generic;

namespace series_aplication_dio
{
    public interface IRepositorio<T>
    {
        void Insert(T entity);
        List<T> GetAll();
        T GetById(int id);
        void Update(int id, T entity);
        void Delete(int id);
        int NextId();
    }
}
