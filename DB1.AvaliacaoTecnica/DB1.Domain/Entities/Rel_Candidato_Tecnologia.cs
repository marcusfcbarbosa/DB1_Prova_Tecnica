using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.Domain.Entities
{
    [Table("tbRel_Candidato_Tecnologia")]
    public class Rel_Candidato_Tecnologia
    {
        [Key]
        public Int32 Rel_Candidato_Tecnologia_ID { get; set; }

        /// <summary>
        /// FK Tecnologia
        /// </summary>
        public Int32 Tecnologia_ID { get; set; }

        /// <summary>
        /// Propriedade de navegação
        /// </summary>
        public virtual Tecnologia Tecnologia { get; set; }



        /// <summary>
        /// FK Candidato
        /// </summary>
        public Int32 Candidato_ID { get; set; }

        /// <summary>
        /// Propriedade de navegação
        /// </summary>
        public virtual Candidato Candidato { get; set; }


    }
}
