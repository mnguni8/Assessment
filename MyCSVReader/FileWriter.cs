using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSVReader
{
    public class FileWriter : IWriter
    {
        public void Write(List<string> value, string path)
        {

                File.WriteAllLines(path, value);          
        }
    }
}
