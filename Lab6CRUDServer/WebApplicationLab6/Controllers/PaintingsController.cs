using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ObjectsManager.Interfaces;
using ObjectsManager.Model;
using WebApplicationLab6.DAL;
using WebApplicationLab6.Services;

namespace WebApplicationLab6.Controllers
{
    public class PaintingsController : ApiController
    {
        private readonly IPaintingsRepository repo;
        private readonly ILogger _logger;

        public PaintingsController(IPaintingsRepository paintingService, ILogger logger)
        {
            repo = paintingService;
            _logger = logger;
        }

        // GET api/values
        public IEnumerable<Painting> Get()
        {
            _logger.Write("GET All for Paintings was called",  LogLevel.Info);
            return repo.GetAll();
        }

        // GET api/values/5
        public Painting Get(int id)
        {
            _logger.Write("GET for Paintings was called", LogLevel.Info);
            return repo.Get(id);
        }

        // POST api/values
        public int Post([FromBody]Painting painting)
        {
            return repo.Add(painting);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Painting painting)
        {
            _logger.Write("PUT for Paintings was called", LogLevel.Info);
            painting.Id = id;
            repo.Update(painting);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            repo.Delete(id);
        }

    }
}
