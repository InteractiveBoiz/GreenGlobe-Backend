using ChatAPI.Graphql.InputTypes;
using ChatAPI.Graphql.Types;
using ChatAPI.Model;
using ChatAPI.RavenDB;
using GraphQL.Types;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAPI.Graphql
{
    public class ChatMutation : ObjectGraphType
    {
        public ChatMutation()
        {
            Field<ChatType>(
              "createChat",
              arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<ChatInputType>> { Name = "chat" }
              ),
              resolve: context =>
              {
                  var chatObj = context.GetArgument<Chat>("chat");
                  using (IDocumentSession session = RavenDocumentStore.Store.OpenSession())  // Open a session for a default 'Database'
                  {
                      session.Store(chatObj);
                      session.SaveChanges();

                      return chatObj;
                  }
              });
            Field<ChatType>(
              "updateChat",
              arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "The ID of the chat." },
                new QueryArgument<NonNullGraphType<ChatInputType>> { Name = "chat" }
              ),
              resolve: context =>
              {
                  var id = context.GetArgument<string>("id");

                  Chat chatObj = context.GetArgument<Chat>("chat");
                  using (IDocumentSession session = RavenDocumentStore.Store.OpenSession())  // Open a session for a default 'Database'
                  {
                      Chat doc = session.Load<Chat>(id);
  
                      doc.Association = chatObj.Association;
                      doc.Members = chatObj.Members;
                      doc.Messages = chatObj.Messages;

                      session.SaveChanges();
                      return doc;
                  }
              });
            Field<BooleanGraphType>(
              "deleteChat",
              arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "The ID of the chat." }
              ),
              resolve: context =>
              {
                  var id = context.GetArgument<string>("id");
                  using (IDocumentSession session = RavenDocumentStore.Store.OpenSession())  // Open a session for a default 'Database'
                  {
                      session.Delete(id);
                      session.SaveChanges();

                      return true;
                  }
              });
            Field<ChatType>(
              "sendMessage",
              arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "The ID of the chat." },
                new QueryArgument<NonNullGraphType<MessageInputType>> { Name = "message" }
              ),
              resolve: context =>
              {
                  var id = context.GetArgument<string>("id");

                  Message messageObj = context.GetArgument<Message>("message");
                  using (IDocumentSession session = RavenDocumentStore.Store.OpenSession())  // Open a session for a default 'Database'
                  {
                      Chat doc = session.Load<Chat>(id);

                      doc.Association = doc.Association;
                      if(doc.Messages == null)
                      {
                          doc.Messages = new List<Message>();
                      }
                      messageObj.Id = doc.Messages.Count.ToString();
                      doc.Messages.Add(messageObj);

                      session.SaveChanges();
                      return doc;
                  }
              });
        }
    }
}
