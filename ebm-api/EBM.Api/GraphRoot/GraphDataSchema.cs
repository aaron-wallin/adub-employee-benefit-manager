using GraphQL;
using GraphQL.Types;

namespace EBM.Api.GraphRoot
{
    public class GraphDataSchema : Schema
    {
        public GraphDataSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<GraphDataQuery>();
            Mutation = resolver.Resolve<GraphDataMutation>();
        }
    }
}
