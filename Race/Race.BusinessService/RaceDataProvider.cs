using Race.BusinessService.Contract;
using Race.Common.Service;
using Race.Domain;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Race.BusinessService
{
    public class RaceDataProvider : IRaceDataProvider
    {
        private const string Name = "rangana";

        private readonly IConfigManager _configManager;
        private readonly ISerializer _serializer;

        public RaceDataProvider(
            IConfigManager configManager,
            ISerializer serializer)
        {
            _configManager = configManager;
            _serializer = serializer;
        }

        public IEnumerable<Bet> GetBets()
        {
            IEnumerable<Bet> bets =
                ExecuteGet<IEnumerable<Bet>>($"api/GetBetsV2?name={Name}");
            return bets;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            IEnumerable<Customer> customers = 
                ExecuteGet<Customer[]>($"api/GetCustomers?name={Name}");

            return customers;
        }

        public IEnumerable<Domain.Race> GetRaces()
        {
            IEnumerable<Domain.Race> races =
                ExecuteGet<IEnumerable<Domain.Race>>($"api/GetRaces?name={Name}");
            return races;
        }

        private R ExecuteGet<R>(string url)
        {
            try
            {
                RestClient client = new RestClient(_configManager.Read("BaseUrl"));
                RestRequest request = new RestRequest(url, Method.GET);

                request.AddHeader("Accept", "application/xml");

                IRestResponse response = client.Execute(request);

                return _serializer.Deserialize<R>(response.Content);
            }
            catch (Exception ex)
            {
                // TODO: Log the exception - Skipped for brevity
                throw;
            }
        }
    }
}
