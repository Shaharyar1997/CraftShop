using ContosoCraft.Website.Models;
using ContosoCraft.Website.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCraft.Website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileProductService productService;

        public IEnumerable<Product> products { get; private set; }  
        public IndexModel(ILogger<IndexModel> logger,JsonFileProductService prodService)
        {
            _logger = logger;
            this.productService = prodService;
        }

        public void OnGet()
        {
            products = productService.GetProducts();
        }
    }
}
