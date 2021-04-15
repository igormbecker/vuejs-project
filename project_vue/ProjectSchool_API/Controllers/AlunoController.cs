using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ProjectSchool_API.Data;
using ProjectSchool_API.Models;
using System.Threading.Tasks;

namespace ProjectSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Ao adicinar ApiController, ele já entende que estamos trabalhando com métodos http e não precisa mais adicionar por ex [FromBody] nas requisições
    public class AlunoController : Controller
    {
        public IRepository _repo { get; }

        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> get()
        {
            try
            {
                var result = await _repo.GetAllAlunosAsync(true);
                
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpGet("{AlunoId}")]
        public async Task<IActionResult> getByAlunoId(int AlunoId)
        {
            try
            {
                var result = await _repo.GetAlunoAsyncById(AlunoId, true);
                
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpGet("ByProfessor/{ProfessorId}")]
        public async Task<IActionResult> getAlunoByProfessorId(int ProfessorId)
        {
            try
            {
                var result = await _repo.GetAlunosAsyncByProfessorId(ProfessorId, true);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }        

        [HttpPost]
        public async Task<IActionResult> post(Aluno model)
        {
            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Created($"/api/aluno/{model.Id}", model);
                }
                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }

        [HttpPut("{AlunoId}")]
        public async Task<IActionResult> put(int AlunoId, Aluno model)
        {
            try
            {
                var aluno = await _repo.GetAlunoAsyncById(AlunoId, false);
                if(aluno == null) return NotFound();

                _repo.Update(model);

                if(await _repo.SaveChangesAsync())
                {
                    aluno = await _repo.GetAlunoAsyncById(AlunoId, true);
                    return Created($"/api/aluno/{model.Id}", aluno);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }

        [HttpDelete("{AlunoId}")]
        public async Task<IActionResult> delete(int AlunoId)
        {
            try
            {
                var aluno = await _repo.GetAlunoAsyncById(AlunoId, false);
                if(aluno == null) return NotFound();

                _repo.Delete(aluno);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }


    }
}