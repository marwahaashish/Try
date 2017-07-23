using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using AddressProcessing.Address;

namespace AddressProcessing.CSV
{
    /*
        2) Refactor this class into clean, elegant, rock-solid & well performing code, without over-engineering.
           Assume this code is in production and backwards compatibility must be maintained.
    */

    public class CSVReaderWriter
    {
        public string Separator
        {
            get
            {
                return (ConfigurationManager.AppSettings["Separator"]).Replace("\\t", "\t");
            }
        }

        public List<List<string>> ReadCSVData(string path)
        {
            var allLines = File.ReadAllLines(path);
            return allLines.Select(line => line.Split(new string[] { Separator }, StringSplitOptions.RemoveEmptyEntries).ToList()).ToList();
        }

        public List<string> ReadCSVData1(string path)
        {
            var lines = new List<string>();

            
            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        //columns = line.Split(new string[] { Separator }, StringSplitOptions.None).ToList();
                        lines.Add(line);
                        line = reader.ReadLine();
                    }
                }
            }
            return lines;
        }
        
        public List<string> MapCSVData(string data)
        {
            return data.Split(new string[] { Separator }, StringSplitOptions.None).ToList();
            //Person address = new Person { Name = columns[0], Address = columns[1], Telephone = columns[3], Email = columns[4] };
            //return address;
        }

        //public Person MapCSVData(string data)
        //{
        //    var columns = data.Split(new string[] { Separator }, StringSplitOptions.None).ToList();
        //    Person address = new Person { Name = columns[0], Address = columns[1], Telephone = columns[3], Email = columns[4] };
        //    return address;
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="path"></param>
        /// <exception cref=""></exception>
        public void WriteCSVData(List<string> columns, string path)
        {
            using (var fileStream = new FileStream(path, FileMode.Append))
            {
                using (var writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine(string.Join(Separator, columns));
                }
            }
        }


    }

}

