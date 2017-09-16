using Race.BusinessService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Race.Domain;

namespace Race.BusinessService
{
    public class RaceService : IRaceService
    {
        public IEnumerable<Bet> GetBets()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Race> GetRaces()
        {
            throw new NotImplementedException();
        }
    }
}
