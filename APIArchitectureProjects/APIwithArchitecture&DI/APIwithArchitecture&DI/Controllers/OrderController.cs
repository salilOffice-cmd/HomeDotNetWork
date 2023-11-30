using APIwithArchitecture.DTOs;
using APIwithArchitecture.Services;
using APIwithArchitecture_DI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        [Route("add")]
        /// <summary>
        /// This endpoint gives the orders placed by a customer
        /// </summary>
        /// <param name="customerId">CustomerId</param>
        /// <returns></returns>
        public ActionResult AddOrder([FromBody] AddOrderDTO addOrderDTO)
        {
            orderService.AddOrder_Service(addOrderDTO);
            return Ok("Order has been added");
        }
    }
}
