using System.Globalization;
using System.Resources;

namespace RapidDeskToolkit.Common.LanguageManager;

public static class LanguageManager
{
    private static readonly List<ResourceManager> ResourceManagers = [];
    private static CultureInfo CurrentCulture = CultureInfo.CurrentCulture;
    public static event Action? LanguageChanged;

    public static void AddResourceManager(ResourceManager resourceManager)
    {
        ResourceManagers.Add(resourceManager);
    }

    public static void SetCurrentCulture(CultureInfo culture)
    {
        CurrentCulture = culture;
        CultureInfo.CurrentCulture = culture;
        LanguageChanged?.Invoke();
    }

    public static string GetString(string key)
    {
        foreach (var resourceManager in ResourceManagers)
        {
            var value = resourceManager.GetString(key, CurrentCulture);
            if (value != null)
                return value;
        }
        return key;
    }

    public static CultureInfo GetCurrentCulture()
    {
        return CurrentCulture;
    }
}
