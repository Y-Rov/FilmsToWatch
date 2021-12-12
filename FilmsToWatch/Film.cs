using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsToWatch
{
    class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public List<string> ActorList { get; set; }
        public int RunningTimeInMinutes { get; set; }
        public string ProductionCompany { get; set; }
        public int ReleaseYear { get; set; }
        public string Language { get; set; }
        public decimal Budget { get; set; }
    }
}
