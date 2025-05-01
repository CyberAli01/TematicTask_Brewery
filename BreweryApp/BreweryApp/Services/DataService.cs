using BreweryApp.Data;
using BreweryApp.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace BreweryApp.Services
{
    public class DataService
    {
        private readonly BreweryContext _context;

        public DataService()
        {
            _context = new BreweryContext();
            _context.Database.EnsureCreated();
            SeedDataFromFiles();
        }

        private void SeedDataFromFiles()
        {
            if (!_context.Clients.Any())
            {
                var xmlSerializer = new XmlSerializer(typeof(List<Client>), new XmlRootAttribute("Clients"));
                using (var reader = new StreamReader("Data/clients.xml"))
                {
                    var clients = (List<Client>)xmlSerializer.Deserialize(reader);
                    _context.Clients.AddRange(clients);
                }
            }

            if (!_context.Beers.Any())
            {
                var json = File.ReadAllText("Data/beers.json");
                var beers = JsonConvert.DeserializeObject<List<Beer>>(json);
                _context.Beers.AddRange(beers);
            }
            
            _context.SaveChanges();

            if (!_context.Orders.Any())
            {
                var ordersJson = File.ReadAllText("Data/orders.json");
                var orders = JsonConvert.DeserializeObject<List<Order>>(ordersJson);

                foreach (var order in orders)
                {
                    if (order.OrderDate.Kind != DateTimeKind.Utc)
                    {
                        order.OrderDate = order.OrderDate.ToUniversalTime();
                    }

                    order.Total = order.OrderBeers.Select(oe =>
                    oe.Quantity * _context.Beers.FirstOrDefault(b => b.Id == oe.BeerId)!.ABV).Sum();
                }

                _context.Orders.AddRange(orders);
            }

            _context.SaveChanges();
        }

        public List<Order> GetOrdersWithDetails()
        {
            return _context.Orders
                .Include(o => o.Client)
                .Include(o => o.OrderBeers)
                    .ThenInclude(ob => ob.Beer)
                .ToList();
        }

        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }
    }
}