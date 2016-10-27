using System.Collections.Generic;

namespace MyCSVReader
{
    public interface ITextFileWriter
    {
        bool WriteUniqueNamesFile(IEnumerable<PersonData> personDataList, string fileName);

        bool WriteAddressesToFile(IEnumerable<string> addressDataList, string fileName);
    }
}