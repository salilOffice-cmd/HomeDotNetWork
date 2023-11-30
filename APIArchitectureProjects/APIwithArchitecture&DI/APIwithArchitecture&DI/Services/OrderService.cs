using APIwithArchitecture.Data_Access_Layer;
using APIwithArchitecture.DTOs;
using APIwithArchitecture.Models;
using APIwithArchitecture_DI.Data_Access_Layer;
using APIwithArchitecture_DI.Services;

namespace APIwithArchitecture.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRespository orderRespository;
        public OrderService(IOrderRespository _orderRespository)
        { 
            orderRespository = _orderRespository;
        }

        public void AddOrder_Service(AddOrderDTO addOrderDTO)
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

            orderRespository.AddOrder_Repo(newOrder);
        }
    }
}
