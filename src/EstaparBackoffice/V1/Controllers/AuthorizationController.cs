using EstaparBackoffice.Controllers;
using EstaparBackoffice.DTO.Authorization;
using EstaparBackoffice.Extensions;
using EstaparGarage.business.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace EstaparBackoffice.V1.Controllers
{
    [Route("Api/")]
    public class AuthorizationController : MainController
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;


        public AuthorizationController(INotificador notificador,
                                       SignInManager<IdentityUser> signInManager,
                                       UserManager<IdentityUser> userManager,
                                       IOptions<AppSettings> appSettings) : base(notificador)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }




        [HttpPost("nova-conta")]
        public async Task<ActionResult> Registrar(RegisterUserViewModel registerUser)
        {
            if(!ModelState.IsValid) return CustomResponse(ModelState);

            var User = new IdentityUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(User,registerUser.Password);
            if(result.Succeeded)
            {
               await _signInManager.SignInAsync(User, false);

                return CustomResponse(registerUser);
            }

            foreach(var erro in result.Errors)
            {
                NotificarErro(erro.Description);
            }

            return CustomResponse(registerUser);
        }


        [HttpPost("entrar")]
        public async Task<ActionResult> Login(LoginUserViewModel loginUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                return CustomResponse(GerarJwt());
            }
            if (result.IsLockedOut)
            {
                NotificarErro("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponse(loginUser);
            }

            NotificarErro("Usuário ou Senha incorretos");
            return CustomResponse(loginUser);
        }

        //Implementar Clains(item 14 da cartilha)
        private string GerarJwt()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            #region key
            #endregion
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encondedToken = tokenHandler.WriteToken(token);

            return encondedToken;
        }
    }
}
