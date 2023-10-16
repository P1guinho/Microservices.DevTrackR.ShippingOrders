using DevTrackR.ShippingOrders.Core.Entities;
using MongoDB.Driver;

namespace DevTrackR.ShippingOrders.Infra.Persistance
{
    public class DbSeed
    {
        private readonly IMongoCollection<ShippingService> _collection;
        private List<ShippingService> _shippingServices = new List<ShippingService> {
            new ShippingService("Envio estadual", 3.75m, 12),
            new ShippingService("Envio interestadual", 5, 15),
            new ShippingService("Envio internacional", 8.25m, 25),
            new ShippingService("Caixa tamanho P", 0, 6),
            new ShippingService("Caixa tamanho M", 0, 8),
            new ShippingService("Caixa tamanho G", 0, 10),
        };

        public DbSeed(IMongoDatabase database)
        {
            _collection = database.GetCollection<ShippingService>("shipping-services");
        }

        public void Populate()
        {
            if (_collection.CountDocuments(c => true) == 0)
                _collection.InsertMany(_shippingServices);
        }
    }
}
