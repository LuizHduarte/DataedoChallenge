using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp.Services
{
    public class ReaderService
    {

        public static List<string> ImportData(string CsvPath)
        {

            var importedLines = new List<string>();
            var reader = new StreamReader(CsvPath);
            var header = reader.ReadLine();
            var headerSize = (header.Split(';').ToList()).Count;

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var column = line.Split(';').ToList();
                if (column.Count < headerSize)
                {
                    var missingColumns = headerSize - column.Count;
                    for (int i = 0; i < missingColumns; i++)
                    {
                        line = line + ";";
                    }
                }
                importedLines.Add(line);
            }

            return importedLines;
        }

    }
}
