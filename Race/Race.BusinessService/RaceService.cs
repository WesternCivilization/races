using Race.BusinessService.Contract;
using Race.Domain;
using System;
using System.Collections.Generic;

namespace Race.BusinessService
{
    public class RaceService : IRaceService
    {
        private readonly IRaceDataProvider _raceDataProvider;

        public RaceService(IRaceDataProvider raceDataProvider)
        {
            _raceDataProvider = raceDataProvider;
        }

        public IEnumerable<Bet> GetBets()
        {
            IEnumerable<Bet> bets = _raceDataProvider.GetBets();
            return bets;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            IEnumerable<Customer> customers = _raceDataProvider.GetCustomers();
            return customers;
        }

        public IEnumerable<Domain.Race> GetRaces()
        {
            IEnumerable<Domain.Race> races = _raceDataProvider.GetRaces();
            return races;
        }
    }
}
