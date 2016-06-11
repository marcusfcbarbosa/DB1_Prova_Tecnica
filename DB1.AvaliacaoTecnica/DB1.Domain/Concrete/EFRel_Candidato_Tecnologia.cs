using DB1.Domain.Abstract;
using DB1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DB1.Domain.Concrete
{
    public class EFRel_Candidato_Tecnologia : IRel_Candidato_Tecnologia
    {
        DB1Context db1Context;

        #region "Construtor"
        public EFRel_Candidato_Tecnologia(DB1Context context)
        {
            db1Context = context;
        }
        #endregion
        #region "Implementações"
        public void Inserir(int Tecnologia_ID, int Candidato_ID)
        {
            if (db1Context.Rel_Candidato_Tecnologias.Where(x => x.Candidato_ID == Candidato_ID && x.Tecnologia_ID == Tecnologia_ID).FirstOrDefault() != null)
            {
                throw new InvalidOperationException("Já foi cadastrado essa tecnologia para esse candidato");
            }
            else {
                db1Context.Rel_Candidato_Tecnologias.Add(new Rel_Candidato_Tecnologia
                {
                    Candidato_ID = Candidato_ID,
                    Tecnologia_ID = Tecnologia_ID
                });
                db1Context.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
        #endregion"
    }
}
