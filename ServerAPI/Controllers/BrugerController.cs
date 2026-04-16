using Core.Models;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories;

namespace ServerAPI.Controllers;

[ApiController]
[Route("api/bruger")]
public class BrugerController : ControllerBase
{
    private readonly IBrugerRepository _repository;

    public BrugerController(IBrugerRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<List<bruger>> GetAll()
    {
        return Ok(_repository.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<bruger> GetById(string id)
    {
        var bruger = _repository.GetById(id);
        if (bruger == null) return NotFound();
        return Ok(bruger);
    }

    [HttpGet("login")]
    public ActionResult<bruger> Login([FromQuery] string navn, [FromQuery] string password)
    {
        var allBrugere = _repository.GetAll();
        var bruger = allBrugere.FirstOrDefault(b => b.Navn == navn && b.Password == password);
        
        if (bruger == null)
            return Unauthorized(new { message = "Ugyldigt brugernavn eller adgangskode" });
        
        return Ok(bruger);
    }

    [HttpPost("register")]
    public ActionResult<bruger> Register([FromBody] bruger bruger)
    {
        var allBrugere = _repository.GetAll();
        if (allBrugere.Any(b => b.Navn == bruger.Navn))
            return BadRequest(new { message = "Brugernavn findes allerede" });
        
        _repository.Add(bruger);
        return Ok(bruger);
    }

    [HttpPost]
    public ActionResult<bruger> Add([FromBody] bruger bruger)
    {
        _repository.Add(bruger);
        return Ok(bruger);
    }

    [HttpPut]
    public ActionResult<bruger> Update([FromBody] bruger bruger)
    {
        _repository.Update(bruger);
        return Ok(bruger);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(string id)
    {
        _repository.Delete(id);
        return Ok();
    }
}
