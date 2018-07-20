namespace mongodemo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MongoRepository;

    [Route("productmanagement/product/v1")]
    public class ProductManagementController : Controller
    {
        private readonly IMongoRepository _mongoRepository;

        public ProductManagementController(IMongoRepository _mongoRepository)
        {
            this._mongoRepository = _mongoRepository;
        }

        [HttpGet]
        [Route("products")]
        public IActionResult GetProduct()
        {
            return Json(_mongoRepository.GetProducts());
        }

        [HttpGet]
        [Route("products/{productId}")]
        public IActionResult GetProduct(int productId)
        {
            return Json(_mongoRepository.GetProduct(productId));
        }
    }
}