using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC1.Models
{
    public class MVC1Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MVC1Context() : base("name=MVC1Context")
        {
            //quando houver uma auteracao na base de dados vai apagar e criar de novo
         
            DropCreateDatabaseIfModelChanges<MVC1Context> initializer = new
            DropCreateDatabaseIfModelChanges<MVC1Context>();
            Database.SetInitializer<MVC1Context>(initializer);

        }

        public DbSet<Produto> Produtoes { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<UploadFileResult> UploadFileResults { get; set; }
    }
}
