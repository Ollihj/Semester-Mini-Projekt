using Core.Models;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories;

namespace ServerAPI.Controllers;

[ApiController]
[Route("api/koebsanmodning")]
public class KøbsanmodningController : ControllerBase
{
    private readonly IKøbsanmodningRepository _repository;

    public KøbsanmodningController(IKøbsanmodningRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<List<købsanmodninger>> GetAll()
    {
        return Ok(_repository.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<købsanmodninger> GetById(string id)
    {
        var købsanmodning = _repository.GetById(id);
        if (købsanmodning == null) return NotFound();
        return Ok(købsanmodning);
    }

    [HttpPost]
    public ActionResult<købsanmodninger> Add([FromBody] købsanmodninger købsanmodning)
    {
        _repository.Add(købsanmodning);
        return Ok(købsanmodning);
    }

    [HttpPut]
    public ActionResult<købsanmodninger> Update([FromBody] købsanmodninger købsanmodning)
    {
        _repository.Update(købsanmodning);
        return Ok(købsanmodning);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(string id)
    {
        _repository.Delete(id);
        return Ok();
    }
}
