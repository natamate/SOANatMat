using System.Collections.Generic;
using System.Web.Http;
using ObjectsManager.Interfaces;
using ObjectsManager.Model;

namespace WebApplicationLab6.Controllers
{
    public class ArtistsController : ApiController
    {

        private readonly IArtistRepository repo;

        public ArtistsController(IArtistRepository artistService)
        {
            repo = artistService;
        }

        // GET api/values
        public IEnumerable<Artist> Get()
        {
            return repo.GetAll();
        }

        // GET api/values/5
        public Artist Get(int id)
        {
            return repo.Get(id);
        }

        // POST api/values
        public int Post([FromBody]Artist artist)
        {
            return repo.Add(artist);
        }

        // PUT api/values/5
        public void Put([FromUri]int id, [FromBody]Artist artist)
        {
            artist.Id = id;
            repo.Update(artist);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            repo.Delete(id);
        }
    }
}
