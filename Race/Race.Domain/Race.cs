using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race.Domain
{
    public class Race : BaseEntity
    {
        public IEnumerable<Horse> Horses { get; set; }

        public DateTime Start { get; set; }

        public RaceStatus Status { get; set; }
    }
}
