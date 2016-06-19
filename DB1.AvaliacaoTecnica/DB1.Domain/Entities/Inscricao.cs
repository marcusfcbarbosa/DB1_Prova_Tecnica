using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DB1.Domain.Entities
{
    [Table("tbInscricao")]
    public class Inscricao
    {
        [Key]
        public Int32 Inscricao_ID { get; set; }
        
        /// <summary>
        /// FK Candidato
        /// </summary>
        public Int32 Candidato_ID { get; set; }

        /// <summary>
        /// Propriedade de navegação
        /// </summary>
        public virtual Candidato Candidato { get; set; }
        
        /// <summary>
        /// FK Tecnologia
        /// </summary>
        public Int32 Tecnologia_ID { get; set; }

        /// <summary>
        /// Propriedade de navegação
        /// </summary>
        public virtual Tecnologia Tecnologia { get; set; }


        /// <summary>
        /// FK Empresa
        /// </summary>
        public Int32 Empresa_ID { get; set; }

        /// <summary>
        /// Propriedade de navegação
        /// </summary>
        public virtual Empresa Empresa { get; set; }

        /// <summary>
        /// Data de registro 
        /// </summary>
        public DateTime? Data_Registro { get; set; }

        /// <summary>
        /// Status da Inscricao
        /// </summary>
        public Boolean? Status { get; set; }
    }
}