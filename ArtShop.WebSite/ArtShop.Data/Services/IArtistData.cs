using ArtShop.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Data.Services
{
    public interface IArtistData
    {
        IEnumerable<Artist> GetAll();
    }
}
