using System;
using System.Collections.Generic;
using System.Text;

namespace series_aplication_dio
{
    class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listSerie = new List<Serie>();

        public void Insert(Serie entity)
        {
            listSerie.Add(entity);
        }

        public List<Serie> GetAll()
        {
            return listSerie;
        }

        public Serie GetById(int id)
        {
            return listSerie[id];
        }

        public int ListSize()
        {
            return listSerie.Count;
        }

        public void Update(int id, Serie entity)
        {
            listSerie[id] = entity;
        }

        public void Delete(int id)
        {
            listSerie[id].Exclui();
        }

        public int NextId()
        {
            return listSerie.Count;
        }


    }
}
