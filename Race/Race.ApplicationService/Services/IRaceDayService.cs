using System.Collections.Generic;
using Race.ApplicationService.Models;

namespace Race.ApplicationService.Services
{
    public interface IRaceDayService
    {
        IEnumerable<RaceData> GetRaces();

        CustomersData GetCustomers();
    }
}
