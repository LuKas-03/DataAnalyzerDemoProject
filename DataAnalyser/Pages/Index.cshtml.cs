using DataAnalyser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace DataAnalyser.Pages
{
    public class IndexModel : PageModel
    {
        public List<string> Values = new List<string>();
        public bool IsShowResults;

        [BindProperty]
        public FileSource FileSource { get; set; }

        public void OnGet()
        {
            IsShowResults = Values.Count > 0;
            Console.WriteLine(Values.Count);
        }

        public async Task OnPostAsync()
        {
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false
            };

            using var fileReader = new StreamReader(FileSource.UploadFile.OpenReadStream());
            using var csvReader = new CsvReader(fileReader, csvConfig);

            string value;

            while (csvReader.Read())
            {
                for (int i = FileSource.MissLinesCount; csvReader.TryGetField<string>(i, out value); i++)
                {
                    Values.Add(value);
                    Console.WriteLine(value);
                }
            }

            IsShowResults = Values.Count > 0;
        }
    }
}