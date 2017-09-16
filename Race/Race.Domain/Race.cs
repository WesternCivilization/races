using System;
using System.Collections.Generic;

namespace Race.Domain
{
    public class Race : BaseEntity
    {
        public IEnumerable<Horse> Horses { get; set; }

        public DateTime Start { get; set; }

        public RaceStatus Status { get; set; }
    }
}
