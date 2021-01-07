using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ISI_Tp2.Models;
using ISI_Tp2.Repositories;
using ISI_Tp2.Services;
using Microsoft.AspNetCore.Authorization;

namespace ISI_Tp2.Controllers
{
    [Route("api/auth")]
    public class HomeController : ControllerBase
    {
        public HomeController(IUserRepository repository)
        {
            _repo = repository;
        }

        private readonly IUserRepository _repo;

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
         

            
            var user = _repo.GetUser(model.Email) ;

            // Verifica se o usuário existe
            if (user.Email == null)
                return NotFound(new { message = "Email ou password invalida" });

            /* Fetch the stored value */
            string savedPasswordHash = user.Password;
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(model.Password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    return NotFound(new { message = "Email ou password invalida" });

          

            // Gera o Token
            var token = TokenService.GenerateToken(user);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }


        [HttpPost]
        [Route("register")]
        public List<User> InsertUser([FromBody] User model)
        {

            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(model.Password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            List<User> user = _repo.InsertUser(model.Name,savedPasswordHash,model.Email);
            return user;
            }


    }
}
