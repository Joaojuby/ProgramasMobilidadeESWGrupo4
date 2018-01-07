using ProgramasMobilidadeESW2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramasMobilidadeESW2017.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Procura por Tipos de Programa Mobilidade
            if (context.TiposProgramaMobilidade.Any())
            {
                return; // BD já tem dados
            }

            var tiposPrograma = new TipoProgramaMobilidade[]
            {
                new TipoProgramaMobilidade{Designacao="Erasmus Estudantes", Descricao="Programa Erasmus para estudantes"},
                new TipoProgramaMobilidade{Designacao="Erasmus Docentes e Não Docentes", Descricao="Programa Erasmus para docentes e não docentes"},
                new TipoProgramaMobilidade{Designacao="Bolsa Luso-Brasileira Santander Universidades", Descricao="Programa Intercambio estudantes Santander Totta"},
                new TipoProgramaMobilidade{Designacao="Bolsa Ibero-Americana Santander Universidades", Descricao="Programa Intercambio estudantes Santander Totta"},
                new TipoProgramaMobilidade{Designacao="Cooperação Instituto Politecnico Macau", Descricao="" },
                new TipoProgramaMobilidade{Designacao="Vasco da Gama", Descricao=""}
            };
            foreach(TipoProgramaMobilidade tipoProgramaMobilidade in tiposPrograma)
            {
                context.TiposProgramaMobilidade.Add(tipoProgramaMobilidade);
            }
            context.SaveChanges();
        }
    }
}
