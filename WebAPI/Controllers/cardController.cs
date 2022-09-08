using Bussines.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class cardController : ControllerBase
    {
        private ICardService _cardService;

        public cardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost("add")]
        public IActionResult Add(Card card)
        {
            var result = _cardService.Add(card);
            if (result.Succes)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var result = _cardService.GetByCustomerId(customerId);

            if (result.Succes)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}

