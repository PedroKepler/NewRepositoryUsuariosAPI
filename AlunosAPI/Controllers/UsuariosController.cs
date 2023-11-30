using Usuarios.Models;
using Usuarios.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Usuarios.Services;

namespace Usuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            try
            {
                var usuarios = await _usuarioService.GetUsuario();
                return Ok(usuarios);
            }
            catch
            {
                return BadRequest("Request inválido");
                //return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter usuários");
            }
        }

        [HttpGet("UsuarioPorNome")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarioPorNome([FromQuery] string nome)
        {
            var usuarios = await _usuarioService.GetUsuariosByNome(nome);

            if (usuarios == null)
                return NotFound($"Não existem usuários com nome = {nome}");

            return Ok(usuarios);
        }

        [HttpGet("{id:int}", Name = "GetUsuario")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            try
            {
                var usuario = await _usuarioService.GetUsuario(id);

                if (usuario == null)
                    return NotFound($"Usuário com id= {id} não encontrado");

                return Ok(usuario);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(Usuario usuario)
        {
            try
            {
                await _usuarioService.CreateUsuario(usuario);
                return CreatedAtRoute(nameof(GetUsuario), new { id = usuario.Id }, usuario);
            }
            catch
            {
                //return BadRequest("Request inválido");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar um novo usuário");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Usuario usuario)
        {
            try
            {
                if (usuario.Id == id)
                {
                    await _usuarioService.UpdateUsuario(usuario);
                    //return NoContent();
                    return Ok($"Usuário com id={id} atualizado com sucesso");
                }
                else
                {
                    return BadRequest("Dados inconsistentes");
                }
            }
            catch (Exception)
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var usuario = await _usuarioService.GetUsuario(id);
                if (usuario != null)
                {
                    await _usuarioService.DeleteUsuario(usuario);
                    return Ok($"Usuário de id={id} excluído com sucesso");
                    //return Ok(id);
                }
                else
                {
                    return NotFound($"Usuário com id= {id} não encontrado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
