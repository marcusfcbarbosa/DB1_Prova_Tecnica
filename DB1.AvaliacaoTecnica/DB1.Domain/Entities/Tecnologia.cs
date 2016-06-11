using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.Domain.Entities
{
    [Table("tbTecnologia")]
    public class Tecnologia
    {

        [Key]
        public int Tecnologia_ID { get; set; }

        public string Descricao { get; set; }
        
        
        public DateTime? Data_Registro { get; set; }

        public Boolean Status { get; set; }

        /// <summary>
        /// Faz a comparação de qualquer objeto feito com o metodo Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var tecnologiaParm = (Tecnologia)obj;
            if (this.Tecnologia_ID == tecnologiaParm.Tecnologia_ID || this.Descricao == tecnologiaParm.Descricao )
            {
                return true;
            }
            return false;
        }
    }
}
