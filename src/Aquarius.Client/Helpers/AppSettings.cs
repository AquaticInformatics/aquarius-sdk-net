using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using ServiceStack;

namespace Aquarius.Helpers
{
    public static class AppSettings
    {
        static AppSettings()
        {
            Settings = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

            Reload();
        }

        // It would be great to use the ServiceStack.Configuration classes http://docs.servicestack.net/appsettings
        // But that brings in a 2 MB ServiceStack.dll assembly. That feels too heavy to add to every SDK client.
        // So do something similar without bringing it all in.
        public static void Reload()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            var settingsPath = Path.Combine(Path.GetDirectoryName(UserAgentBuilder.GetExecutingAssemblyPath()),
                "AquariusSdkSettings.txt");

            var allSettings = new List<Dictionary<string, string>>
            {
                ReadEnvironmentSettings(),
                ReadTextSettings(settingsPath),
                ReadJsonSettings(Path.ChangeExtension(settingsPath, ".json")),
                ReadAppSettings(),
            };

            Settings.Clear();

            foreach (var dictionary in allSettings.Where(dict => dict != null))
            {
                foreach (var kvp in dictionary)
                {
                    if (Settings.ContainsKey(kvp.Key)) continue; // First setting wins

                    Settings.Add(kvp.Key, kvp.Value);
                }
            }
        }

        private static Dictionary<string, string> ReadTextSettings(string path)
        {
            return !File.Exists(path)
                ? null
                : File.ReadAllText(path).ParseKeyValueText("=");
        }

        private static Dictionary<string, string> ReadJsonSettings(string path)
        {
            return !File.Exists(path)
                ? null
                : File.ReadAllText(path).FromJson<Dictionary<string,string>>();
        }

        private static Dictionary<string, string> ReadEnvironmentSettings()
        {
            return Environment
                .GetEnvironmentVariables()
                .Cast<DictionaryEntry>()
                .ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString());
        }

        private static Dictionary<string, string> ReadAppSettings()
        {
#if NETFULL
            return ConfigurationManager
                .AppSettings
                .ToDictionary();
#else
            return null;
#endif
        }

        private static readonly Dictionary<string, string> Settings;

        public static T Get<T>(string name, T defaultValue)
        {
            var key = GetSettingKey(name);

            return Settings.TryGetValue(key, out var valueText)
                ? valueText.FromJson<T>()
                : defaultValue;
        }

        private const string SettingPrefix = "Aquarius.SDK.";

        public static string GetSettingKey(string name)
        {
            return $"{SettingPrefix}{name}";
        }
    }
}
