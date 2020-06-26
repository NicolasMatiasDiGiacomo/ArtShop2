using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Data.Model
{
    public class OrderDetail:IdentityBase
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

    }
}
