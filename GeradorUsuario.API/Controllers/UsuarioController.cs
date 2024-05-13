using GeradorUsuario.Application.Interfaces;
using GeradorUsuario.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GeradorUsuario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(IUsuarioService usuarioService) : ControllerBase
    {
        private readonly IUsuarioService _usuarioService = usuarioService;

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioOutputDto>> Get(Guid id)
        {
            UsuarioOutputDto? usuarioDto = await _usuarioService.GetById(id);

            if (usuarioDto == null)
            {
                return NotFound();
            }

            return Ok(usuarioDto);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<UsuarioOutputDto>>> GetAll()
        {
            IEnumerable<UsuarioOutputDto>? itemList = await _usuarioService.GetAll();

            return Ok(itemList);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioOutputDto>> Add([FromForm] UsuarioInputDto usuarioDto)
        {
            UsuarioOutputDto newItem = await _usuarioService.Add(usuarioDto);

            return CreatedAtAction(nameof(Get), new { id = newItem.Uuid }, newItem);
        }
        
        [HttpPost]
        [Route("AddUsuarioAleatorio")]
        public async Task<ActionResult<UsuarioOutputDto>> AddUsuarioAleatorio()
        {
            UsuarioOutputDto newItem = await _usuarioService.AddUsuarioAleatorio();

            return CreatedAtAction(nameof(Get), new { id = newItem.Uuid }, newItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid uuid, [FromForm] UsuarioInputDto usuarioDto)
        {
            UsuarioOutputDto? item = await _usuarioService.Update(uuid, usuarioDto);

            if (item == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool success = await _usuarioService.Delete(id);

            if (success)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
