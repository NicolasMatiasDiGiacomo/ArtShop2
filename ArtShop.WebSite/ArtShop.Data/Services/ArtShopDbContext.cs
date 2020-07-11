using ArtShop.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Data.Services
{
    //Dbcontext es una clase de Entity Framework que generalmente representa una conexion de base de datos y un conjunto de tablas.
    public class ArtShopDbContext : DbContext
    {
        //Creo un constructor indicandole que no se trabajara con codefirst

        //Indico al constructor de base que se trabajara con el string connection por default.
        public ArtShopDbContext() : base("name=DefaultConnection")
        {
            //NO CODEFIRST
            Database.SetInitializer<ArtShopDbContext>(null);
        }
        //Sobrecargo el metodo OnModelCreating para remover la convencion que crea Entity a las entidades escritas en singular pasandolas a plural. En el momento que se crea el modelo se descarta esa funcionalidad.  
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        //Se realiza propiedad dbset para representar a una entidad. La llamamos Artista con propiedades de lectura y escritura.  
        public virtual DbSet<Artist> Artist { get; set; }

        public virtual DbSet<Cart> Cart { get; set; }

        public virtual DbSet<CartItem> CartItem { get; set; }

        //Lo mismo para Product y las demas entidades -  COMPLETAR LAS DEMAS ENTIDADES NECESARIAS.
        public virtual DbSet<Product> Product { get; set; }

        //Cuando se implemente elDataService de estas entidades se tendra el enlace a la tabla siempre y cuando coincidan los nombres.
        public virtual DbSet<Error> Error { get; set; }


    }
}
