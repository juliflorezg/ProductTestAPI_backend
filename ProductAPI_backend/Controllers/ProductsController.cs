using System.ComponentModel.DataAnnotations;
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


    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }


        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
    public class ProductInsertDTO
    {

        public string Name { get; set; }


        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
    public class ProductUpdateDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }


        public decimal Price { get; set; }

        public int Stock { get; set; }
    }

}
