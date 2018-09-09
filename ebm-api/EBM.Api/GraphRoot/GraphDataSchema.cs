using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBM.Api.GraphRoot
{
    public class GraphDataSchema : Schema
    {
        public GraphDataSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<GraphDataQuery>();
        }
    }
}
