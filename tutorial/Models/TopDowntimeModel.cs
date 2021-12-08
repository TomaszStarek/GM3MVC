using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial.Models
{
    public class TopDowntimeModel
    {
        public string Sekcja { get; set; }
        public string Stacja { get; set; }
        public string Opis{ get; set; }
        public int LiczbaWystapien { get; set; }
        public int TotalMinutes { get; set; }
        public List<int> Ids { get; set; }

    }
}
