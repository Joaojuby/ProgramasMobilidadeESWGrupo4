using GenFu;
using ProgramasMobilidadeESW2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Testes
{
    public class PaisService : IPaisService
    {
        private List<Pais> Paises { get; set; }

        public PaisService()
        {
            var i = 0;
            Paises = A.ListOf<Pais>(50);
            Paises.ForEach(pais =>
            {
                i++;
                pais.ID = i;
            });
        }

        public IEnumerable<Pais> GetAll()
        {
            return Paises;
        }

        public Pais Get(int id)
        {
            return Paises.First(_ => _.ID == id);
        }

        public Pais Add(Pais pais)
        {
            var newid = Paises.OrderBy(_ => _.ID).Last().ID + 1;
            pais.ID = newid;

            Paises.Add(pais);

            return pais;
        }

        public void Update(int id, Pais pais)
        {
            var existing = Paises.First(_ => _.ID == id);
            existing.Nome = pais.Nome;
            existing.CodigoISO = pais.CodigoISO;
            existing.CodigoPais = pais.CodigoPais;
        }

        public void Delete(int id)
        {
            var existing = Paises.First(_ => _.ID == id);
            Paises.Remove(existing);
        }
    }

    public interface IPaisService
    {
        IEnumerable<Pais> GetAll();
        Pais Get(int id);
        Pais Add(Pais pais);
        void Update(int id, Pais pais);
        void Delete(int id);
    }
}
