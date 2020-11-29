using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace xmltest
{
    public class JsonParser<T> : AbstractParser<T> where T: class, new()
    {
        public override string Extension { get; } = ".json";
        protected override string GetRawPropertyByName(string propName)
        {
            var jsonElement = JsonDocument.Parse(ReadDocument()).RootElement;
            return jsonElement.GetProperty(propName).GetRawText().Trim('"');
        }
    }
}
