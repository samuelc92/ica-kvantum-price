var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var grafana = builder.AddContainer("grafana", "grafana/grafana")
    .WithBindMount("../grafana/config", "/etc/grafana")
    .WithBindMount("../grafana/dashboards", "/var/lib/grafana/dashboards")
    .WithEndpoint(targetPort: 3000, port: 3000, name: "grafana-http", scheme: "http");
    
var prometheus = builder.AddContainer("prometheus", "prom/prometheus")
    .WithBindMount("../prometheus", "/etc/prometheus")
    .WithEndpoint(targetPort: 9090, port: 9090);

var apiService = builder.AddProject<Projects.IcaKvantumPrice_ApiService>("apiservice")
    .WithEnvironment("GRAFANA_URL", grafana.GetEndpoint("grafana-http"));

builder.AddProject<Projects.IcaKvantumPrice_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService)
    .WithEnvironment("GRAFANA_URL", grafana.GetEndpoint("grafana-http"));

builder.Build().Run();
