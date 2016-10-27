using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSVReader
{
    public interface ICSVReaderProgram
    {
        bool Execute();

        List<PersonData> GetUniqueNames(List<PersonData> personDataList);

        List<string> GetAddressesSorted(List<PersonData> personDataList);

        void CountFrequencies(List<PersonData> personDataList);
    }
}
