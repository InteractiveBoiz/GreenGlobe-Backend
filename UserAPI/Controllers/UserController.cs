using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Raven.Client.Documents.Session;
using UserAPI.Database;
using UserAPI.Models;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            using (IDocumentSession session = RavenDocumentStore.Store.OpenSession())  // Open a session for a default 'Database'
            {
                //EnsureDatabaseExists.DatabaseExists(RavenDocumentStore.Store, "Users");
                List<User> users = session
                    .Query<User>()
                    .ToList();
                return users.ToArray();
            }
        }
    }
}
