using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Data.Model
{
    public class Order:IdentityBase
    {
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public int OrderNumber { get; set; }
        public int ItemCount { get; set; }

    }
}
