using ContosoCraft.Website.Models;
using ContosoCraft.Website.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCraft.Website.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService prodService) {
        
            this.jsonFileProdService = prodService; 
        }

        public JsonFileProductService jsonFileProdService { get; }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return jsonFileProdService.GetProducts();
        }

        [Route("Rate")]
        [HttpGet]
        public ActionResult Get([FromQuery]string productId,[FromQuery]int Rating)
        {
            jsonFileProdService.AddRating(productId, Rating);
            return Ok();
        }
    }
}
