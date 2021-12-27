using CsvHelper.Configuration.Attributes;

namespace FilmsToWatch
{
    public class AuthorizedUser
    {
        [Index(0)]
        public string Name { get; set; }
        [Index(1)]
        public string Password { get; set; }
        [Index(2)]
        public bool IsAdmin { get; set; }
    }
}