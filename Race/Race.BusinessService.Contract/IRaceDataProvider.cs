using Race.Domain;
using System.Collections.Generic;

namespace Race.BusinessService.Contract
{
    public interface IRaceDataProvider
    {
        IEnumerable<Customer> GetCustomers();

        IEnumerable<Bet> GetBets();

        IEnumerable<Domain.Race> GetRaces();
    }
}
