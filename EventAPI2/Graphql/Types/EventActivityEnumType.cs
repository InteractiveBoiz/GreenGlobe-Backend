using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI2.Graphql.Types
{
    public class EventActivityEnumType : EnumerationGraphType
    {
        public EventActivityEnumType()
        {
            Name = "EventActivity";
            Description = "The Activity to perform during the event.";
            AddValue("Cleanup_Small_Items", "Cleanup Small Items.", 0);
            AddValue("Cleanup_Large_Items", "Cleanup Large Items.", 1);
            AddValue("Ocean_Lake_River_Cleanup", "Ocean Lake River Cleanup.", 2);
            AddValue("Tree_Planting", "Tree Planting.", 3);
            AddValue("Flower_Planting", "Flower Planting.", 4);
            AddValue("Environmental_Landscaping", "Environmental Landscaping.", 5);
            AddValue("Help_Animals", "Help Animals.", 6);
            AddValue("Seminar", "Seminar.", 7);
        }
    }
}

/*
 * Cleanup_Small_Items = 0,
        Cleanup_Large_Items = 1,
        Ocean_Lake_River_Cleanup = 2,
        Tree_Planting = 3,
        Flower_Planting = 4,
        Environmental_Landscaping = 5,
        Help_Animals = 6,
        Seminar = 7,
 * 
 */
