using CsvHelper.Configuration.Attributes;

namespace FilmsToWatch
{
    public class User
    {
        [Index(0)]
        public string Name { get; set; }
        [Index(1)]
        public string Password { get; set; }
    }
}