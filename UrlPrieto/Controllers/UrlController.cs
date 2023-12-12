using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.ComponentModel.DataAnnotations;
using UrlPrieto.Data;
using UrlPrieto.Entities;
using UrlPrieto.Models;

namespace UrlPrieto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly UrlContext _UrlContext;
        public UrlController(UrlContext UrlContext)
        {
            _UrlContext = UrlContext;
        }

        [HttpPost]
        [Authorize]
        public IActionResult saveUrlLarge([FromBody] UrlForCreationDTO UrlLarge)
        {
            int userId = int.Parse(User.Claims.First(x => x.Type == "id").Value);
            string UrlShort = Helpers.CustomUrlHelper.Shortener();
            var userinuse = _UrlContext.Users.FirstOrDefault(u => u.Id == userId);

            if (userinuse.Restantes < 1) {
                return BadRequest("El usuario no tiene mas restantes");
            }

            Url url = new Url()
            {
                largeUrl = UrlLarge.largeUrl,
                smallUrl = UrlShort,
                Cont = 0,
                IdCategory = UrlLarge.categoryId,
                IdUser = userId
            };

            userinuse.Restantes--;
            _UrlContext.Update(userinuse);

            _UrlContext.Add(url);
            _UrlContext.SaveChanges();

            return Ok(UrlShort);
        }

        [HttpGet("{UrlShort}")] 

        public IActionResult getUrlLarge(string UrlShort) {
           
            var hola = _UrlContext.Url.FirstOrDefault(u=> u.smallUrl == UrlShort);
            if (hola == null)
            {
                return NotFound();
            }
            hola.Cont++;

            _UrlContext.Update(hola);
            _UrlContext.SaveChanges();

            return Redirect(hola.largeUrl);
        }
     
    }
}
