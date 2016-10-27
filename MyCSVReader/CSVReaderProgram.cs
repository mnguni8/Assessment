using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace MyCSVReader
{
    public class CSVReaderProgram : ICSVReaderProgram
    {
        private ICSVReader _csvReader;
        private ITextFileWriter _writer;

        public CSVReaderProgram(ICSVReader csvReader, ITextFileWriter writer)
        {
            _csvReader = csvReader;
            _writer = writer;
        }

        public bool Execute()
        {
            var personDataList = _csvReader.ReadCSVFile();

            CountFrequencies(personDataList);

            bool namesSuccess = _writer.WriteUniqueNamesFile(GetUniqueNames(personDataList), "UniqueNames.txt");
            bool addressesSuccess = _writer.WriteAddressesToFile(GetAddressesSorted(personDataList), "AddressList.txt");

            return true;
        }

        public List<PersonData> GetUniqueNames(List<PersonData> personDataList)
        {
            return personDataList.DistinctBy(x => x.FirstName)
                .OrderByDescending(x => x.FirstNameFrequency).ThenBy(x => x.FirstName).ToList();
        }

        public List<string> GetAddressesSorted(List<PersonData> personDataList)
        {
            return personDataList.OrderBy(x => x.AddressName).Select(x => x.Address).ToList();
        }

        public void CountFrequencies(List<PersonData> personDataList)
        {
            var countByFirstName = personDataList.GroupBy(x => x.FirstName)
                       .ToDictionary(g => g.Key, g => g.Count());

            foreach (var person in personDataList)
            {
                person.FirstNameFrequency = countByFirstName[person.FirstName];
            }
        }
    }
}
