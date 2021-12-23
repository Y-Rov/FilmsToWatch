using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml.Attributes;

namespace FilmsToWatch
{
    public class Film
    {
        [EpplusIgnore]
        public int Id { get; set; }

        [EpplusTableColumn(Order = 1, NumberFormat = "General")]
        public string Title { get; set; }

        [EpplusTableColumn(Order = 2, NumberFormat = "General")]
        public string Director { get; set; }

        [EpplusTableColumn(Order = 3, NumberFormat = "General")]
        public string Genre { get; set; }

        [EpplusTableColumn(Order = 4, NumberFormat = "General")]
        public string Actors { get; set; }

        [EpplusTableColumn(Order = 5, NumberFormat = "General")]
        public string ProductionCompany { get; set; }

        [EpplusTableColumn(Order = 6, NumberFormat = "General")]
        public string Language { get; set; }

        [EpplusTableColumn(Order = 7, NumberFormat = "0")]
        public int ReleaseYear { get; set; }

        [EpplusTableColumn(Order = 8, NumberFormat = "0")]
        public int RunningTimeInMinutes { get; set; }

        [EpplusTableColumn(Order = 9, NumberFormat = "[$$-409]#,##0")]
        public decimal Budget { get; set; }
    }
}
