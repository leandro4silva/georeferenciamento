using Georeferenciamento.Application.Common.Models;
using Georeferenciamento.Application.Handlers.CreateState;
using Georeferenciamento.Application.Handlers.GetCitie;
using Georeferenciamento.Application.Handlers.GetState;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Georeferenciamento.Api.Controllers;

[Route("v1/states")]
[ApiController]
public class StateController : ControllerBase
{
    private readonly IMediator _mediator;

    public StateController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateState(
        [FromBody] CreateStateCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);

        return CreatedAtAction(nameof(CreateState), null);
    }
    
    [HttpGet("{statePostCode}")] 
    [ProducesResponseType(typeof(BaseResponse<GetStateResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetState([FromRoute] string statePostCode, CancellationToken cancellationToken)
    {
        var request = new GetStateCommand()
        {
            StatePostalCode = statePostCode 
        };
    
        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response);
    }
    
    [HttpGet("{statePostCode}/{city}")] 
    [ProducesResponseType(typeof(BaseResponse<GetCitiesResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetState([FromRoute] string statePostCode, [FromRoute] string city, CancellationToken cancellationToken)
    {
        var request = new GetCitieCommand()
        {
            StatePostalCode = statePostCode,
            CityName = city
        };
    
        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response);
    }
  
}