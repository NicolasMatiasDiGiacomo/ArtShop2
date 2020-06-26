using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Data.Model
{
    public class Rating:IdentityBase
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Stars { get; set; }
    }
}
