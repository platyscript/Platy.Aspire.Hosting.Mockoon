using Azure.Identity;
using Platy.Aspire.Hosting.Mockoon.Environment;
using Platy.Aspire.Hosting.Mockoon.Shared;

namespace Platy.Aspire.Hosting.Mockoon;

/// <summary>
/// Azurite Builder Extension
/// </summary>
public static class MockoonBuilderExtensions
{
  /// <summary>
  ///   Adds the azurite instance.
  /// </summary>
  /// <param name="mockJsonFilePath">
  /// The path in the project containing the filePath.
  /// This can be a full path or a path relative to the current project's .csproj file.
  /// </param>
  /// <param name="port">The http port.</param>
  /// <param name="builder">The DistributedApplicationBuilder</param>
  /// <param name="registry">The container registry domain path</param>
  /// <param name="tag">The image tag</param>
  /// <param name="containerName">The name of the container.</param>
  /// <param name="namePrefix">The name prefix.</param>
  /// <returns></returns>
  public static IResourceBuilder<MockoonResource> AddMockoonInstance(this IDistributedApplicationBuilder builder,
    string mockJsonFilePath,
    int port,
    string registry = "hub.docker.com",
    string tag = MockoonContainerImageTags.Tag,
    string containerName = "mockoon",
    string namePrefix = "")
  {
    ArgumentNullException.ThrowIfNull(builder);

    var finalContainerName = containerName.GetFinalForm(namePrefix);
    var instance = new MockoonResource(containerName);
    
    // builder.AddContainer("dc-mockoon", "mockoon/cli:latest")
    //   .WithBindMount("mockoon/DCMock.json", "/data", true)
    //   .WithArgs("--data", "data")
    //   .WithArgs("--port", "3000")
    //   .WithHttpEndpoint(3001, 3000, isProxied: false);
    var resourceInstance = builder.AddResource(instance)
      .WithImage(MockoonContainerImageTags.Image, tag)
      .WithDataBindMount(mockJsonFilePath, true)
      .WithArgs("--data", "data")
      .WithArgs("--port", "3000")
      .WithHttpEndpoint(port, 3000, isProxied: false)
      .WithContainerName(finalContainerName);

    if (builder.KeepContainersRunning())
    {
      resourceInstance.WithLifetime(ContainerLifetime.Persistent);
    }

    return resourceInstance;
  }


  /// <summary>
  /// Add a data volume
  /// </summary>
  /// <param name="builder">The Resource Builder</param>
  /// <param name="name">The name of the data volume</param>
  /// <param name="isReadOnly">IsReadOnly</param>
  /// <returns></returns>
  public static IResourceBuilder<MockoonResource> WithDataVolume(this IResourceBuilder<MockoonResource> builder,
    string name, bool isReadOnly = false)
  {
    ArgumentNullException.ThrowIfNull(builder);

    return builder.WithVolume(name, "/data", isReadOnly);
  }

  /// <summary>
  /// With DataBindMount
  /// </summary>
  /// <param name="builder">The builder</param>
  /// <param name="source">The source directory</param>
  /// <param name="isReadOnly">Is ReadOnly</param>
  /// <returns></returns>
  public static IResourceBuilder<MockoonResource> WithDataBindMount(this IResourceBuilder<MockoonResource> builder,
    string source, bool isReadOnly = false)
  {
    ArgumentNullException.ThrowIfNull(builder);
    ArgumentNullException.ThrowIfNull(source);

    return builder.WithBindMount(source, "/data", isReadOnly);
  }
}
