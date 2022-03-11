using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace DataAnalyser.Models
{
    public class CsvFileParser
    {
        public string[][] Parse(IFormFile file,int lessRows)
        {
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false,
            };

            using var fileReader = new StreamReader(file.OpenReadStream());
            using var csvReader = new CsvReader(fileReader, csvConfig);

            string value;
            var result = new List<string[]>();

            while (csvReader.Read())
            {
                for (int i = lessRows; csvReader.TryGetField<string>(i, out value); i++)
                {
                    result.Add(value.Split(',').ToArray());
                    Console.WriteLine(value);
                }
            }

            return result.ToArray();
        }
    }
}
