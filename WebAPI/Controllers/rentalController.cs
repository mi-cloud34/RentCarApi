﻿using Bussines.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class rentalController : ControllerBase
    {
        IRentalService _rentalService;
        public rentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // yenisi = getrentaldetailbycarId  eski ismi = getbyid

        [HttpGet("getrentaldetailbycarId")]
        public IActionResult GetById(int CarId)
        {
            var result = _rentalService.GetById(CarId);
            if (result.Succes)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }



        [HttpGet("getcardetail")]
        public IActionResult GetCarDetailDtos()
        {

            var result = _rentalService.GetRentalDetails();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Succes)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            if (result.Succes)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

    }
}
