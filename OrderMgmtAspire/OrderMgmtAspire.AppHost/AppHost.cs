var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.OrderMgmtAspire_ApiService>("orders-api")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.OrderMgmtAspire_Web>("web-ui")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
