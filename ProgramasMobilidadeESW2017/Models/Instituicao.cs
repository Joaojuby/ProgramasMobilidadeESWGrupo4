using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramasMobilidadeESW2017.Models
{
    public class Instituicao
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Morada { get; set; }

        public string Email { get; set; }

        [Display(Name = "Nº Telefone")]
        public long PhoneNumber { get; set; }

        public string Website { get; set; }

        public int PaisID { get; set; }

        public Pais Pais { get; set; }
    }
}
