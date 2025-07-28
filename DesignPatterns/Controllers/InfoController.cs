using DesignPatterns.Mediator;
using DesignPatterns.Mediator.Requests;
using DesignPatterns.Notification.WithDelegate;
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

    [HttpGet("mediator")]
    public IActionResult GetWithMediator(CancellationToken cancellationToken)
    {
        var infos = _sender.Send(new QueryRequest(), cancellationToken);

        return Ok(infos);
    }

    [HttpGet("notification/delegate")]
    public IActionResult NotifyWithDelegate(CancellationToken cancellationToken)
    {
        var service = new AService();
        service.ShowCount += OnShowCount;
        service.DoSomething();


        return Ok();
    }

    private void OnShowCount(int counter)
    {
        Console.WriteLine($"Somethins was done and was notified by delegate");
    }
}
