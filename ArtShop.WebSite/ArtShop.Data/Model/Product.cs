using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Data.Model
{
    public class Product
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public int ArtistId { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int QuantitySold { get; set; }
        public double AvgStars { get; set; }
    
        //Metodo de solo lectura para mostrar el artista de un producto. Se realiza virtual por si se quiere sobreescribir en el comportamiento de artista al especializarlo. No lleva collection porque solo se pide uno por artista.
        public virtual Artist Artist { get; set; }
    }
}
