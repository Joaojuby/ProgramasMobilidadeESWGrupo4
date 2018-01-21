using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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

            // Procura por Tipos de Programa Mobilidade
            if (!context.TiposProgramaMobilidade.Any())
            {
                var tiposPrograma = new TipoProgramaMobilidade[]
                {
                new TipoProgramaMobilidade{Designacao="Erasmus Estudantes", Descricao="Programa Erasmus para estudantes"},
                new TipoProgramaMobilidade{Designacao="Erasmus Docentes e Não Docentes", Descricao="Programa Erasmus para docentes e não docentes"},
                new TipoProgramaMobilidade{Designacao="Bolsa Luso-Brasileira Santander Universidades", Descricao="Programa Intercambio estudantes Santander Totta"},
                new TipoProgramaMobilidade{Designacao="Bolsa Ibero-Americana Santander Universidades", Descricao="Programa Intercambio estudantes Santander Totta"},
                new TipoProgramaMobilidade{Designacao="Cooperação Instituto Politecnico Macau", Descricao="" },
                new TipoProgramaMobilidade{Designacao="Vasco da Gama", Descricao=""}
                };
                foreach (TipoProgramaMobilidade tipoProgramaMobilidade in tiposPrograma)
                {
                    context.TiposProgramaMobilidade.Add(tipoProgramaMobilidade);
                }
                context.SaveChanges();
            }




            // Procura por Paises
            if (!context.Paises.Any())
            {
                var paises = new Pais[]
                {
                new Pais{Nome="Brasil", CodigoISO="BR", CodigoPais=55},
                new Pais{Nome="Alemanha", CodigoISO="DE", CodigoPais=49},
                new Pais{Nome="Itália", CodigoISO="IT", CodigoPais=39},
                new Pais{Nome="França", CodigoISO="FR", CodigoPais=33},
                new Pais{Nome="Noruega", CodigoISO="NO", CodigoPais=47},
                new Pais{Nome="Eslováquia", CodigoISO="SK", CodigoPais=421},
                new Pais{Nome="Hungria", CodigoISO="HU", CodigoPais=36},
                new Pais{Nome="Grécia", CodigoISO="GR", CodigoPais=30},
                new Pais{Nome="Chipre", CodigoISO="CY", CodigoPais=357},
                new Pais{Nome="Turquia", CodigoISO="TR", CodigoPais=90},
                new Pais{Nome="Bélgica", CodigoISO="BE", CodigoPais=32},
                new Pais{Nome="Espanha", CodigoISO="ES", CodigoPais=34},
                };
                foreach (Pais p in paises)
                {
                    context.Paises.Add(p);
                }
                context.SaveChanges();
            }




            // Procura por Instituicoes
            if (!context.Instituicoes.Any())
            {
                var paises = context.Paises;
                var instituicoes = new Instituicao[]
{
                new Instituicao{Nome="Berlim Polytecnic", Morada="Rua Direita de Berlim, Berlim, Alemanha", Website="www.polyberlim.de", Email="berlimpoly@ipberlim.de", PhoneNumber=289657238, PaisID=paises.Single(p => p.CodigoISO == "DE").ID},
                new Instituicao{Nome="Roma University", Morada="Paque de Roma nº4, Roma, Italia", Website="www.uniroma.it", Email="uniRoma@uniRoma.it", PhoneNumber=555686895, PaisID=paises.Single(p => p.CodigoISO == "IT").ID},
                new Instituicao{Nome="Paris University", Morada="Campos Eliseu nº20, Paris, França", Website="www.uniparis.fr", Email="uniParis@uniParis.fr", PhoneNumber=825653650, PaisID=paises.Single(p => p.CodigoISO == "FR").ID},
                new Instituicao{Nome="International Oslo University", Morada="Rua do Bacalhau nº90, Oslo, Norway", Website="www.intoslouni.no", Email="uniOslo@uniOslo.no", PhoneNumber=999686852, PaisID=paises.Single(p => p.CodigoISO == "NO").ID},
                new Instituicao{Nome="Bratislava Polytecnic", Morada="Avenida bartask lote 5 , Bratislava, Eslováquia", Website="www.poliBartislava.sk", Email="poliBartislava@poliBartislava.sk", PhoneNumber=888555740, PaisID=paises.Single(p => p.CodigoISO == "SK").ID},
                new Instituicao{Nome="Budapeste University", Morada="Parque Mostard nº74 , Budapeste, Hungria", Website="www.uniBudapeste.hu", Email="uniBudapeste@uniBudapeste.hu", PhoneNumber=124586795, PaisID=paises.Single(p => p.CodigoISO == "HU").ID},
                new Instituicao{Nome="Atenas University", Morada="Rua Deus de Ará nº23 , Atenas, Grécia", Website="www.uniAtenas.gr", Email="uniAtenas@uniAtenas.gr", PhoneNumber=765894320, PaisID=paises.Single(p => p.CodigoISO == "GR").ID},
                new Instituicao{Nome="Nicosia Polytecnic", Morada="Rua dos Principes nº10 , Nicosia, Chipre", Website="www.polyNicosia.cy", Email="turnin@polyNicosia.cy", PhoneNumber=784569581, PaisID=paises.Single(p => p.CodigoISO == "CY").ID},
                new Instituicao{Nome="Ancara University", Morada="Avenida Jõao da Silva nº30 , Ancara, Turquia", Website="www.uniAncara.tr", Email="uniAncara@uniAncara.tr", PhoneNumber=111236500, PaisID=paises.Single(p => p.CodigoISO == "TR").ID},
                new Instituicao{Nome="Bruxels Polytecnic", Morada="Campos de Bruxelas nº13 , Bruxelas, Bélgica", Website="www.polyBruxels.be", Email="bruxels@polyBruxels.be", PhoneNumber=753266900, PaisID=paises.Single(p => p.CodigoISO == "BE").ID},
                new Instituicao{Nome="Madrid University", Morada="Rua D.Juan V nº10 , Madrid, Espanha", Website="www.unimadrid.es", Email="unimadrid@uniMadrid.es", PhoneNumber=200500700, PaisID=paises.Single(p => p.CodigoISO == "ES").ID},
                new Instituicao{Nome="Copacabana University", Morada="Rua Ivete Sangalo nº3 , Copacabana, Brasil", Website="www.unicopacabana.br", Email="unicopacabana@unicopacabana.es", PhoneNumber=963258300, PaisID=paises.Single(p => p.CodigoISO == "BR").ID},
};
                foreach (Instituicao i in instituicoes)
                {
                    context.Instituicoes.Add(i);
                }
                context.SaveChanges();
            }



            // Procura por estados candidatura
            if (!context.EstadosCandidaturas.Any())
            {
                var estados = new EstadoCandidatura[]
                {
                    new EstadoCandidatura{Designacao="Em Análise"},
                    new EstadoCandidatura{Designacao="Cancelada"},
                    new EstadoCandidatura{Designacao="Aguardar Resultados"},
                    new EstadoCandidatura{Designacao="Aprovada"},
                    new EstadoCandidatura{Designacao="Não Aprovada"},
                };

                foreach(EstadoCandidatura e in estados)
                {
                    context.EstadosCandidaturas.Add(e);
                }
                context.SaveChanges();
            }

        }
    }
}
