using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ArtShop.Data.Model
{
    public class Product : IdentityBase
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        [Required]
        public int ArtistId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Image { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int QuantitySold { get; set; }
        [Required]
        public double AvgStars { get; set; }

        //Metodo de solo lectura para mostrar el artista de un producto. Se realiza virtual por si se quiere sobreescribir en el comportamiento de artista al especializarlo. No lleva collection porque solo se pide uno por artista.
        public virtual Artist Artist { get; set; }
    }
}
