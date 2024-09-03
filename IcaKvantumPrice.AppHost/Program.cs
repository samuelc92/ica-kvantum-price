var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var postgres = builder.AddPostgres("PostgreSQL")
                      .WithPgWeb();
var icadb = postgres.AddDatabase("icadb");

var apiService = builder.AddProject<Projects.IcaKvantumPrice_ApiService>("apiservice")
                        .WithReference(icadb);

builder.AddProject<Projects.IcaKvantumPrice_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();
