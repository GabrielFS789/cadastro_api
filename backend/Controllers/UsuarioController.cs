using backend.Model;
using backend.Repositories.InterfaceRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUnitOfWorkRepository _unitOfWork;

        public UsuarioController(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAllAsync()
        {
            try
            {
                var usuarios = await _unitOfWork.UsuarioRepository.GetAllAsync();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> GetByIdAsync(int id)
        {
            try
            {
                var usuario = await _unitOfWork.UsuarioRepository.GetByIdAsync(id);
                if (usuario is null)
                    return NotFound("Usuario não localizado");
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> UpdateAsync(Usuario usuario)
        {
            await _unitOfWork.UsuarioRepository.UpdateAsync(usuario);
            try
            {
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
