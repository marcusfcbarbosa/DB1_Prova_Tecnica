using DB1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DB1.Domain.Abstract
{
    public interface IRel_Candidato_Tecnologia
    {

        /// <summary>
        /// Inserir Rel_Candidato_Tecnologia
        /// </summary>
        /// <param name="empresa"></param>
        void Inserir(Int32 Tecnologia_ID, Int32 Candidato_ID);

        /// <summary>
        //excluir Rel_Candidato_Tecnologia
        /// </summary>
        /// <param name="id"></param>
        void Excluir(Int32 id);

       

    

    }
}
