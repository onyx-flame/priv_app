using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace xmltest
{
    class ConfigManager
    {
        public T GetConfig<T>() where T : class, new()
        {
            IParser<T> _configParser;
            if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml")))
            {
                _configParser = new XmlParser<T>();
            }
            else if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json")))
            {
                _configParser = new JsonParser<T>();
            }
            else
            {
                throw new ArgumentNullException("No config was found");
            }
            return _configParser.Parse();
        }
        public ConfigManager()
        {
            //_configParser = new JsonParser<T>();
        }
    }
}
