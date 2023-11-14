using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using UrlPrieto.Controllers;
using UrlPrieto.Data;
using UrlPrieto.Entities;
using UrlPrieto.Migrations;
using UrlPrieto.Models;

namespace UrlPrieto.Services
{
    public class UsersServices
    {
        private readonly UrlContext _urlContext;

        public UsersServices(UrlContext urlContext)
        {
            _urlContext = urlContext;
        }
        public void CreateUser(UserForCreationDto UserForCreate)
        {
            Users user = new Users()
            {
                User = UserForCreate.User,
                Password = UserForCreate.Password,
            };
            _urlContext.Add(user);
            _urlContext.SaveChanges();
        }
    }
}
