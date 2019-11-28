using GraphQL.Types;
using GraphQL.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EventAPI.Graphql
{
    public class EventSchema : Schema
    {
        public EventSchema(IServiceProvider provider)
        {
            Query = provider.GetRequiredService<EventQuery>();
            //Mutation = provider.GetRequiredService<StarWarsMutation>();
        }
    }
}
