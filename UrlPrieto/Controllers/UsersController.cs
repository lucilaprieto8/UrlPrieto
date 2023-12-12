using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UrlPrieto.Data;
using UrlPrieto.Entities;
using UrlPrieto.Models;
using UrlPrieto.Services;

namespace UrlPrieto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UsersServices _usersServices;
        private readonly UrlContext _urlContext;

        public UserController(UsersServices usersServices, UrlContext urlContext)
        {
            _usersServices = usersServices;
            _urlContext = urlContext;
        }

        [HttpPost]
        public IActionResult UserCreate([FromBody] UserForCreationDto UserForCreate)
        {
            try
            {
                _usersServices.CreateUser(UserForCreate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Created("Created", UserForCreate);
        }

        [HttpGet]
        public IActionResult GetUrlsByUser()
        {
            int userId = int.Parse(User.Claims.First(x => x.Type == "id").Value);
            var urls = _urlContext.Url.Where(u => u.IdUser == userId).ToList();
            return Ok(urls);
        }

        [HttpGet("Restantes")]

        public IActionResult GetRestantes()
        {
            int userId = int.Parse(User.Claims.First(x => x.Type == "id").Value);
            var restanT = _urlContext.Users.FirstOrDefault(u => u.Id == userId);
            if (restanT == null)
            {
                return NotFound();
            }
            return Ok(restanT.Restantes);
        }

        [HttpPut]

        public IActionResult UpdateRestantes()
        {
            int userId = int.Parse(User.Claims.First(x => x.Type == "id").Value);
            var restanT = _urlContext.Users.FirstOrDefault(u => u.Id == userId);
            restanT.Restantes = 10;
            _urlContext.Update(restanT);
            _urlContext.SaveChanges();
            return Ok();
        }


        [HttpDelete]

        public IActionResult DeleteUser(int id)
        {
            var userId = _urlContext.Users.Single(x => x.Id == id);
            if (userId == null)
            {
                return NotFound();
            }
            _urlContext.Users.Remove(userId);
            _urlContext.SaveChanges();
            return Ok();
        }

    }   
}