using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramasMobilidadeESW2017.Models
{

    public class Candidatura
    {
        [Display(Name="Nº")]
        public int ID { get; set; }

        public int ProgramaMobilidadeID { get; set; }

        public int EstadoCandidaturaID { get; set; }

        [Required]
        [Display(Name= "Nome da Pessoa de Contacto")]
        public string NomePessoaContacto { get; set; }

        [Required]
        [Display(Name ="Telefone da Pessoa de Contacto")]
        public long TelefonePessoaContacto { get; set; }

        [Required]
        [Display(Name ="Relação com o candidato")]
        public string RelacaoComCandidato { get; set; }


        [Display(Name = "Estado")]
        public EstadoCandidatura EstadoCandidatura { get; set; }

        [Display(Name = "Programa de Mobilidade")]
        public ProgramaMobilidade ProgramaMobilidade { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<Entrevista> Entrevistas { get; set; }
        public ICollection<ObservacaoCandidatura> Observacoes { get; set; }

        [Display(Name = "Nome")]
        public string GetUserName()
        {
            return User.PrimeiroNome + " " + User.UltimoNome;
        }
    }
}
