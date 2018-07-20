namespace mongodemo.MongoRepository
{
    using MongoDB.Bson;
    using MongoDB.Bson.IO;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using Newtonsoft.Json.Linq;

    public class MongoRepository : IMongoRepository
    {
        public JObject GetProducts()
        {
            return GetData(8000000);
        }

        public JObject GetProduct(int productId)
        {
            return GetData(productId);
        }

        private static JObject GetData(int productId)
        {
            MongoClient client = new MongoClient("mongodb://asospravah:asospravah#1@ds020168.mlab.com:20168/asospravah");
            MongoServer server = client.GetServer();
            MongoDatabase database = server.GetDatabase("asospravah");
            var query = Query.EQ("productID", productId);
            var data = database.GetCollection<BsonDocument>("ProductData").FindOne(query);
            var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            return JObject.Parse(data.ToJson<MongoDB.Bson.BsonDocument>(jsonWriterSettings));
        }
    }
}
