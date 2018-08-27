using System.Configuration;

namespace TimeSheetBuilder
{
    public class ConfigSettings
    {
        private static ClientSettingsSection _settingsSection;
        private static Configuration _config;

        public static ClientSettingsSection SettingsSection
        {
            get
            {
                if (_config == null)
                {
                    loadConfig();
                }
                if(_settingsSection == null)
                {
                    loadSettingsSection();
                }

                return _settingsSection;
            }
        }

        public static SettingElementCollection Settings
        {
            get
            {
                if (_config == null)
                {
                    loadConfig();
                }
                if (_settingsSection == null)
                {
                    loadSettingsSection();
                }
                
                return _settingsSection.Settings;
            }
        }

        private static void loadConfig()
        {
            _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
        }

        private static void loadSettingsSection()
        {
            if (_config == null)
                loadConfig();

            _settingsSection =
                    _config.GetSection("userSettings/TimeSheetBuilder.Properties.Settings") as ClientSettingsSection;
        }

        public static string GetValue(string name)
        {
            return Settings.Get(name).Value.ValueXml.InnerText;
        }

        public static void SetValue(string name, string value)
        {
            Settings.Get(name).Value.ValueXml.InnerText = value;
        }

        public static void Save()
        {
            if (_config == null)
                loadConfig();

            SettingsSection.SectionInformation.ForceSave = true;
            _config.Save(ConfigurationSaveMode.Full);
        }
    }
}
