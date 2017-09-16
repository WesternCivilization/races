using System.Collections.Generic;

namespace Race.BusinessService.Contract
{
    public interface IRaceService
    {
        IEnumerable<Domain.Race> GetRaces();

        IEnumerable<Domain.Customer> GetCustomers();

        IEnumerable<Domain.Bet> GetBets();
    }
}
