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
        public int EstadoCandidaturaID { get; set; }
        public string NomePessoaContacto { get; set; }
        public long TelefonePessoaContacto { get; set; }
        public string RelacaoComCandidato { get; set; }
        public EstadoCandidatura EstadoCandidatura { get; set; }
        public ProgramaMobilidade ProgramaMobilidade { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<Entrevista> Entrevistas { get; set; }
        public ICollection<ObservacaoCandidatura> Observacoes { get; set; }
        public string GetUserName()
        {
            return User.PrimeiroNome + " " + User.UltimoNome;
        }
    }
}
