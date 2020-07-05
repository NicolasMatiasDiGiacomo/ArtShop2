using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ArtShop.Data.Model
{
    public class Artist : IdentityBase
    {

        public Artist()
        {
            this.Products = new HashSet<Product>();
        }
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(30, ErrorMessage = "El nombre no puede ser mayor a 30 caracteres")]
        [DisplayName("Nombre")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Apellido")]
        public string LastName { get; set; }
        [MaxLength(30)]
        [DisplayName("Esperanza de vida")]
        public string LifeSpan { get; set; }
        [MaxLength(30)]
        [DisplayName("País")]
        public string Country { get; set; }
        [MaxLength(2000)]
        [DisplayName("Descripción")]
        public string Description { get; set; }
        [Required]
        [DisplayName("Total de productos")]
        public int TotalProducts { get; set; }

        [NotMapped]
        [DisplayName("Nombre completo")]
        public string FullName { get { return FirstName + " " + LastName; } }

        // Metodo de solo lectura para mostrar productos que tiene cada artista. Collection porque son varios por artista.
        public virtual ICollection<Product> Products { get; set; }
    }
}
