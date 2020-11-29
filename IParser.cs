using System;
using System.Collections.Generic;
using System.Text;

namespace xmltest
{
    public interface IParser<T> where T : class, new()
    {
        public string Extension { get; }
        public T Parse();
    }
}
