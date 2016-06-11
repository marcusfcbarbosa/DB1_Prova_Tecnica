using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB1.Api
{
    public class Retorno
    {

        public Retorno() {
            this.Tecnologias = new List<string>();
        }
        public string NomeEmpresa { get; set; }

        public string NomeCandidato { get; set; }

        public List<String> Tecnologias { get; set; }

    }
}