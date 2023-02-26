using coIT.BewirbDich.Winforms.Application.VersicherungsVorgaenge.Commands;
using coIT.BewirbDich.Winforms.Application.VersicherungsVorgaenge.Queries;
using coIT.BewirbDich.Winforms.Domain;
using coIT.BewirbDich.Winforms.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace coIT.BewirbDich.Winforms.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class VersicherungsVorgangController : ControllerBase
{
    private readonly ILogger logger;
    private readonly ISender sender;

    public VersicherungsVorgangController(ILogger<VersicherungsVorgangController> logger,
        ISender sender)
    {
        this.logger = logger;
        this.sender = sender;
    }

    [HttpPost("CreateVersicherungsVorgang")]
    public async Task<ActionResult<Guid>> CreateVersicherungsVorgangAsync(
        [FromBody] CreateVersicherungsVorgangCommand createVersicherungsVorgangCommand, CancellationToken cancellationToken)
    {
        try
        {
            var result = await sender.Send(createVersicherungsVorgangCommand, cancellationToken);
            if (result.IsSuccess)
            {
                return result.Value;
            }
            return BadRequest(result.Error);
        }
        catch (Exception e)
        {
            logger.LogError(e, nameof(CreateVersicherungsVorgangAsync));
            return BadRequest();
        }
    }

    [HttpPut("AngebotAkzeptieren/{id}")]
    public async Task<ActionResult> AngebotAkzeptierenAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var command = new AngebotAkzeptierenCommand(id);
            var result = await sender.Send(command, cancellationToken);
            if (result.IsSuccess)
            {
                return Ok();
            }
            return BadRequest(result.Error);
        }
        catch (Exception e)
        {
            logger.LogError(e, nameof(AngebotAkzeptierenAsync));
            return BadRequest();
        }
    }

    [HttpPut("VersicherungsscheinAustellen/{id}")]
    public async Task<ActionResult> VersicherungsscheinAustellenAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var command = new VersicherungsscheinAustellenCommand(id);
            var result = await sender.Send(command, cancellationToken);
            if (result.IsSuccess)
            {
                return Ok();
            }
            return BadRequest(result.Error);
        }
        catch (Exception e)
        {
            logger.LogError(e, nameof(VersicherungsscheinAustellenAsync));
            return BadRequest();
        }
    }

    [HttpDelete("VersicherungsVorgangLoeschen/{id}")]
    public async Task<ActionResult> VersicherungsVorgangLoeschenAsnyc(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var command = new VersicherungsVorgangLoeschenCommand(id);
            var result = await sender.Send(command, cancellationToken);
            if (result.IsSuccess)
            {
                return Ok();
            }
            return BadRequest(result.Error);
        }
        catch (Exception e)
        {
            logger.LogError(e, nameof(VersicherungsVorgangLoeschenAsnyc));
            return BadRequest();
        }
    }

    [HttpGet("GetOffeneVersicherungsVorgaenge")]
    public async Task<ActionResult<VersicherungsVorgaengeResponse>> GetOffeneVersicherungsVorgaengeAsync(CancellationToken cancellationToken)
    {
        try
        {
            var query = new GetOffeneVersicherungsVorgaengeQuery();
            var result = await sender.Send(query, cancellationToken);
            if (result.IsSuccess)
            {
                return result.Value;
            }
            return BadRequest(result.Error);
        }
        catch (Exception e)
        {
            logger.LogError(e, nameof(GetVersicherungsVorgangAsync));
            return BadRequest();
        }
    }

    [HttpGet("GetBeendeteVersicherungsVorgaengeAsync")]
    public async Task<ActionResult<VersicherungsVorgaengeResponse>> GetBeendeteVersicherungsVorgaengeAsync(GetBeendeteVersicherungsVorgaengeQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await sender.Send(request, cancellationToken);
            if (result.IsSuccess)
            {
                return result.Value;
            }
            return BadRequest(result.Error);
        }
        catch (Exception e)
        {
            logger.LogError(e, nameof(GetBeendeteVersicherungsVorgaengeAsync));
            return BadRequest();
        }
    }

    [HttpGet("GetVersicherungsvorgang/{id}")]
    public async Task<ActionResult<VersicherungsVorgangResponse>> GetVersicherungsVorgangAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var query = new GetVersicherungsvorgangByIdQuery(id);
            var result = await sender.Send(query, cancellationToken);
            if (result.IsSuccess)
            {
                return result.Value;
            }
            return BadRequest(result.Error);
        }
        catch (Exception e)
        {
            logger.LogError(e, nameof(GetVersicherungsVorgangAsync));
            return BadRequest();
        }
    }
}