using GenFu;
using ProgramasMobilidadeESW2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Testes
{
    public class InstituicaoService : IInstituicaoService
    {
        private List<Instituicao> Instituicoes { get; set; }

        public InstituicaoService()
        {
            var i = 0;
            Instituicoes = A.ListOf<Instituicao>(50);
            Instituicoes.ForEach(instituicao =>
            {
                i++;
                instituicao.ID = i;
                instituicao.PaisID = i;
            });
        }

        public IEnumerable<Instituicao> GetAll()
        {
            return Instituicoes;
        }

        public Instituicao Get(int id)
        {
            return Instituicoes.First(_ => _.ID == id);
        }

        public Instituicao Add(Instituicao instituicao)
        {
            var newid = Instituicoes.OrderBy(_ => _.ID).Last().ID + 1;
            instituicao.ID = newid;

            Instituicoes.Add(instituicao);

            return instituicao;
        }

        public void Update(int id, Instituicao instituicao)
        {
            var existing = Instituicoes.First(_ => _.ID == id);
            existing.Nome = instituicao.Nome;
            existing.Morada = instituicao.Morada;
            existing.Email = instituicao.Email;
            existing.PhoneNumber = instituicao.PhoneNumber;
            existing.Website = instituicao.Website;
            existing.PaisID = instituicao.PaisID;
        }

        public void Delete(int id)
        {
            var existing = Instituicoes.First(_ => _.ID == id);
            Instituicoes.Remove(existing);
        }
    }

    public interface IInstituicaoService
    {
        IEnumerable<Instituicao> GetAll();
        Instituicao Get(int id);
        Instituicao Add(Instituicao instituicao);
        void Update(int id, Instituicao instituicao);
        void Delete(int id);
    }
}
