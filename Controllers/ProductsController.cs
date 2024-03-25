using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VueDemo.Models;
using VueDemo.Models.Abstract;

namespace VueDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductDal _productDal;

        public ProductsController(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _productDal.GetAll();

            return Ok(result);
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] Product product)
        {
            _productDal.Add(product);
            return Ok();//Tüm ürünleri dön 
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromQuery] int id)
        {
            _productDal.Delete(id);
            return Ok();
        }


    }
}
