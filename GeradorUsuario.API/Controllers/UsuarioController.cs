using GeradorUsuario.Application.Dtos;
using GeradorUsuario.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeradorUsuario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(IUsuarioService usuarioService) : ControllerBase
    {
        private readonly IUsuarioService _usuarioService = usuarioService;

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> Get(Guid id)
        {
            UsuarioDto? usuarioDto = await _usuarioService.GetById(id);

            if (usuarioDto == null)
            {
                return NotFound();
            }

            return Ok(usuarioDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetAll()
        {
            IEnumerable<UsuarioDto>? itemList = await _usuarioService.GetAll();

            return Ok(itemList);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> Add(UsuarioDto usuarioDto)
        {
            UsuarioDto newItem = await _usuarioService.Add(usuarioDto);

            return CreatedAtAction(nameof(Get), new { id = newItem.Uuid }, newItem);
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, UsuarioDto usuarioDto)
        //{
        //    if (id != usuarioDto.Id)
        //    {
        //        return BadRequest();
        //    }

        //    //UsuarioDto? newItem = await _usuarioService.Update(id, usuarioDto);

        //    if (newItem == null)
        //    {
        //        return NotFound();
        //    }

        //    return NoContent();
        //}

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
