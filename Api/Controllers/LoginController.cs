using TopDown_API.Models;
using TopDown_API.Repositories;
using TopDown_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace TopDown_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpGet]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate(string usuario, string senha)
        {

            var usarioLogado = UsuarioRepository.GetUsuario(usuario, senha);

            if (usarioLogado == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var tokenGerado = TokenService.GetToken(usarioLogado);

            // Oculta a senha para não retornar ao frontend
            usarioLogado.Senha = "";

            return new
            {
                user = usarioLogado,
                token = tokenGerado
            };
        }
    }
}
