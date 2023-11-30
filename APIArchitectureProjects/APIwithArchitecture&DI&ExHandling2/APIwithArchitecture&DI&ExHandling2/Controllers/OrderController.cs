using APIwithArchitecture.DTOs;
using APIwithArchitecture.Services;
using APIwithArchitecture_DI.Services;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;
using System.Reflection.Metadata;
using System.Threading;

namespace APIwithArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService _orderService)
        {
            orderService = _orderService;
        }


        // Async Await
        // In the controller layer, we use async/await to handle
        // incoming HTTP requests and return responses asynchronously.
        // This allows us to handle multiple requests concurrently without
        // blocking the thread pool.


        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddOrder([FromBody] AddOrderDTO addOrderDTO)
        {
            try
            {
                await orderService.AddOrder_Service(addOrderDTO);
                return Ok("Order has been added");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        // This code will start the AddOrder_Service method asynchronously
        // and then return to the caller.
        // The caller will not be blocked while the AddOrder_Service method is running.
        // When the AddOrder_Service method completes,
        // the controller will resume execution and return the response to the client.
    }
}
