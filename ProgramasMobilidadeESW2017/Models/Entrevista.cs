using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramasMobilidadeESW2017.Models
{
    public class Entrevista
    {
        public int ID { get; set; }
        public int CandidaturaID { get; set; }

        public Candidatura Candidatura { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data da Entrevista")]
        public DateTime DataEntrevista { get; set; }
    }
}
