using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;
using MyCSVReader;
using System.Linq;
using System.Collections.Generic;
using Moq;

namespace CSVReaderTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Can_ReadStream()
        {
            var stream = CreateMockStream();

            var rdr = new CSVReader(stream);

            var result = rdr.ReadCSVFile();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Test_Can_Return_5_Objects()
        {
            var stream = CreateMockStream();

            var rdr = new CSVReader(stream);

            var result = rdr.ReadCSVFile();

            Assert.IsTrue(result.Count == 8);
        }

        [TestMethod]
        public void Test_Can_Count_Frequencies()
        {
            var stream = CreateMockStream();

            var rdr = new CSVReader(stream);

            CSVReaderProgram prog = new CSVReaderProgram(rdr, null);

            var result = rdr.ReadCSVFile();

            prog.CountFrequencies(result);

            Assert.IsTrue(result.FirstOrDefault(x => x.FirstName == "Graham").FirstNameFrequency == 2);
        }

        [TestMethod]
        public void Test_Writer_Can_Write_UniqueNames()
        {
            var stream = CreateMockStream();

            var rdr = new CSVReader(stream);

            

            var result = rdr.ReadCSVFile();

            var prog = new CSVReaderProgram(rdr, null);

            var names = prog.GetUniqueNames(result);

            var mockWriter = new Mock<IWriter>();
            mockWriter.Setup(r => r.Write(It.IsAny<List<string>>(), It.IsAny<string>()));

            var writer = new TextFileWriter(mockWriter.Object);
            bool success = writer.WriteUniqueNamesFile(names, "UniqueNames.txt");

            Assert.IsTrue(success);
        }

        [TestMethod]
        public void Test_Writer_Can_Write_Addresses()
        {
            var stream = CreateMockStream();

            var rdr = new CSVReader(stream);

            var result = rdr.ReadCSVFile();

            var prog = new CSVReaderProgram(rdr, null);

            var addresses = prog.GetAddressesSorted(result);

            var mockWriter = new Mock<IWriter>();
            mockWriter.Setup(r => r.Write(It.IsAny<List<string>>(), It.IsAny<string>()));

            var writer = new TextFileWriter(mockWriter.Object);
            bool success = writer.WriteAddressesToFile(addresses, "UniqueNames.txt");

            Assert.IsTrue(success);
        }

        [TestMethod]
        public void Test_Addresses_Sorted()
        {
            var stream = CreateMockStream();

            var rdr = new CSVReader(stream);

            var result = rdr.ReadCSVFile();

            var prog = new CSVReaderProgram(rdr, null);

            var addresses = prog.GetAddressesSorted(result);

            Assert.IsTrue(addresses.FirstOrDefault() == "65 Ambling Way");
            Assert.IsTrue(addresses.LastOrDefault() == "49 Sutherland St");
        }

        [TestMethod]
        public void Test_Names_Unique()
        {
            var stream = CreateMockStream();

            var rdr = new CSVReader(stream);

            var result = rdr.ReadCSVFile();

            var prog = new CSVReaderProgram(rdr, null);

            int nameCount = result.Count;

            var names = prog.GetUniqueNames(result);

            Assert.IsTrue(nameCount > names.Count);
        }

        private StreamReader CreateMockStream()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Jimmy,Smith,102 Long Lane,29384857");
            stringBuilder.AppendLine("Clive, Smith,65 Ambling Way,29384857");
            stringBuilder.AppendLine("James, Smith,82 Stewart St,29384857");
            stringBuilder.AppendLine("Graham, Smith,12 Howard St,29384857");
            stringBuilder.AppendLine("John, Smith,78 Short Lane,29384857");
            stringBuilder.AppendLine("Clive, Smith,49 Sutherland St,29384857");
            stringBuilder.AppendLine("James, Smith,8 Crimson Rd,29384857");
            stringBuilder.AppendLine("Graham, Smith,94 Roland St,29384857");

            var streamReader = new StreamReader(new MemoryStream(Encoding.ASCII.GetBytes(stringBuilder.ToString())));
            return streamReader;
        }
    }
}
