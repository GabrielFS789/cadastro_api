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
        private readonly IEntidadeRepository _entidadeRepo;

        public EntidadeController(IMapper mapper, IEntidadeRepository entidadeRepo)
        {
            _mapper = mapper;
            _entidadeRepo = entidadeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntidadeDTO>>> Get()
        {
            var entidades = await _entidadeRepo.GetAll();
            var entidadesDTO = _mapper.Map<IEnumerable<EntidadeDTO>>(entidades);
            return Ok(entidadesDTO);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EntidadeDTO>> GetById(int id)
        {
            var entidade = await _entidadeRepo.GetById(id);
            if (entidade is null)
                return NotFound("Entidade não encontrada");
            return Ok(entidade);
        }

        [HttpPost]
        public async Task<ActionResult<EntidadeDTO>> Create(EntidadeDTO entidadeDTO)
        {
            var entidade = _mapper.Map<Entidade>(entidadeDTO);
            var newEntidadeDTO = await _entidadeRepo.Create(entidade);

            return Ok(newEntidadeDTO);
        }

        //[HttpPut("{id:int}")]
        //public async Task<ActionResult<EntidadeDTO>> Update(int id, Entidade entidade)
        //{
        //    if (id != entidade.Id || entidade is null)
        //        return BadRequest("Id informado no Header Difere do ID informado na entidade");
        //    var newEntidade = await _entidadeRepo.Update(entidade);
        //    var entidadeDTO = _mapper.Map<EntidadeDTO>(newEntidade);
        //    return Ok(entidadeDTO);

        //}

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<EntidadeDTO>> Patch(int id, JObject value)
        {
            var entidade = await _entidadeRepo.GetById(id);
            if (entidade is null)
                return NotFound();
            var dataHoraCadastro = entidade.DataHoraCadastro;

            foreach(var property in value.Properties())
            {
                var patchDoc = new JsonPatchDocument();
                patchDoc.Replace($"/{property.Name}", property.Value);

                patchDoc.ApplyTo(entidade);
            }
            entidade.DataHoraCadastro = dataHoraCadastro;
            var entidadeEditada = await _entidadeRepo.Update(entidade);
            var entidadeDTO = _mapper.Map<EntidadeDTO>(entidadeEditada);
            return Ok(entidade);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EntidadeDTO>> Delete(int id)
        {
            var entidadeDeletada = await _entidadeRepo.GetById(id);
            if (entidadeDeletada is null)
                return NotFound();
            await _entidadeRepo.Delete(id);
            return Ok(entidadeDeletada);
        }
    }
}
