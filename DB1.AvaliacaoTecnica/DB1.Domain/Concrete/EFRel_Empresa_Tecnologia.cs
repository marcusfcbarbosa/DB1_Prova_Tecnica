using DB1.Domain.Abstract;
using DB1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.Domain.Concrete
{
    public class EFRel_Empresa_Tecnologia : IRel_Empresa_Tecnologia
    {
        DB1Context db1Context;
        #region "Construtor"
        public EFRel_Empresa_Tecnologia(DB1Context context)
        {
            db1Context = context;
        }
        #endregion
        
        #region "Implementações"
        public void Inserir(int Tecnologia_ID, int Empresa_ID)
        {
            if (db1Context.Rel_Empresa_Tecnologias.Where(x => x.Tecnologia_ID == Tecnologia_ID && x.Empresa_ID == Empresa_ID).FirstOrDefault() != null)
            {
                throw new InvalidOperationException("Já foi cadastrado essa tecnologia para essa empresa");
            }
            else {

                db1Context.Rel_Empresa_Tecnologias.Add(new Rel_Empresa_Tecnologia
                {
                    Empresa_ID = Empresa_ID,
                    Tecnologia_ID = Tecnologia_ID
                });
                db1Context.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}