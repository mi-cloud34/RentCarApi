using Bussines.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class operationClaimController : ControllerBase
    {
      
            private readonly IOperationClaimService _operationClaimService;
            public operationClaimController(IOperationClaimService operationClaimService) => _operationClaimService = operationClaimService;

            [HttpPost("add")]//[HttpPost("add")]
            public IActionResult Add(OperationClaim operationClaim)
            {
                var result = _operationClaimService.Add(operationClaim);
                return result.Succes ? Ok(result) : BadRequest(result);
            }

            [HttpPost("update")]//[HttpPost("delete")]
            public IActionResult Delete(OperationClaim operationClaim)
            {
                var result = _operationClaimService.Delete(operationClaim);
                return result.Succes ? Ok(result) : BadRequest(result);
            }

            [HttpPost("delete")]//[HttpPost("update")]
            public IActionResult Update(OperationClaim operationClaim)
            {
                var result = _operationClaimService.Update(operationClaim);
                return result.Succes ? Ok(result) : BadRequest(result);
            }

            [HttpGet("getall")]
            public IActionResult GetAll()
            {
                var result = _operationClaimService.GetAll();
                return result.Succes ? Ok(result) : BadRequest(result);
            }

            [HttpGet("getbyid")]
            public IActionResult GetById(int id)
            {
                var result = _operationClaimService.GetById(id);
                return result.Succes ? Ok(result) : BadRequest(result);
            }
        }
    }
