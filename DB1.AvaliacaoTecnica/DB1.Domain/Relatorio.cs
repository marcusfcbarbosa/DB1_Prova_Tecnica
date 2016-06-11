using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.Domain
{
    public class Relatorio
    {
        public Relatorio()
        {
            this.Tecnologias = new List<string>();
        }
        public string NomeEmpresa { get; set; }

        public string NomeCandidato { get; set; }

        public List<String> Tecnologias { get; set; }

    }
}
