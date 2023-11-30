using APIwithArchitecture.DTOs;
using APIwithArchitecture.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// The Controller layer is responsible for handling incoming HTTP requests
// and returning responses.
// It should be responsible for validating input,
// routing requests to the appropriate Service layer, and handling errors.

namespace APIwithArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        [HttpPost]
        [Route("add")]
        public ActionResult AddOrder([FromBody] AddOrderDTO addOrderDTO)
        {
            OrderService orderService = new OrderService();
            orderService.AddOrderService(addOrderDTO);
            return Ok("Order has been added");
        }
    }
}
