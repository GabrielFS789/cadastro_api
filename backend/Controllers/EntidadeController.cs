using AutoMapper;
using backend.DataContext;
using backend.DTOs;
using backend.Model;
using backend.Repositories.InterfaceRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntidadeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkRepository _unitOfWork;

        public EntidadeController(IMapper mapper, IUnitOfWorkRepository unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntidadeDTO>>> GetAllAsync()
        {
            var entidades = await _unitOfWork.EntidadeRepository.GetAllAsync();
            var entidadesDTO = _mapper.Map<IEnumerable<EntidadeDTO>>(entidades);
            return Ok(entidadesDTO);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EntidadeDTO>> GetByIdAsync(int id)
        {
            var entidade = await _unitOfWork.EntidadeRepository.GetByIdAsync(id);
            if (entidade is null)
                return NotFound("Entidade não encontrada");
            return Ok(entidade);
        }

        [HttpPost]
        public async Task<ActionResult<EntidadeDTO>> CreateAsync(EntidadeDTO entidadeDTO)
        {
            try
            {
                var entidade = _mapper.Map<Entidade>(entidadeDTO);
                var newEntidadeDTO = await _unitOfWork.EntidadeRepository.CreateAsync(entidade);
                await _unitOfWork.CommitAsync();
                return Ok(newEntidadeDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<EntidadeDTO>> Update(int id, Entidade entidade)
        {
            if (id != entidade.Id || entidade is null)
                return BadRequest("Id informado no Header Difere do ID informado na entidade");
            var newEntidade = _unitOfWork.EntidadeRepository.Update(entidade);
            var entidadeDTO = _mapper.Map<EntidadeDTO>(newEntidade);
            await _unitOfWork.CommitAsync();
            return Ok(entidadeDTO);
        }

        [HttpPatch("{codigo:int}")]
        public async Task<ActionResult<EntidadeDTO>> Patch(int codigo, JObject value)
        {
            try
            {
                var entidade = await _unitOfWork.EntidadeRepository.GetByCodigoAsync(codigo);
                if (entidade is null)
                    return NotFound();
                var dataHoraCadastro = entidade.DataHoraCadastro;

                foreach (var property in value.Properties())
                {
                    var patchDoc = new JsonPatchDocument();
                    patchDoc.Replace($"/{property.Name}", property.Value);

                    patchDoc.ApplyTo(entidade);
                }
                var entidadeEditada = _unitOfWork.EntidadeRepository.Update(entidade);
                await _unitOfWork.CommitAsync();
                var entidadeDTO = _mapper.Map<EntidadeDTO>(entidadeEditada);
                return Ok(entidadeDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EntidadeDTO>> Delete(int id)
        {
            var entidadeDeletada = await _unitOfWork.EntidadeRepository.GetByIdAsync(id);
            if (entidadeDeletada is null)
                return NotFound();
            await _unitOfWork.EntidadeRepository.DeleteAsync(id);
            return Ok(entidadeDeletada);
        }
    }
}
