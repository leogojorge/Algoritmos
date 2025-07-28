using DesignPatterns.Features;
using DesignPatterns.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers;

[ApiController]
[Route("[controller]")]
public class InfoController : ControllerBase
{
    private readonly ILogger<InfoController> _logger;
    private readonly ISender _sender;

    public InfoController(ILogger<InfoController> logger, ISender sender)
    {
        _logger = logger;
        _sender = sender;
    }

    [HttpGet]
    public IActionResult Get(CancellationToken cancellationToken)
    {
        var infos = _sender.Send(new QueryRequest(), cancellationToken);

        return Ok(infos);
    }
}
