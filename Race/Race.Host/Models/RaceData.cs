using System.Collections.Generic;

namespace Race.Host.Models
{
    public class RaceData
    {
        public string Status { get; set; }

        public decimal TotalMoneyOnRace { get; set; }

        public IEnumerable<HorseData> Horses { get; set; }
    }
}