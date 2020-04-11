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
using WorkerCRM.Services.Contract;
using WorkerCRM.Services.Contract.Dto;

namespace todo.Controllers
{
    public class AccountController : Controller
    {
        
        private readonly IAuthorizationService _authorization;
        public AccountController( IAuthorizationService auth)
        {
            _authorization = auth;
        }

      
        [HttpPost("/token")]
        public IActionResult Token(string username, string password)
        {
            var token =_authorization.GetToken(username, password);
           
            if (token == null)
                return BadRequest(new { errorText = "Invalid username or password." });
           
            return Json(token);
                 
        }

       
    }
}