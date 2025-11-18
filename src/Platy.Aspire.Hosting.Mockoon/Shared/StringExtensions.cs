using Platy.Aspire.Hosting.Mockoon.Environment;

namespace Platy.Aspire.Hosting.Mockoon.Shared;

/// <summary>
/// The string extensions
/// </summary>
public static class StringExtensions
{
  /// <summary>
  /// Get the final form
  /// </summary>
  /// <param name="containerName"></param>
  /// <param name="containerNamePrefix"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentException"></exception>
  public static string GetFinalForm(this string containerName, string containerNamePrefix)
  {
    if (string.IsNullOrWhiteSpace(containerName))
    {
      throw new ArgumentException("Container name cannot be null or whitespace.", nameof(containerName));
    }

    if (!string.IsNullOrEmpty(containerNamePrefix) && containerNamePrefix.Length > 0)
    {
      containerName = $"{containerNamePrefix}-{containerName}";
    }

    var namePrefixEnv = EnvironmentExtensions.GetNamePrefix();

    if (!string.IsNullOrEmpty(namePrefixEnv))
    {
      containerName = $"{namePrefixEnv}-{containerName}";
    }

    return containerName;
  }
}
