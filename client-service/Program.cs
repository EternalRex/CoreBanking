using ClientService.Application.Command.Create;
using ClientService.Application.Commands.Delete;
using ClientService.Application.Commands.Update;
using ClientService.Application.Query.List;
using ClientService.Application.Query.Lookups;
using ClientService.Application.Query.Search;
using ClientService.Domain.Repositories;
using ClientService.Infrastructure.Data;
using ClientService.Infrastructure.Middleware;
using ClientService.Infrastructure.Repositories;
using ClientService.Services;
using client_service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MappingMiddleware));
builder.Services.AddDbContext<DataContext>();

/*Register interfaces and their implementation*/
builder.Services.AddScoped<ICreateClientCmd, CreateClientCmd>();
builder.Services.AddScoped<IMasterFileRepository, MasterFileRepository>();
builder.Services.AddScoped<IDeleteClientCmd, DeleteClientCmd>();
builder.Services.AddScoped<IUpdateClientCmd, UpdateClientCmd>();
builder.Services.AddScoped<IQueryLookup, QueryLookup>();
builder.Services.AddScoped<IQuerySearch, QuerySearch>();
builder.Services.AddScoped<IQueryList, QueryList>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
//Let grpc receive maximum message size to prevent exhaustion
builder.Services.AddGrpc(options => options.MaxReceiveMessageSize = int.MaxValue);
builder.Services.AddGrpc();

/*To use grpc setvier reflection*/
builder.Services.AddGrpcReflection();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<ClientServices>();
app.MapGrpcService<MasterFileServices>();

/*To use grpc setvier reflection*/
app.MapGrpcReflectionService();

app.MapGet(
    "/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909"
);

app.Run();
