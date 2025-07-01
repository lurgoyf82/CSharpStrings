using CSharpStrings.Api.SwaggerExamples;
using CSharpStrings.Application.DTOs.Requests;
using CSharpStrings.Application.DTOs.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System.Net;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

namespace CSharpStrings.Controllers
{
    // <summary>
    // Controller principale per la String Calculator.
    // Include sette endpoint, uno per ciascuno step progressivo,
    // con regole di calcolo e TDD incrementali.
    // </summary>
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

        //1. The method can take 0, 1 or 2 numbers, separated by commas, and will return their sum, examples: 
        //    * “” should return 0
        //    * “1” should return 1
        //    * “1,2” should return 3
        //2. Start with the simplest test case of an empty string and move to one and two numbers.
        //3. Remember to solve things as simply as possible so that you force yourself to write tests you did not think about.
        //4. Remember to refactor after each passing test.
        [HttpPost]
        [Route("/[action]")]
        [ProducesResponseType(typeof(GetStringResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [SwaggerOperation(
            Summary = "Step 1 - Basic Add",
            Description = "1. The method can take 0, 1 or 2 numbers, separated by commas, and will return their sum, examples: \r\n"+
            "   * “” should return 0\r\n"+
            "   * “1” should return 1\r\n"+
            "   * “1,2” should return 3\r\n"+
            "2. Start with the simplest test case of an empty string and move to one and two numbers.\r\n"+
            "3. Remember to solve things as simply as possible so that you force yourself to write tests you did not think about.\r\n"+
            "4. Remember to refactor after each passing test."
        )]
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

        // Allow the Add method to handle an unknown amount of numbers.
        [HttpPost]
        [Route("/[action]")]
        [ProducesResponseType(typeof(GetStringResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [SwaggerOperation(
            Summary = "Step 2 - Remove quantity of numbers limitations",
            Description = "Allow the Add method to handle an unknown amount of numbers."
        )]
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

        // Calling Add with a negative number will throw an exception “negatives not allowed” - and the negative that was passed.
        // If there are multiple negatives, show all of them in the exception message
        [HttpPost]
        [Route("/[action]")]
        [ProducesResponseType(typeof(GetStringResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [SwaggerOperation(
            Summary = "Step 3 - Negative numbers",
            Description = "Calling Add with a negative number will throw an exception “negatives not allowed” - and the negative that was passed.\r\n" +
            "If there are multiple negatives, show all of them in the exception message."
        )]
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

        // Numbers bigger than 1000 should be ignored, for example “1000,2” should return 2
        [HttpPost]
        [Route("/[action]")]
        [ProducesResponseType(typeof(GetStringResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [SwaggerOperation(
            Summary = "Step 4 - Limit highest number allowed",
            Description = "Numbers bigger than 1000 should be ignored, for example “1000,2” should return 2"
        )]
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

        //Support different delimiters
        //Delimiters can be of any length with the following format: 
        //  * “//[delimiter]//”
        //  for example: 
        //    * “//[***]//1***2***3”
        //    should return 6
        [HttpPost]
        [Route("/[action]")]
        [ProducesResponseType(typeof(GetStringResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [SwaggerOperation(
            Summary = "Step 5 - Support different delimiters",
            Description = "Delimiters can be of any length with the following format: \r\n"+
            "  “//[delimiter]//”\r\n"+
            "  for example: \r\n"+
            "    “//[&#42;&#42;&#42;]//1&#42;&#42;&#42;2&#42;&#42;&#42;3” \r\n"+
            "    should return 6."
        )]
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

        //Allow multiple delimiters like this:  
        //  * “//[delim1][delim2]//”
        //  for example
        //    *“//[*][%]//1*2%3”
        //    should return 6
        [HttpPost]
        [Route("/[action]")]
        [ProducesResponseType(typeof(GetStringResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [SwaggerOperation(
            Summary = "Step 6 - Multiple delimiters",
            Description = "Allow multiple delimiters like this: \r\n" +
            "   * “//[delim1][delim2]//” \r\n" +
            "For example\r\n" +
            "   * “//[&#42;][%]//1&#42;2%3”\r\n" +
            "should return 6.\r\n"
        )]
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

        // Make sure you can also handle multiple delimiters with length longer than one char
        [HttpPost]
        [Route("/[action]")]
        [ProducesResponseType(typeof(GetStringResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [SwaggerOperation(
            Summary = "Step 7 - Different multiple delimiters",
            Description = "Make sure you can also handle multiple delimiters with length longer than one char."
        )]
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