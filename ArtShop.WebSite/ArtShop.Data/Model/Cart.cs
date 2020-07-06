using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Data.Model
{
    class Cart : IdentityBase
    {
        [Required]
        [MaxLength(40)]
        public string Cookie { get; set; }
        [Required]
        public DateTime CartDate { get; set; }
        [Required]
        public int ItemCount { get; set; }
    }
}
