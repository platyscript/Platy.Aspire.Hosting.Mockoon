namespace Platy.Aspire.Hosting.Mockoon.Environment;

/// <summary>
/// The environment extensions
/// </summary>
public static class EnvironmentExtensions
{
  /// <summary>
  /// Keep the container running
  /// </summary>
  /// <param name="_">The application builder</param>
  /// <returns></returns>
  public static bool KeepContainersRunning(this IDistributedApplicationBuilder _)
  {
    var setting = System.Environment.GetEnvironmentVariable(EnvironmentalVariables.ContainerLifetime.KeepRunning);
    return !string.IsNullOrEmpty(setting) && Convert.ToBoolean(setting);
  }

  /// <summary>
  /// The Volatile setting
  /// </summary>
  /// <param name="_"></param>
  /// <returns></returns>
  public static bool Volatile(this IDistributedApplicationBuilder _)
  {
    var setting = System.Environment.GetEnvironmentVariable(EnvironmentalVariables.ContainerPersistence.Volatile);
    return !string.IsNullOrEmpty(setting) && Convert.ToBoolean(setting);
  }

  /// <summary>
  /// Get Name prefix
  /// </summary>
  /// <returns></returns>
  public static string? GetNamePrefix()
  {
    var containerName = System.Environment.GetEnvironmentVariable(EnvironmentalVariables.ContainerNaming.NamePrefix);
    if (!string.IsNullOrEmpty(containerName))
    {
      return containerName;
    }

    return null;
  }
}
