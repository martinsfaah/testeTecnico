using Microsoft.AspNetCore.Mvc;
using project.Models;
using project.Repository;

namespace project.Controllers
{
  [ApiController]
  [Route("project")]

  public class ProjectController : Controller
  {
    private readonly IProjectRepository _repository;
    public ProjectController(IProjectRepository repository)
    {
      _repository = repository;
    }

    [HttpGet]
    public IActionResult GetInscricao()
    {
      return Ok(_repository.GetInscricao());
    }

    [HttpPost]
    public IActionResult AddCandidato([FromBody]Candidato candidato)
    {
        if (candidato.Cpf.Length != 11 || candidato == null) {
          return BadRequest();
        }
        _repository.AddCandidato(candidato);

        return CreatedAtRoute(candidato.Nome, candidato);
    }

    [HttpPost]
    public IActionResult AddCurso([FromBody]Curso curso)
    {
        if (curso == null) {
            return BadRequest();
        }
        _repository.AddCurso(curso);

        return CreatedAtRoute(curso.Nome, curso);
    }

    [HttpPost]
    public IActionResult AddInscricao([FromBody]Inscricao inscricao)
    {
        if (inscricao == null) {
            return BadRequest();
        }
        _repository.AddInscricao(inscricao);

        return Ok();      
    }

  }
}