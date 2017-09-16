using Race.BusinessService.Contract;
using Race.Domain;
using System;
using System.Collections.Generic;

namespace Race.BusinessService
{
    public class RaceDataProvider : IRaceDataProvider
    {
        public IEnumerable<Bet> GetBets()
        {
            return new List<Bet>
            {
                new Bet
                {
                    Race = new Domain.Race
                    {
                        Id = 1,
                        Name = "Test",
                        Start = DateTime.Today.AddDays(1),
                        Status = RaceStatus.Pending,
                        Horses = new List<Horse>
                        {
                            new Horse
                            {
                                Id = 1,
                                Name = "Kandula",
                                Odds = 1.6m
                            },
                            new Horse
                            {
                                Id = 2,
                                Name = "Pema",
                                Odds = 8.9m
                            }
                        }
                    },
                    Horse = new Horse
                            {
                                Id = 1,
                                Name = "Kandula",
                                Odds = 1.6m
                            },
                    Stake = 380,
                    Customer = new Customer
                        {
                            Id = 1,
                            Name = "Rangana"
                        }
                }
            };
        }

        public IEnumerable<Customer> GetCustomers()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Domain.Race> GetRaces()
        {
            return new List<Domain.Race>
            {
                new Domain.Race
                {
                    Id = 1,
                    Name = "Test",
                    Start = DateTime.Today.AddDays(1),
                    Status = RaceStatus.Pending,
                    Horses = new List<Horse>
                    {
                        new Horse
                        {
                            Id = 1,
                            Name = "Kandula",
                            Odds = 1.6m
                        },
                        new Horse
                        {
                            Id = 2,
                            Name = "Pema",
                            Odds = 8.9m
                        }
                    }
                }
            };
        }
    }
}
