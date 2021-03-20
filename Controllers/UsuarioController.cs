using Curso.API.Business.Entities;
using Curso.API.Business.Repositories;
using Curso.API.Config;
using Curso.API.Filters;
using Curso.API.Models.Usuários;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.Annotations;

namespace Curso.API.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthenticationService _authenticationService;

        public UsuarioController(IUsuarioRepository usuarioRepository, 
                                 IConfiguration configuration,
                                 IAuthenticationService authentication)
        {
            _usuarioRepository = usuarioRepository;
            _authenticationService = authentication;
        }

        /// <summary>
        /// Este serviço permite autenticar um usuário cadastrado e ativo.
        /// </summary>
        /// <param name="loginViewModelInput"></param>
        /// <returns>retorna status ok, dados de usuário e o token em caso de sucesso.</returns>

        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("Login")]
        [ValidacaoModelStateCustom]
        public IActionResult Login(LoginViewModelInput loginViewModelInput)
        {
            Usuario usuario = _usuarioRepository.ObterUsuario(loginViewModelInput.Login);

            if(usuario == null)
            {
                return BadRequest("Houve um erro ao tentar acessar.");
            }

            //  if (usuario.Senha != loginViewModelInput.Senha.GerarSenhaEncriptografada())
            //{
            //   return BadRequest("Houve um erro ao tentar acessar.");
            // }

            var usuarioViewModelOutput = new UsuarioViewModelOutput()
            {
                Codigo = usuario.Codigo,
                Login = loginViewModelInput.Login,
                Email = usuario.Email
            };

            var token = _authenticationService.GerarToken(usuarioViewModelOutput);

            return Ok(new
           {
               Token = token,
               Usuario = usuarioViewModelOutput
           });

        }
        /// <summary>
        /// Este serviço permite cadastrar um usuário cadastrado não existente
        /// </summary>
        /// <param name="registroViewModelInput">View Model do registo de login</param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("Registrar")]
        [ValidacaoModelStateCustom]
        public IActionResult Registrar(RegistroViewModelInput registroViewModelInput)
        {
          

            //var migracoesPendentes = contexto.Database.GetPendingMigrations();
          
           // if (migracoesPendentes.Count() > 0)
           // {
           //     contexto.Database.Migrate();
           // }
            var usuario = new Usuario();
            usuario.Login = registroViewModelInput.Login;
            usuario.Senha = registroViewModelInput.Senha;
            usuario.Email = registroViewModelInput.Email;

            _usuarioRepository.Adicionar(usuario);
            _usuarioRepository.Commit();

            return Created("", registroViewModelInput);

        }
            
    }
}
