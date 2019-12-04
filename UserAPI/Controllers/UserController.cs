using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserAPI.Graphql;

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

        /*
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
        */
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();

            var schema = new Schema()
            {
                Query = new UserQuery(),
                Mutation = new UserMutation()
            };

            var result = await new DocumentExecuter().ExecuteAsync(_ => 
                {
                    _.Schema = schema;
                    _.Query = query.Query;
                    _.OperationName = query.OperationName;
                    _.Inputs = inputs;
                    _.ExposeExceptions = true;
                }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
