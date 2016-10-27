using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSVReader
{
     public class TextFileWriter : ITextFileWriter
    {
        private IWriter _textWriter;

        public TextFileWriter(IWriter textWriter)
        {
            _textWriter = textWriter;
        }

        public bool WriteUniqueNamesFile(IEnumerable<PersonData> personDataList, string fileName)
        {
            bool success = false;

            try
            {
                var linesToAppend = new List<string>();

                foreach (var data in personDataList)
                {
                    linesToAppend.Add(data.FirstName + ", " + data.FirstNameFrequency);
                }

                _textWriter.Write(linesToAppend, fileName);

                success = true;
            }
            catch(Exception ex)
            {
                success = false;
            }

            return success;
        }

        public bool WriteAddressesToFile(IEnumerable<string> addressDataList, string fileName)
        {
            bool success = false;

            try
            {
                var linesToAppend = new List<string>();


                foreach (var address in addressDataList)
                {
                    linesToAppend.Add(address);
                }

                _textWriter.Write(linesToAppend, fileName);

                success = true;
            }
            catch(Exception ex)
            {
                success = false;
            }

            return success;
        }

    }
}
