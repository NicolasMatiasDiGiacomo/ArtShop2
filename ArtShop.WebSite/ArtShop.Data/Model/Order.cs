using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Data.Model
{
    class Order : IdentityBase
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public float TotalPrice { get; set; }
        [Required]
        public int OrderNumber { get; set; }
        [Required]
        public int ItemCount { get; set; }
    }
}
