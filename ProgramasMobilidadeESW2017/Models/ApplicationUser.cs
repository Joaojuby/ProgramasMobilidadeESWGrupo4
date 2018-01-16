using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProgramasMobilidadeESW2017.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        // Nome Utilizador
        public string PrimeiroNome { get; set; }

        public string UltimoNome { get; set; }

        // Data Nascimento Utilizador
        public DateTime DataNascimento { get; set; }

        // Nacionalidade Utilizador
        public string Nacionalidade { get; set; }

        // Dados necessarios para candidatura
        public string Genero { get; set; }

        // TO DO Fotografia
        // Escola
        // Ano Curricular
        // Curso
        // Numero Aluno
    }
}
