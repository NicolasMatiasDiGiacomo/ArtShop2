using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Data.Model
{
    public class Cart : IdentityBase
    {
        public Cart()
        {
            this.CartItem = new HashSet<CartItem>();
        }
        [Required]
        [MaxLength(40)]
        public string Cookie { get; set; }
        [Required]
        public DateTime CartDate { get; set; }
        [Required]
        public int ItemCount { get; set; }

        public virtual ICollection<CartItem> CartItem { get; set; }
    }
}
