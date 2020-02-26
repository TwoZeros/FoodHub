using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WorkerCRM.Infrastructure.Mappers.Interfaces;
using WorkerCRM.Models;
using WorkerCRM.Services.Contract;
using Serilog;

namespace WorkerCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderMapper _mapper;
        private readonly ILoggerService _logService;
        public OrderController(IOrderMapper mapper,  ILoggerService logService)
        {
            _mapper = mapper;
            _logService = logService;
        }

        [HttpGet]
        public ActionResult Post()
        {
            _logService.LogAboutSuccess("Получил пост");
            return Ok("");
            //var dto = _mapper.MapFromModel(order);
            //string currentDatetime = DateTime.Now.ToString();
            //string successMessage = "{0} - Success. Name:{1} | Phone {2}";
            //string errorMessage = "ERROR: {0} {1} - Name:{2} | Phone {3}";

            //using (var customLogger = new LoggerConfiguration().WriteTo.File(@"..\MyLogs\log.txt").CreateLogger())
            //{
            //    try
            //    {
            //        _emailService.Send(dto);
            //        _logService.LogOrderSuccess(order.Name, order.Phone);
            //        //customLogger.Information(string.Format(successMessage, currentDatetime, dto.Name, dto.Phone));
            //    } catch (Exception e)
            //    {
            //        _logService.LogOrderError(e, order.Name, order.Phone);
            //        //customLogger.Error(string.Format(errorMessage, e.Message, currentDatetime, dto.Name, dto.Phone));
            //    }
            //}

            ////TODO: Create Email Service and send a email

            ////TODO: Log this action

            //return new JsonResult(new { order.Name, order.Phone });
        }
    }
}