using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressProcessing.CSV;
namespace TrainlineExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var rdrWriter = new CSVReaderWriter();
            //   var allDataLines = rdrWriter.ReadCSVData(@"C:\Users\amarwa\Desktop\Backend Engineer (General - C#)\src\AddressProcessor.Tests\test_data\contacts.csv");
            //foreach (List<string> lines in allDataLines)
            //{
            //    int i = 0;
            //    lines.ForEach(data => Console.Write(string.Format("{0} ", data)));
            //    Console.ReadLine();
            //    Console.WriteLine();
            //}
            //Console.ReadLine();
            var writer = new CSVReaderWriter();
            var allData = rdrWriter.ReadCSVData1(@"C:\Users\amarwa\Desktop\Backend Engineer (General - C#)\src\AddressProcessor.Tests\test_data\contacts.csv");
            foreach (var line in allData)
            {
                var columns = rdrWriter.MapCSVData(line);
                writer.WriteCSVData(columns, @"C:\Users\amarwa\Desktop\Backend Engineer (General - C#)\src\AddressProcessor.Tests\test_data\contacts2.csv");
            }

            // writer.WriteCSVData(allData, @"C:\Users\amarwa\Desktop\Backend Engineer (General - C#)\src\AddressProcessor.Tests\test_data\contacts2.csv");
            // foreach (var line in allData)
        }
    }
}
