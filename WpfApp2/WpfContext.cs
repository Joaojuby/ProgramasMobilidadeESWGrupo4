using Microsoft.EntityFrameworkCore;
using ProgramasMobilidadeESW2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class WpfContext : DbContext
    {
        public WpfContext() : base ("Server=tcp:programasmobilidadeesw1718dbserver.database.windows.net,1433;Initial Catalog = ProgramasMobilidadeESW1718_db; Persist Security Info=False;User ID = { your_username }; Password={your_password}; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30")
        {    
        }
        public DbSet<TipoProgramaMobilidade> TiposProgramaMobilidade { get; set; }
        public DbSet<ProgramaMobilidade> ProgramasMobilidade { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<ProgramaMobilidadePais> ProgramasMobilidadePais { get; set; }
        public DbSet<Candidatura> Candidaturas { get; set; }
        public DbSet<Entrevista> Entrevistas { get; set; }
        public DbSet<ObservacaoCandidatura> ObservacoesCandidaturas { get; set; }
        public DbSet<EstadoCandidatura> EstadosCandidaturas { get; set; }
    }
}
