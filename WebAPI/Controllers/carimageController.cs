using Bussines.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class carimageController : ControllerBase
    {
        private readonly ICarImageService _carImageService;
        public carimageController(ICarImageService carImageService) => _carImageService = carImageService;

        [HttpPost]
        public IActionResult Add([FromForm(Name = "Image")] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(file, carImage);
            return result.Succes ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(CarImage carImage)
        {
            var carDeleteImage = _carImageService.GetById(carImage.CarImageId).Data;
            var result = _carImageService.Delete(carDeleteImage);
            return result.Succes ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update([FromForm(Name = "Image")] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Update(file, carImage);
            return result.Succes ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            return result.Succes ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            return result.Succes ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getimagesbycarid")]
        //[Route("getimagesbycarid/{carId}")]
        public IActionResult GetImagesByCarId(int carId)
        {
            var result = _carImageService.GetImagesByCarId(carId);
            return result.Succes ? Ok(result) : BadRequest(result);
        }
    }
}
