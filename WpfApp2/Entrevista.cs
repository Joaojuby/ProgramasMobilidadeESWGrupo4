using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramasMobilidadeESW2017.Models
{
    public class Entrevista
    {
        public int ID { get; set; }
        public int CandidaturaID { get; set; }

        public Candidatura Candidatura { get; set; }

        public DateTime DataEntrevista { get; set; }
    }
}
