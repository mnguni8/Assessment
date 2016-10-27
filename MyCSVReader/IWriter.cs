using System.Collections.Generic;

namespace MyCSVReader
{
    public interface IWriter
    {
        void Write(List<string> value, string path);
    }
}