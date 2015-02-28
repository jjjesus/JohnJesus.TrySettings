using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;


namespace JohnJesus.TrySettings
{
    public class AudioSettings
    {
        public static int GainDB { get; set; }
        public static string AudioDir { get; set; }
        static readonly string SETTINGS_FILE = "AudioSettings.ini";
        static readonly AudioSettings _instance = new AudioSettings();
        AudioSettings() {}
        static AudioSettings()
        {
            string propertyName = "";
            if (!File.Exists(SETTINGS_FILE))
            {
                AudioDir = "NOT SET";
                GainDB = (-1);
            }
            else
            {
                string[] settings = File.ReadAllLines(SETTINGS_FILE);
                foreach (string s in settings)
                {
                    try
                    {
                        string[] split = s.Split(new char[] { ':' }, 2);
                        if (split.Length != 2)
                            continue;
                        propertyName = split[0].Trim();
                        string propertyValue = split[1].Trim();
                        PropertyInfo propInfo = _instance.GetType().GetProperty(propertyName);
                        switch (propInfo.PropertyType.Name)
                        {
                            case "Int32":
                                propInfo.SetValue(null, Convert.ToInt32(propertyValue), null);
                                break;
                            case "String":
                                propInfo.SetValue(null, propertyValue, null);
                                break;
                        }
                    }
                    catch
                    {
                        throw new Exception("Invalid setting '" + propertyName + "'");
                    }
                }
            }
        }
    }
}
