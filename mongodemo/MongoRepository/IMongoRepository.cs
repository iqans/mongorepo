namespace mongodemo.MongoRepository
{
    using Newtonsoft.Json.Linq;

    public interface IMongoRepository
    {
        JObject GetProducts();
        JObject GetProduct(int productId);
    }
}
