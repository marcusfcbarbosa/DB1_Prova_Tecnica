using DB1.Domain.Abstract;
using DB1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.Domain.Concrete
{
    public class EFInscricao : IInscricao
    {

        DB1Context db1Context;
        #region "Construtor"
        public EFInscricao(DB1Context context)
        {
            db1Context = context;
        }
        #endregion 

        #region "Implementações"
        public void Inserir(int Candidato_ID, int Empresa_ID, Int32 Tecnologia_ID)
        {
            if (db1Context.Inscricoes.Where(x => x.Candidato_ID == Candidato_ID && x.Empresa_ID == Empresa_ID).FirstOrDefault() != null) {
                throw new InvalidOperationException("Já foi feita a inscricao desse candidato");
            }
            var numeroVagas = (from emp in db1Context.Empresas
                               where emp.Empresa_ID == Empresa_ID
                               select emp.Vagas
                               ).FirstOrDefault();

            var inscricoesRealizadas = (from ins in db1Context.Inscricoes where ins.Tecnologia_ID == Tecnologia_ID && ins.Empresa_ID == Empresa_ID select ins).Count();
            if (inscricoesRealizadas >= numeroVagas)
            {
                throw new InvalidOperationException("Não existem mais vagas para essa inscrição");
            }
            else
            {
                db1Context.Inscricoes.Add(new Inscricao
                {
                    Candidato_ID = Candidato_ID,
                    Empresa_ID = Empresa_ID,
                    Tecnologia_ID = Tecnologia_ID,
                    Data_Registro = DateTime.Now,
                    Status = true
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
