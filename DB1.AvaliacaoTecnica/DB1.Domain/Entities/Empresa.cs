using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DB1.Domain.Entities
{
    [Table("tbEmpresa")]
    public class Empresa
    {
        [Key]
        public int Empresa_ID { get; set; }

        public string Nome { get; set; }

        public string Cnpj { get; set; }

        public String Email { get; set; }

        public String Telefone { get; set; }

        public Int32 Vagas { get; set; }
        
        public DateTime? Data_Registro { get; set; }

        public Boolean? Status { get; set; }
        /// <summary>
        /// Faz a comparação de qualquer objeto feito com o metodo Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var empresaParm = (Empresa)obj;
            if (this.Empresa_ID == empresaParm.Empresa_ID || this.Nome == empresaParm.Nome || this.Email == empresaParm.Email || this.Cnpj == empresaParm.Cnpj)
            {
                return true;
            }
            return false;
        }
    }
}