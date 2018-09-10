using System;
using System.Threading.Tasks;
using EBM.Api.GraphRoot;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;

namespace EBM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EbmController : ControllerBase
    {
        private readonly ISchema schema;
        private readonly IDocumentExecuter documentExecutor;

        public EbmController(ISchema schema, IDocumentExecuter documentExecutor)
        {
            this.schema = schema;
            this.documentExecutor = documentExecutor;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            var inputs = query.Variables.ToInputs();
            var executeOptions = new ExecutionOptions
            {
                Schema = schema,
                Query = query.Query,
                Inputs = inputs
            };

            var result = await documentExecutor.ExecuteAsync(executeOptions).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}