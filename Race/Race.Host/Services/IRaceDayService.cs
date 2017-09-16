using Race.Host.Models;
using System.Collections.Generic;

namespace Race.Host.Services
{
    public interface IRaceDayService
    {
        IEnumerable<RaceData> GetRaces();

        CustomersData GetCustomers();
    }
}
