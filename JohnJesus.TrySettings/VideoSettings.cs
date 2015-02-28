using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;


namespace JohnJesus.TrySettings
{
    public class VideoSettings
    {
        public static int FrameMax { get; set; }
        public static string VideoDir { get; set; }
        static readonly string SETTINGS_FILE = "VideoSettings.ini";
        static readonly VideoSettings _instance = new VideoSettings();
        VideoSettings() {}
        static VideoSettings()
        {
            string propertyName = "";
            if (!File.Exists(SETTINGS_FILE))
            {
                VideoDir = "NOT SET";
                FrameMax = (-1);
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
