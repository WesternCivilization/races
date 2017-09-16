using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race.BusinessService.Contract
{
    public interface IRaceService
    {
        IEnumerable<Domain.Race> GetRaces();

        IEnumerable<Domain.Customer> GetCustomers();

        IEnumerable<Domain.Bet> GetBets();
    }
}
