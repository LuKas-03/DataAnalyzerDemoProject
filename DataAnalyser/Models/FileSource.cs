namespace DataAnalyser.Models
{
    public class FileSource : ISource
    {
        public SourceType SourceType { get; set; }
        public int MissLinesCount { get; set; } = 0;
        public IFormFile UploadFile { get; set; } 
    }
}
