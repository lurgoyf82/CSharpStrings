using CSharpStrings.Api.SwaggerExamples;
using CSharpStrings.Application.DTOs.Requests;
using CSharpStrings.Application.DTOs.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System.Net;

namespace CSharpStrings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringsController : Controller
    {

        private readonly IMediator _mediator;
        private readonly ILogger<StringsController> _logger;


        public StringsController(IMediator mediator, ILogger<StringsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Route("/[action]")]
        [ProducesResponseType(typeof(GetStringResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [SwaggerRequestExample(typeof(GetStepOneRequestDto), typeof(GetStepOneRequestDtoExample))]
        public async Task<IActionResult> GetStepOneAsync([FromBody] GetStepOneRequestDto request)
        {
            GetStringResponseDto response = new();
            try
            {
                response = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
            return Ok(response);
        }









        [HttpPost]
        [Route("/[action]")]
        [ProducesResponseType(typeof(GetStringResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [SwaggerRequestExample(typeof(GetStepTwoRequestDto), typeof(GetStepTwoRequestDtoExample))]
        public async Task<IActionResult> GetStepTwoAsync([FromBody] GetStepTwoRequestDto request)
        {
            GetStringResponseDto response = new();
            try
            {
                response = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
            return Ok(response);
        }







        [HttpPost]
        [Route("/[action]")]
        [ProducesResponseType(typeof(GetStringResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [SwaggerRequestExample(typeof(GetStepThreeRequestDto), typeof(GetStepThreeRequestDtoExample))]
        public async Task<IActionResult> GetStepThreeAsync([FromBody] GetStepThreeRequestDto request)
        {
            GetStringResponseDto response = new();
            try
            {
                response = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
            return Ok(response);
        }






        [HttpPost]
        [Route("/[action]")]
        [ProducesResponseType(typeof(GetStringResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [SwaggerRequestExample(typeof(GetStepFourRequestDto), typeof(GetStepFourRequestDtoExample))]
        public async Task<IActionResult> GetStepFourAsync([FromBody] GetStepFourRequestDto request)
        {
            GetStringResponseDto response = new();
            try
            {
                response = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
            return Ok(response);
        }






        [HttpPost]
        [Route("/[action]")]
        [ProducesResponseType(typeof(GetStringResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [SwaggerRequestExample(typeof(GetStepFiveRequestDto), typeof(GetStepFiveRequestDtoExample))]
        public async Task<IActionResult> GetStepFiveAsync([FromBody] GetStepFiveRequestDto request)
        {
            GetStringResponseDto response = new();
            try
            {
                response = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
            return Ok(response);
        }





        [HttpPost]
        [Route("/[action]")]
        [ProducesResponseType(typeof(GetStringResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [SwaggerRequestExample(typeof(GetStepSixRequestDto), typeof(GetStepSixRequestDtoExample))]
        public async Task<IActionResult> GetStepSixAsync([FromBody] GetStepSixRequestDto request)
        {
            GetStringResponseDto response = new();
            try
            {
                response = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
            return Ok(response);
        }





        [HttpPost]
        [Route("/[action]")]
        [ProducesResponseType(typeof(GetStringResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [SwaggerRequestExample(typeof(GetStepSevenRequestDto), typeof(GetStepSevenRequestDtoExample))]
        public async Task<IActionResult> GetStepSevenAsync([FromBody] GetStepSevenRequestDto request)
        {
            GetStringResponseDto response = new();
            try
            {
                response = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
            return Ok(response);
        }
    }
}