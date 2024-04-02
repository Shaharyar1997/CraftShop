using ContosoCraft.Website.Models;
using System.Text.Json;

namespace ContosoCraft.Website.Services
{
    public class JsonFileProductService
    {
        public IWebHostEnvironment webHost { get; }
        public JsonFileProductService(IWebHostEnvironment webHost) {
         this.webHost = webHost;
        }
        private string JsonFileName
        {
            get {
                return Path.Combine(webHost.WebRootPath, "data", "products.json");
                    }
        }

        public IEnumerable<Product> GetProducts()
        {

            using(var fileReader=File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Product[]>(fileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive=true
                    });
            }
            
        }

        public void AddRating(string productId,int rating)
        {
            var products=GetProducts();
            
            var product=products.First(X=>X.Id==productId);

            if (product.Ratings == null)
            {
                product.Ratings = new int?[] { rating };
            }
            else
            {
                var query = product.Ratings.ToList();
                query.Add(rating);
                product.Ratings=query.ToArray();
            }
            using(var outputStream=File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize < IEnumerable<Product>>(new Utf8JsonWriter(outputStream, new JsonWriterOptions
                {
                    Indented = true,
                    SkipValidation = true,
                }),products);
            }
        }
    
    }
}
