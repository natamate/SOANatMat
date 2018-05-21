using ObjectsManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.Services;
using Wing = ObjectsManager.Model.Wing;

namespace WebApplication1.Controllers
{
    public class WingController : ApiController
    {
        private readonly IWingRepository repo;
        private readonly ILogger _logger;

        public WingController(IWingRepository wingService, ILogger logger)
        {
            repo = wingService;
            _logger = logger;
        }

        // GET api/values
        public List<Wing> Get()
        {
            _logger.Write("GET All for Wing was called", LogLevel.Info);
            return repo.GetAllWings();
        }

        // GET api/values/5
        public Wing Get(int id)
        {
            _logger.Write("GET for Paintings was called", LogLevel.Info);
            return repo.Get(id);
        }

        // POST api/values
        public int Post([FromBody]Wing wing)
        {
            return repo.Add(wing);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Wing wing)
        {
            _logger.Write("PUT for Wing was called", LogLevel.Info);
            wing.Id = id;
            repo.Update(wing);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            repo.Delete(id);
        }
    }
}
