using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Threading.Tasks;
using DB1.Domain.Entities;


namespace DB1.Domain.Concrete
{
    public class DB1Context : DbContext
    {
        public DB1Context()
            : base("name=conexao")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DB1Context>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<Candidato> Candidatos { get; set; }

        public DbSet<Tecnologia> Tecnologias { get; set; }

        public DbSet<Rel_Candidato_Tecnologia> Rel_Candidato_Tecnologias { get; set; }

        public DbSet<Rel_Empresa_Tecnologia> Rel_Empresa_Tecnologias { get; set; }

        public DbSet<Inscricao> Inscricoes { get; set; }
    }
}
