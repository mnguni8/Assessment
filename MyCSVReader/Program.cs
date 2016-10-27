using Microsoft.Practices.Unity;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSVReader
{
    class Program
    {
        static void Main(string[] args)
        {
            //Written by Linda Mnguni

            var unity = RegisterContainer();

            bool success = unity.Resolve<ICSVReaderProgram>().Execute();
        }

        static UnityContainer RegisterContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<ICSVReader, CSVReader>();
            container.RegisterType<ITextFileWriter, TextFileWriter>();
            container.RegisterType<ICSVReaderProgram, CSVReaderProgram>();
            container.RegisterInstance(new StreamReader(File.OpenRead(@"data.csv")));
            container.RegisterType<IWriter, FileWriter>();

            return container;
        }
    }
}
