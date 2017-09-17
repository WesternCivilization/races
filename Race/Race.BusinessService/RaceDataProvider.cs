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
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Race.BusinessService
{
    public class RaceDataProvider : IRaceDataProvider
    {
        private const string Name = "rangana";

        private readonly IConfigManager _configManager;

        public RaceDataProvider(IConfigManager configManager)
        {
            _configManager = configManager;
        }

        public IEnumerable<Bet> GetBets()
        {
            XDocument doc = ExecuteGet($"api/GetBetsV2?name={Name}");
            XNamespace ns = doc.Root.GetDefaultNamespace().NamespaceName;

            IEnumerable<Bet> bets = doc.Root?.Elements()
                .Select(e => new Bet
                {
                    Customer = new Customer
                    {
                        Id = int.Parse(e.Element(ns + "customerId").Value)
                    },
                    Horse = new Horse
                    {
                        Id = int.Parse(e.Element(ns + "horseId").Value)
                    },
                    Race = new Domain.Race
                    {
                        Id = int.Parse(e.Element(ns + "raceId").Value)
                    },
                    Stake = decimal.Parse(e.Element(ns + "stake").Value)
                })
                .ToList();

            return bets;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            XDocument doc = ExecuteGet($"api/GetCustomers?name={Name}");
            XNamespace ns = doc.Root.GetDefaultNamespace().NamespaceName;

            IEnumerable<Customer> customers = doc.Root?.Elements()
                .Select(e => new Customer
                {
                    Id = int.Parse(e.Element(ns + "id").Value),
                    Name = e.Element(ns + "name").Value
                })
                .ToList();

            return customers;
        }

        public IEnumerable<Domain.Race> GetRaces()
        {
            XDocument doc = ExecuteGet($"api/GetRaces?name={Name}");
            XNamespace ns = doc.Root.GetDefaultNamespace().NamespaceName;

            IEnumerable<Domain.Race> races = doc.Root?.Elements()
                .Select(e => new Domain.Race
                {
                    Id = int.Parse(e.Element(ns + "id").Value),
                    Name = e.Element(ns + "name").Value,
                    Start = DateTime.Parse(e.Element(ns + "start").Value),
                    Status = (RaceStatus)Enum.Parse(typeof(RaceStatus), e.Element(ns + "status").Value, true),
                    Horses = e.Element(ns + "horses")?.Elements()?.Select(h => 
                                    new Horse
                                    {
                                        Id = int.Parse(h.Element(ns + "id").Value),
                                        Name = h.Element(ns + "name").Value,
                                        Odds = decimal.Parse(h.Element(ns + "odds").Value)
                                    }).ToList()
                })
                .ToList();

            return races;
        }

        private XDocument ExecuteGet(string url)
        {
            try
            {
                RestClient client = new RestClient(_configManager.Read("BaseUrl"));
                RestRequest request = new RestRequest(url, Method.GET);

                request.AddHeader("Accept", "application/xml");

                IRestResponse response = client.Execute(request);

                return XDocument.Parse(response.Content);
            }
            catch (Exception ex)
            {
                // TODO: Log the exception - Skipped for brevity
                throw;
            }
        }        
    }
}

