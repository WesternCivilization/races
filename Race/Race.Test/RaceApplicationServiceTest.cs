using Microsoft.VisualStudio.TestTools.UnitTesting;
using Race.ApplicationService.Models;
using Race.ApplicationService.Services;
using Race.Test.Mock;
using System.Collections.Generic;
using System.Linq;

namespace Race.Test
{
    [TestClass]
    public class RaceApplicationServiceTest
    {
        [TestMethod]
        public void WhenCustomersAvailable()
        {
            // Arrange
            IRaceDayService raceDayService = 
                new RaceDayService(new MockRaceService());

            int expectedCustomerCount = 5;
            decimal expectedTotalAmountOnBets = 120 + 200 + 500 + 50;
            IDictionary<int, int> expectedNumberOfBetsByCustomer = new Dictionary<int, int>
            {
                { 1, 1 },  { 2, 1 }, { 3, 1 }, { 4, 1 }, { 5, 0 }
            };

            IDictionary<int, decimal> expectedTotalAmountOnBetsByCustomer = new Dictionary<int, decimal>
            {
                { 1, 120 },  { 2, 200 }, { 3, 500 }, { 4, 50 }, { 5, 0 }
            };

            IDictionary<int, bool> expectedRiskByCustomer = new Dictionary<int, bool>
            {
                { 1, false },  { 2, false }, { 3, true }, { 4, false }, { 5, false }
            };

            // Act
            CustomersData customersData = raceDayService.GetCustomers();

            // Assert
            Assert.IsNotNull(customersData);
            Assert.AreEqual(expectedCustomerCount, customersData.Customers.Count());
            Assert.AreEqual(expectedTotalAmountOnBets, customersData.TotalAmountOnBetsForAll);

            foreach (CustomerData customerData in customersData.Customers)
            {
                Assert.IsNotNull(customerData);
                Assert.AreEqual(expectedNumberOfBetsByCustomer[customerData.Id], customerData.NumberOfBets);
                Assert.AreEqual(expectedTotalAmountOnBetsByCustomer[customerData.Id], customerData.TotalAmountOnBets);
                Assert.AreEqual(expectedRiskByCustomer[customerData.Id], customerData.IsAtRisk);
            }
        }

        [TestMethod]
        public void WhenRacesAvailable()
        {
            // Arrange
            IRaceDayService raceDayService =
                new RaceDayService(new MockRaceService());

            int expectedRacesCount = 3;
            IDictionary<int, string> expectedRaceStatusByRace = new Dictionary<int, string>
            {
                { 1, "Pending" },  { 2, "Completed" }, { 3, "In Progress" }
            };

            IDictionary<int, decimal> expectedMoneyByRace = new Dictionary<int, decimal>
            {
                { 1, 320 },  { 2, 500 }, { 3, 50 }
            };

            IDictionary<int, string> expectedHorsesByRace = new Dictionary<int, string>
            {
                { 1, "Horse 1:Horse 2:Horse 3" },  { 2, "Horse 1:Horse 2" }, { 3, "Horse 2:Horse 3" }
            };

            IDictionary<int, int> expectedBetsByHorse = new Dictionary<int, int>
            {
                { 1, 2 },  { 2, 1 }, { 3, 1 }
            };

            IDictionary<int, decimal> expectedPayoutByHorse = new Dictionary<int, decimal>
            {
                { 1, 2*1.5m },  { 2, 1*5.5m }, { 3, 1*3m }
            };

            // Act
            IEnumerable<RaceData> racesData = raceDayService.GetRaces();

            // Assert
            Assert.IsNotNull(racesData);
            Assert.AreEqual(expectedRacesCount, racesData.Count());

            foreach (RaceData raceData in racesData)
            {
                Assert.IsNotNull(raceData);
                Assert.AreEqual(expectedRaceStatusByRace[raceData.Id], raceData.Status);
                Assert.AreEqual(expectedMoneyByRace[raceData.Id], raceData.TotalMoneyOnRace);

                string[] expectedHorses = expectedHorsesByRace[raceData.Id].Split(':');
                Assert.AreEqual(expectedHorses.Length, raceData.Horses.Count());

                foreach (HorseData horseData in raceData.Horses)
                {
                    Assert.IsNotNull(horseData);
                    Assert.IsTrue(expectedHorses.Any(h => h == horseData.Name));
                    Assert.AreEqual(expectedBetsByHorse[horseData.Id], horseData.NumberOfBets);
                    Assert.AreEqual(expectedPayoutByHorse[horseData.Id], horseData.PayoutIfWon);
                }
            }
        }
    }
}
