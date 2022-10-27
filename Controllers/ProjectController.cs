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
    public IActionResult GetAllInscricao()
    {
      var response = _repository.GetAllInscricao().Select(o => new InscricaoResponse(){
        NomeCandidato = o.Candidato.Nome,
        CpfCandidato = o.Candidato.Cpf,
        NomeCurso = o.Curso.Nome
      });
      return Ok(response);
    }

    [HttpGet("view")]
    public IActionResult ProjectView()
    {
      var response = _repository.GetAllInscricao().Select(o => new InscricaoResponse(){
        NomeCandidato = o.Candidato.Nome,
        CpfCandidato = o.Candidato.Cpf,
        NomeCurso = o.Curso.Nome
      });
      ViewBag.Inscricao = response;
      return View();
    }

    [HttpPost("/candidato")]
    public IActionResult AddCandidato([FromBody] AddCandidatoRequest addCandidatoRequest)
    {
        if (addCandidatoRequest.Cpf.Length != 11 || addCandidatoRequest == null) {
          return BadRequest();
        }

        Candidato candidato = new() { Cpf = addCandidatoRequest.Cpf, Nome = addCandidatoRequest.Nome };
        _repository.AddCandidato(candidato);

        return Ok();
    }

    [HttpPost("/curso")]
    public IActionResult AddCurso([FromBody]AddCursoRequest addCursoRequest)
    {
        if (addCursoRequest == null) {
            return BadRequest();
        }

        Curso curso = new() { Nome = addCursoRequest.Nome };
        _repository.AddCurso(curso);

        return Ok();
    }

    [HttpPost("/inscricao")]
    public IActionResult AddInscricao([FromBody]AddInscricaoRequest addInscricaoRequest)
    {
        if (addInscricaoRequest == null) {
            return BadRequest();
        }

        Inscricao inscricao = new() { CandidatoId = addInscricaoRequest.CandidatoId, CursoId = addInscricaoRequest.CursoId };
        _repository.AddInscricao(inscricao);

        return Ok();      
    }

  }
}