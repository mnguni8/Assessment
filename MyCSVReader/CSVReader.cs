using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSVReader
{
    public class CSVReader : ICSVReader
    {
        private StreamReader _streamReader;

        public CSVReader(StreamReader streamReader)
        {
            _streamReader = streamReader;
        }

        public List<PersonData> ReadCSVFile()
        {            
            var personDataList = new List<PersonData>();

            while (!_streamReader.EndOfStream)
            {
                var line = _streamReader.ReadLine();
                var values = line.Split(',');

                if (values[0] != "FirstName")
                {
                    var person = new PersonData()
                    {
                        FirstName = values[0],
                        LastName = values[1],
                        Address = values[2],
                        PhoneNumber = values[3]
                    };

                    personDataList.Add(person);
                }
            }

            return personDataList;
        }
    }
}
