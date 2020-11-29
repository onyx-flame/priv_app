using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace xmltest
{
    public abstract class AbstractParser<T> : IParser<T> where T: class, new()
    {
        public abstract string Extension { get; }
        protected abstract string GetRawPropertyByName(string propName);
        public T Parse()
        {
            
            var configureObject = new T();
            foreach (var property in configureObject.GetType().GetProperties())
            {
                var sourceProp = GetRawPropertyByName(property.Name);
                var prop = Convert.ChangeType(sourceProp, property.PropertyType);
                property.SetValue(configureObject, prop);
            }
            return configureObject;
        }
        protected string ReadDocument()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config" + Extension);
            using var sr = new StreamReader(path, System.Text.Encoding.Default);
            return sr.ReadToEnd();
        }
    }
}
