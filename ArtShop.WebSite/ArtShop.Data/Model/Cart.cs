using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Data.Model
{
    public class Cart:IdentityBase
    {

        public string Cookie{ get; set; }
        public DateTime CartDate { get; set; }
        public int ItemCount { get; set; }
       
    }
}
