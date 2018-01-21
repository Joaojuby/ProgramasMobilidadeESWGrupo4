using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramasMobilidadeESW2017.Models
{
    public class ObservacaoCandidatura
    {
        public int ID { get; set; }
        public string Nota { get; set; }

        public int CandidaturaID { get; set; }
        public Candidatura Candidatura { get; set; }
    }
}
