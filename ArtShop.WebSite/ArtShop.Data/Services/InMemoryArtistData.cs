using ArtShop.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Data.Services
{
    public class InMemoryArtistData : IArtistData
    {
        private List<Artist> Artists;

        public InMemoryArtistData()
        {
            Artists = new List<Artist>() {
                new Artist() { Id = 1, FirstName = "Nicolas", LastName = "Di Giacomo", TotalProducts = 10, CreatedOn = DateTime.Now, ChangedOn = DateTime.Now },
                new Artist() { Id = 3, FirstName = "Juan", LastName = "Perez", TotalProducts = 10, CreatedOn = DateTime.Now, ChangedOn = DateTime.Now },
                new Artist() { Id = 2, FirstName = "Fernando", LastName = "Suarez", TotalProducts = 10, CreatedOn = DateTime.Now, ChangedOn = DateTime.Now }
            };
        }

        public IEnumerable<Artist> GetAll()
        {
            return Artists;
        }
    }
}
