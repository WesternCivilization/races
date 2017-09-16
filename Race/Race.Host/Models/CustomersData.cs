using System.Collections.Generic;

namespace Race.Host.Models
{
    public class CustomersData
    {
        public IEnumerable<CustomerData> Customers { get; set; }

        public decimal TotalAmountOnBetsForAll { get; set; }
    }
}