using Core.Models;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories;

namespace ServerAPI.Controllers;

[ApiController]
[Route("api/annoncer")]
public class AnnonceController : ControllerBase
{
    private readonly IAnnonceRepository _repository;

    public AnnonceController(IAnnonceRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<List<annoncer>> GetAll()
    {
        return Ok(_repository.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<annoncer> GetById(string id)
    {
        var annoncer = _repository.GetById(id);
        if (annoncer == null) return NotFound();
        return Ok(annoncer);
    }

    [HttpPost]
    public ActionResult<annoncer> Add([FromBody] annoncer annoncer)
    {
        _repository.Add(annoncer);
        return Ok(annoncer);
    }

    [HttpPut]
    public ActionResult<annoncer> Update([FromBody] annoncer annoncer)
    {
        _repository.Update(annoncer);
        return Ok(annoncer);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(string id)
    {
        _repository.Delete(id);
        return Ok();
    }
}