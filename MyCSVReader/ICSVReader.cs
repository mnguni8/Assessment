using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSVReader
{
    public interface ICSVReader
    {
        List<PersonData> ReadCSVFile();
    }
}
