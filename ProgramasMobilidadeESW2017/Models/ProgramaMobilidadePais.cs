using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramasMobilidadeESW2017.Models
{
    public class ProgramaMobilidadePais
    {
        public int ProgramaMobilidadeID { get; set; }
        public int PaisID { get; set; }

        public ProgramaMobilidade ProgramaMobilidade { get; set; }
        public Pais Pais { get; set; }
    }
}
