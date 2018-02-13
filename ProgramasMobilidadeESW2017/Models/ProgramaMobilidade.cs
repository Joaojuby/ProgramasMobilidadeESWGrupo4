using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramasMobilidadeESW2017.Models
{
    public class ProgramaMobilidade
    {
        public int ID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public int TipoProgramaMobilidadeID { get; set; }

        // Duracao em horas
        [Required]
        [Display(Name = "Duração em Horas")]
        public int Duracao { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Inicio de Inscrição")]
        public DateTime DataInicioInscricao { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Limite de Inscrição")]
        public DateTime DataLimiteInscricao { get; set; }
        
        [Display(Name = "Tipo de Programa de Mobilidade")]
        public TipoProgramaMobilidade TipoProgramaMobilidade { get; set; }

        public ICollection<ProgramaMobilidadePais> ListaPaises { get; set; }
        
    }
}
