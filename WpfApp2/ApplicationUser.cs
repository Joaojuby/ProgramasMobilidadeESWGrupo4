using System;
using System.Collections.Generic;

namespace ProgramasMobilidadeESW2017.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Nacionalidade { get; set; }
        public string Genero { get; set; }
        public ICollection<Candidatura> Candidaturas { get; set; }
  }
}
