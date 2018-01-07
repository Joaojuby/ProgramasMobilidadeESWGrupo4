using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramasMobilidadeESW2017.Models
{
    public class ProgramaMobilidade
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int TipoProgramaMobilidadeID { get; set; }

        // Duracao em horas
        public int Duracao { get; set; }
        
        public DateTime DataInicioInscricao { get; set; }

        public DateTime DataLimiteInscricao { get; set; }
        
        public TipoProgramaMobilidade TipoProgramaMobilidade { get; set; }

        public ICollection<ProgramaMobilidadePais> ListaPaises { get; set; }
        
    }
}
