using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PAP_Condominio.Models
{
    public class PAP_CondominioContext : DbContext
    {




        public PAP_CondominioContext() : base("name=PAP_CondominioContext")
        {

            //quando houver uma auteracao na base de dados vai apagar e criar de novo

            DropCreateDatabaseIfModelChanges<PAP_CondominioContext> initializer = new
                DropCreateDatabaseIfModelChanges<PAP_CondominioContext>();
            Database.SetInitializer<PAP_CondominioContext>(initializer);

        }



        public DbSet<Condominio> Condominios { get; set; }

        public DbSet<Morador> Moradors { get; set; }

        public System.Data.Entity.DbSet<PAP_Condominio.Models.Sindico> Sindicoes { get; set; }

        public System.Data.Entity.DbSet<PAP_Condominio.Models.MuralDigital> Solicitacaos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            //se excluir a categoria ele nao exclui os dados dentro dela
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }



}
