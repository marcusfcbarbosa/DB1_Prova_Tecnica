using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DB1.Domain.Entities
{

    [Table("tbRel_Empresa_Tecnologia")]
    public class Rel_Empresa_Tecnologia
    {
        [Key]
        public int Rel_Empresa_Tecnologia_ID { get; set; }

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

    }
}