using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        [HttpGet]
        public ActionResult GetProducts()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult GetProductById(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            throw new NotImplementedException();
        }
    }


}
