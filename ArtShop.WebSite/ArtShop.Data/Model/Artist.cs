using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Data.Model
{
    public class Artist: IdentityBase
    {

        public Artist()
        {
            this.Products = new HashSet<Product>();
        }

        //Campos Artista - No se colocan los ID ni los que se autocompletan en la base.
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LifeSpan { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public int TotalProducts { get; set; }
       
        // Metodo de solo lectura para mostrar productos que tiene cada artista. Collection porque son varios por artista.
        public virtual ICollection<Product> Products { get; set; }
    }
}
