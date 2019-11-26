using System.Collections.Generic;
using System.Linq;
using EventAPI.Model;
using EventAPI.RavenDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Raven.Client.Documents.Session;

namespace EventAPI.Controllers
{
    [ApiController]
    [Route("api/Event")]
    public class EventController : ControllerBase
    {
        private readonly ILogger<EventController> _logger;

        public EventController(ILogger<EventController> logger)
        {
            _logger = logger;
        }

        // GET: api/Event
        public IEnumerable<Event> Get()
        {
            using (IDocumentSession session = RavenDocumentStore.Store.OpenSession())  // Open a session for a default 'Database'
            {
                //EnsureDatabaseExists.DatabaseExists(RavenDocumentStore.Store, "Scores");
                List<Event> events = session
                    .Query<Event>()
                    .ToList();
                return events;
            }
        }
    }
}
