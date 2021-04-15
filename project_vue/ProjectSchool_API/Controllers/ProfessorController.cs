using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ProjectSchool_API.Data;
using ProjectSchool_API.Models;
using System.Threading.Tasks;

namespace ProjectSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : Controller
    {
        public IRepository _repo { get; }
        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> get()
        {
            try
            {
                var result = await _repo.GetAllProfessorAsync(true);
                
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpGet("{ProfessorId}")]
        public async Task<IActionResult> getByProfessorId(int ProfessorId)
        {
            try
            {
                var result = await _repo.GetProfessorAsyncById(ProfessorId, true);
                
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Professor model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/professor/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }

        [HttpPut("{ProfessorId}")]
        public async Task<IActionResult> put(int ProfessorId, Professor model)
        {
            try
            {
                var professor = await _repo.GetProfessorAsyncById(ProfessorId, false);
                if(professor == null) return NotFound();

                _repo.Update(model);

                if(await _repo.SaveChangesAsync())
                {
                    professor = await _repo.GetProfessorAsyncById(ProfessorId, true);
                    return Created($"/api/professor/{model.Id}", professor);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }

        [HttpDelete("{ProfessorId}")]
        public async Task<IActionResult> delete(int ProfessorId)
        {
            try
            {
                var professor = await _repo.GetProfessorAsyncById(ProfessorId, false);
                if(professor == null) return NotFound();

                _repo.Delete(professor);

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