using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramasMobilidadeESW2017.Models
{

    public class Candidatura
    {
        public int ID { get; set; }
        public int ProgramaMobilidadeID { get; set; }

        [Required]
        [Display(Name= "Nome da Pessoa de Contacto")]
        public string NomePessoaContacto { get; set; }

        [Required]
        [Display(Name ="Telefone da Pessoa de Contacto")]
        public string TelefonePessoaContacto { get; set; }

        [Required]
        [Display(Name ="Relacao com o candidato")]
        public string RelacaoComCandidato { get; set; }

        public int EstadoCandidaturaID { get; set; }

        public EstadoCandidatura EstadoCandidatura { get; set; }

        public ICollection<Entrevista> Entrevistas { get; set; }
        public ICollection<Observacao> Observacoes { get; set; }
    }
}
