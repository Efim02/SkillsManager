namespace SkillsManager.Controllers;

using System;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Контроллер для проверки состояния сервиса.
/// </summary>
[ApiController]
[Route("api/live")]
public class LiveController : ControllerBase
{
    [HttpGet("bad")]
    public IActionResult BadLiveRequest()
    {
        return BadRequest();
    }

    [HttpGet("good")]
    public IActionResult GoodLiveRequest()
    {
        return Ok();
    }

    [HttpGet("read-health")]
    public IActionResult ReadLiveRequest()
    {
        if (Random.Shared.NextSingle() > 0.7)
            return BadRequest();

        return Ok("This server is health!");
    }
}