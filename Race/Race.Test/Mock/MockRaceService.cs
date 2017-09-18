using Race.BusinessService.Contract;
using Race.Domain;
using System;
using System.Collections.Generic;

namespace Race.Test.Mock
{
    public class MockRaceService : IRaceService
    {
        public IEnumerable<Domain.Race> GetRaces()
        {
            return new List<Domain.Race>
            {
                new Domain.Race
                {
                    Id = 1,
                    Name = "Race 1",
                    Start = new DateTime(2017, 09, 20),
                    Status = RaceStatus.Pending,
                    Horses = new List<Horse>
                    {
                        new Horse
                        {
                            Id = 1,
                            Name = "Horse 1",
                            Odds = 1.5m
                        },
                        new Horse
                        {
                            Id = 2,
                            Name = "Horse 2",
                            Odds = 5.5m
                        },
                        new Horse
                        {
                            Id = 3,
                            Name = "Horse 3",
                            Odds = 3m
                        }
                    }
                },
                new Domain.Race
                {
                    Id = 2,
                    Name = "Race 2",
                    Start = new DateTime(2017, 09, 16),
                    Status = RaceStatus.Completed,
                    Horses = new List<Horse>
                    {
                        new Horse
                        {
                            Id = 1,
                            Name = "Horse 1",
                            Odds = 1.5m
                        },
                        new Horse
                        {
                            Id = 2,
                            Name = "Horse 2",
                            Odds = 5.5m
                        }
                    }
                },
                new Domain.Race
                {
                    Id = 3,
                    Name = "Race 3",
                    Start = new DateTime(2017, 09, 18),
                    Status = RaceStatus.InProgress,
                    Horses = new List<Horse>
                    {
                        new Horse
                        {
                            Id = 2,
                            Name = "Horse 2",
                            Odds = 5.5m
                        },
                        new Horse
                        {
                            Id = 3,
                            Name = "Horse 3",
                            Odds = 3m
                        }
                    }
                }
            };
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Name = "Rangana"
                },
                new Customer
                {
                    Id = 2,
                    Name = "Dulanjani"
                },
                new Customer
                {
                    Id = 3,
                    Name = "Jayantha"
                },
                new Customer
                {
                    Id = 4,
                    Name = "Ruvindra"
                },
                new Customer
                {
                    Id = 5,
                    Name = "Kumudu"
                }
            };
        }

        public IEnumerable<Bet> GetBets()
        {
            return new List<Bet>
            {
                new Bet
                {
                  Customer = new Customer { Id = 1 },
                  Horse = new Horse { Id = 1 },
                  Race = new Domain.Race { Id = 1 },
                  Stake = 120
                },
                new Bet
                {
                    Customer = new Customer { Id = 2 },
                    Horse = new Horse { Id = 2 },
                    Race = new Domain.Race { Id = 1 },
                    Stake = 200
                },
                new Bet
                {
                    Customer = new Customer { Id = 3 },
                    Horse = new Horse { Id = 1 },
                    Race = new Domain.Race { Id = 2 },
                    Stake = 500
                },
                new Bet
                {
                    Customer = new Customer { Id = 4 },
                    Horse = new Horse { Id = 3 },
                    Race = new Domain.Race { Id = 3 },
                    Stake = 50
                }
            };
        }
    }
}
