using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramasMobilidadeESW2017.Models
{
    public class Pais
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        // Codigo ISO 2 caracteres do Pais
        public string CodigoISO { get; set; }

        public int CodigoPais { get; set; }

        public ICollection<Instituicao> Instituicoes { get; set; }

        public ICollection<ProgramaMobilidadePais> ListaProgramas { get; set; }
    }
}
