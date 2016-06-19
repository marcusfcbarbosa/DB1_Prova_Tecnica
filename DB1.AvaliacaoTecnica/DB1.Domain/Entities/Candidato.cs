using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.Domain.Entities
{
    [Table("tbCandidato")]
    public class Candidato
    {
        [Key]
        public int Candidato_ID { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public Int32 Idade { get; set; }

        public String Email { get; set; }

        public String Telefone { get; set; }
        
        public DateTime? Data_Registro { get; set; }

        public Boolean? Status { get; set; }

        /// <summary>
        /// Faz a comparação de qualquer objeto feito com o metodo Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var candidatoParm = (Candidato)obj;
            if (this.Candidato_ID == candidatoParm.Candidato_ID || this.Nome == candidatoParm.Nome || this.Email == candidatoParm.Email || this.Cpf == candidatoParm.Cpf)
            {
                return true;
            }
            return false;
        }
    }
}