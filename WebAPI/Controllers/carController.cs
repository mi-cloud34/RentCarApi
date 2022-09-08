using Bussines.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class carController : ControllerBase
    {
        ICarService _carService;
        public carController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
            //IProductService productService = new ProductManager(new EfProductDal());
            var result = _carService.GetAll();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbyId")]
        public IActionResult GetById(int id)
        {
            //IProductService productService = new ProductManager(new EfProductDal());
            var result = _carService.GetById(id);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            //IProductService productService = new ProductManager(new EfProductDal());
            var result = _carService.Add(car);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
