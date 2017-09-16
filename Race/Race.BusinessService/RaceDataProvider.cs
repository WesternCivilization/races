using System.Collections.Generic;
using Race.BusinessService.Contract;
using Race.Domain;

namespace Race.BusinessService
{
    public class RaceDataProvider : IRaceDataProvider
    {
        public IEnumerable<Bet> GetBets()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Domain.Race> GetRaces()
        {
            throw new System.NotImplementedException();
        }
    }
}
