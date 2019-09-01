using System;
using System.IO;
using System.Threading.Tasks;
using AwesomeSauce.Api.Models;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;

namespace AwesomeSauce.Api.Infrastructure
{
    public class AwesomeGraphQLMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IPersonRepository _personRepository;
        public AwesomeGraphQLMiddleware(RequestDelegate next, IPersonRepository
        personRepository)
        {
            _next = next;
            _personRepository = personRepository;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.StartsWithSegments("/graphql"))
            {
                using (var stream = new StreamReader(httpContext.Request.Body))
                {
                    var query = await stream.ReadToEndAsync();
                    if (!String.IsNullOrWhiteSpace(query))
                    {
                        var schema = new Schema
                        {
                            Query = new PersonQuery(_personRepository)
                        };

                        var result = await new DocumentExecuter()
                            .ExecuteAsync(options =>
                            {
                                options.Schema = schema;
                                options.Query = query;
                            });

                        await WriteResult(httpContext, result);
                    }
                }
            }
            else
            {
                await _next(httpContext);
            }
        }
        private async Task WriteResult(HttpContext httpContext, ExecutionResult result)
        {
            var json = new DocumentWriter(indent: true).Write(result);
            httpContext.Response.StatusCode = 200;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(json);
        }
    }

    public class PersonQuery : ObjectGraphType
    {
        public PersonQuery(IPersonRepository personRepository)
        {
            Field<PersonType>("person",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>() { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return personRepository.GetOne(id);
                });
            Field<ListGraphType<PersonType>>("people",
                resolve: context =>
                {
                    return personRepository.GetAll();
                });
        }
    }

    public class PersonType : ObjectGraphType<Person>
    {
        public PersonType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Email);
            Field<ListGraphType<PersonType>>("friends");
        }
    }
}