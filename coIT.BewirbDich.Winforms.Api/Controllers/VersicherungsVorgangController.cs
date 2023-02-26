using coIT.BewirbDich.Api.Abstractions;
using coIT.BewirbDich.Application.VersicherungsVorgaenge.Commands;
using coIT.BewirbDich.Application.VersicherungsVorgaenge.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace coIT.BewirbDich.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class VersicherungsVorgangController : ApiController
{
    public VersicherungsVorgangController(ISender sender)
       : base(sender)
    {
    }

    [HttpPost("CreateVersicherungsVorgang")]
    public async Task<ActionResult<Guid>> CreateVersicherungsVorgangAsync(
        [FromBody] CreateVersicherungsVorgangCommand createVersicherungsVorgangCommand, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(createVersicherungsVorgangCommand, cancellationToken);
        if (result.IsSuccess)
        {
            return result.Value;
        }
        return HandleFailure(result);
    }

    [HttpPut("AngebotAkzeptieren/{id}")]
    public async Task<ActionResult> AngebotAkzeptierenAsync(Guid id, CancellationToken cancellationToken)
    {
        var command = new AngebotAkzeptierenCommand(id);
        var result = await Sender.Send(command, cancellationToken);
        if (result.IsSuccess)
        {
            return Ok();
        }
        return BadRequest(result.Error);
    }

    [HttpPut("VersicherungsscheinAustellen/{id}")]
    public async Task<IActionResult> VersicherungsscheinAustellenAsync(Guid id, CancellationToken cancellationToken)
    {
        var command = new VersicherungsscheinAustellenCommand(id);
        var result = await Sender.Send(command, cancellationToken);
        if (result.IsSuccess)
        {
            return Ok();
        }
        return HandleFailure(result);
    }

    [HttpDelete("VersicherungsVorgangLoeschen/{id}")]
    public async Task<IActionResult> VersicherungsVorgangLoeschenAsnyc(Guid id, CancellationToken cancellationToken)
    {
        var command = new VersicherungsVorgangLoeschenCommand(id);
        var result = await Sender.Send(command, cancellationToken);
        if (result.IsSuccess)
        {
            return Ok();
        }
        return HandleFailure(result);
    }

    [HttpGet("GetOffeneVersicherungsVorgaenge")]
    public async Task<ActionResult<VersicherungsVorgaengeResponse>> GetOffeneVersicherungsVorgaengeAsync(CancellationToken cancellationToken)
    {
        var query = new GetOffeneVersicherungsVorgaengeQuery();
        var result = await Sender.Send(query, cancellationToken);
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        return HandleFailure(result);
    }

    [HttpGet("GetBeendeteVersicherungsVorgaengeAsync")]
    public async Task<ActionResult<VersicherungsVorgaengeResponse>> GetBeendeteVersicherungsVorgaengeAsync(GetBeendeteVersicherungsVorgaengeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        return HandleFailure(result);
    }

    [HttpGet("GetVersicherungsvorgang/{id}")]
    public async Task<ActionResult<VersicherungsVorgangResponse>> GetVersicherungsVorgangAsync(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetVersicherungsvorgangByIdQuery(id);
        var result = await Sender.Send(query, cancellationToken);
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        return HandleFailure(result);
    }
}