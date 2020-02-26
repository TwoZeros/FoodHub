using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WorkerCRM.Models; 
using WorkerCRM.Data;
using WorkerCRM.Services;
using WorkerCRM.Common;
namespace todo.Controllers
{
    public class AccountController : Controller
    {
        // тестовые данные вместо использования базы данных
        private readonly PlanersDbContext  _context;

        public AccountController(PlanersDbContext context)
        {
            _context = context;
        }

      
        [HttpPost("/token")]
        public IActionResult Token(string username, string password)
        {
            var auth = new Authorization(_context);

            auth.GetIdentity(username, password);
          
            if (auth.isCorrectUser())
            {
                var responce = auth.getToken();
                return Json(responce);
            }
            else
            {
                return BadRequest(new { errorText = "Invalid username or password." });
                
            }

            
        }

       
    }
}