namespace Platy.Aspire.Hosting.Mockoon.Environment;

/// <summary>
/// The Environment Variables
/// </summary>
public static class EnvironmentalVariables
{
  /// <summary>
  /// The root name
  /// </summary>
  public const string Root = "PLATY_ASPIRE_";

  /// <summary>
  /// The Container Lifetime 
  /// </summary>
  public static class ContainerLifetime
  {
    /// <summary>
    /// The KeepRunning string
    /// </summary>
    public const string KeepRunning = Root + "CONTAINER_LIFETIME_KEEP_RUNNING";
  }

  /// <summary>
  /// The container persistence
  /// </summary>
  public static class ContainerPersistence
  {
    /// <summary>
    /// The Volatile root name
    /// </summary>
    public const string Volatile = Root + "CONTAINER_PERSISTENCE_VOLATILE";
  }

  /// <summary>
  /// Container Naming
  /// </summary>
  public static class ContainerNaming
  {
    /// <summary>
    /// The name prefix
    /// </summary>
    public const string NamePrefix = Root + "NAME_PREFIX";
  }
}
