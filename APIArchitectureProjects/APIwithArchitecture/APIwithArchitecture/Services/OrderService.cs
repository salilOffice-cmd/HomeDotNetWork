using APIwithArchitecture.Data_Access_Layer;
using APIwithArchitecture.DTOs;
using APIwithArchitecture.Models;

// Role Of Service Layer
// 1.Validate the addOrderDTO object

// 2.Create a new actual object from the DTO object

// 3.Save the object to the database using the Repository


namespace APIwithArchitecture.Services
{
    public class OrderService
    {
        public void AddOrderService(AddOrderDTO addOrderDTO)
        {
            Order newOrder = new Order
            {
                Customer_name = addOrderDTO.Customer_name,
                Amount = addOrderDTO.Amount,
                DeliveryLocation = addOrderDTO.DeliveryLocation,
                OrderStatus = "Initiated",
                Order_date = DateTime.Now,
                EstimatedDeliveryDate = DateTime.Now.AddDays(5)
            };

            OrderRespository orderRespository = new OrderRespository();
            orderRespository.AddOrderRepo(newOrder);
        }
    }
}
