using System;
using System.Collections.Generic;
using System.Linq;
using Race.ApplicationService.Models;
using Race.BusinessService.Contract;
using Race.Common;
using Race.Domain;

namespace Race.ApplicationService.Services
{
    public class RaceDayService : IRaceDayService
    {
        private readonly IRaceService _raceService;

        public RaceDayService(IRaceService raceService)
        {
            _raceService = raceService;
        }

        public CustomersData GetCustomers()
        {
            IEnumerable<Domain.Customer> customers = _raceService.GetCustomers();
            IEnumerable<Domain.Bet> bets = _raceService.GetBets();

            if (customers == null) return new CustomersData();

            IList<CustomerData> customersData = new List<CustomerData>();

            foreach (Domain.Customer customer in customers)
            {
                CustomerData customerData = CreateCustomerData(customer, bets);
                customersData.Add(customerData);
            }

            decimal totalAmountForAllCustomers = Math.Round(customersData.Sum(c => c.TotalAmountOnBets), 2);

            return new CustomersData
            {
                Customers = customersData,
                TotalAmountOnBetsForAll = totalAmountForAllCustomers
            };
        }

        public IEnumerable<RaceData> GetRaces()
        {
            IEnumerable<Domain.Race> races = _raceService.GetRaces();
            IEnumerable<Domain.Bet> bets = _raceService.GetBets();

            IList<RaceData> racesData = new List<RaceData>();

            if (races == null) return racesData;

            foreach (Domain.Race race in races)
            {
                RaceData raceData = CreateRaceData(race, bets);
                racesData.Add(raceData);
            }

            return racesData;
        }

        private RaceData CreateRaceData(Domain.Race race, IEnumerable<Domain.Bet> bets)
        {
            RaceData raceData = new RaceData
            {
                Status = race.Status.GetDescription()
            };

            IEnumerable<Domain.Bet> betsOnRace = bets?.Where(b => b.Race?.Id == race.Id);

            raceData.TotalMoneyOnRace = betsOnRace.Sum(b => b.Stake);

            if (race.Horses != null)
            {
                IList<HorseData> horsesData = new List<HorseData>();

                foreach (Domain.Horse horse in race.Horses)
                {
                    HorseData horseData = new HorseData
                    {
                        Name = horse.Name,
                        NumberOfBetsOnMe = bets?.Where(b => b.Horse?.Id == horse.Id).Count() ?? 0
                    };
                    horseData.PayoutIfIWin = horseData.NumberOfBetsOnMe * horse.Odds;

                    horsesData.Add(horseData);
                }

                raceData.Horses = horsesData;
            }

            return raceData;
        }

        private CustomerData CreateCustomerData(Customer customer, IEnumerable<Bet> bets)
        {
            IList<Bet> betsByCustomer = bets?.Where(b => b.Customer?.Id == customer.Id).ToList();

            CustomerData customerData = new CustomerData
            {
                NumberOfBets = betsByCustomer.Count(),
                TotalAmountOnBets = betsByCustomer.Sum(b => b.Stake)
            };

            customerData.IsAtRisk = 
                customerData.TotalAmountOnBets > Constant.RiskBetThreshold;

            return customerData;
        }

    }
}
