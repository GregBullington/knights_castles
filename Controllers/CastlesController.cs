using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using knights_castles.Models;
using knights_castles.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace knights_castles.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CastlesController : ControllerBase
  {
    private readonly CastlesService _cs;
    public CastlesController(CastlesService cs)
    {
      _cs = cs;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Castle>> Get()
    {
      try
      {
        List<Castle> castles = _cs.Get();
        return Ok(castles);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Castle>> Create([FromBody] Castle newCastle)
    {
      try
      {
        Account user = await HttpContext.GetUserInfoAsync<Account>();
        newCastle.CreatorId = user.Id;
        Castle castle = _cs.Create(newCastle);
        castle.Creator = user;
        return Ok(castle);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}