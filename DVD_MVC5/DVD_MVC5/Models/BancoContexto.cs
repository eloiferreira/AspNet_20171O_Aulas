using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DVD_MVC5.Models
{
    public class BancoContexto : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public BancoContexto() : base("name=BancoContexto")
        {
        }
        //Como o "System.Data.Entity." ja esta referenciado la em cima nao precisa dele e "DVD_MVC5" tbm
        //public System.Data.Entity.DbSet<DVD_MVC5.Models.Livros> Livros { get; set; }

        public DbSet<Livros> Livros { get; set; }
    }
}
