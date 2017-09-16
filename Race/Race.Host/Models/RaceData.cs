using Race.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Race.Host.Models
{
    public class RaceData
    {
        public string Status { get; set; }

        public decimal TotalMoneyOnRace { get; set; }

        public IEnumerable<HorseData> Horses { get; set; }
    }
}