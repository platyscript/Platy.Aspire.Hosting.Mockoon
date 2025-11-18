using Microsoft.Extensions.Logging.Abstractions;
using Platy.Aspire.Hosting.Mockoon;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddMockoonInstance("mockoon/Mock.json", 3001, containerName:"dc-mockoon");

builder.Build().Run();
