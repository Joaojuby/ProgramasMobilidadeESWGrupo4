﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgramasMobilidadeESW2017.Models;

namespace ProgramasMobilidadeESW2017.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<ProgramaMobilidadePais>()
                .HasKey(c => new { c.PaisID, c.ProgramaMobilidadeID });
        }
    }
}
