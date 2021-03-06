﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CookItWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CookItWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _Context
            ;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration, 
            ApplicationDbContext context) {

            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _Context = context;
        }

        [Route("Create")] //Registro
        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] UserInfo Usuario)
        {

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = Usuario._Email, Email = Usuario._Email };
                var result = await _userManager.CreateAsync(user, Usuario._Password);
                if (result.Succeeded)
                {
                    _Context.Usuarios.Add(Usuario);
                    _Context.SaveChanges();
                    return BuildToken(Usuario);
                }
                else
                {
                    return BadRequest("Usuario o contrasña invalidos.");
                }
            }
            else
            {
                return BadRequest(ModelState);        
            }

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserInfo Usuario)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Usuario._Email, Usuario._Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return BuildToken(Usuario);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Intento de inicio de sesión no válido.");
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest(ModelState);        
            }
        }

        private IActionResult BuildToken(UserInfo Usuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, Usuario._Email),
                new Claim("miValor", "Lo que yo quiera"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMonths(1);

            JwtSecurityToken token = new JwtSecurityToken(            
                issuer: "yourdomain.com",
                audience: "yourdomain.com",
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expiration
            });

        }
    }
}