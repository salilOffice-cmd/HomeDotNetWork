using Azure.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics.Metrics;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using WebEFAPI_2.MyLogging;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebEFAPI_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        // 1. Strongly Coupled / tightly coupled (not recommended)
        //private readonly IMyLogger _myLogger;

        //public ClientController()
        //{
        //    _myLogger = new LogToDB();


        //    // If i want to change LogToDb to LogToFile
        //    // I have to modify it like this everytime and in every controller
        //    // _myLogger = new LogToFile();
        //}




        // 2. Loosely Coupled (Dependency Injection)
        private readonly IMyLogger _myLogger;

        public ClientController(IMyLogger myLogger)
        {
            _myLogger = myLogger;
        }


        





        // For testing the logging classes
        [HttpGet]
        public ActionResult Index()
        {
            _myLogger.Log("Index method started!");
            return Ok();
        }
    }
}
