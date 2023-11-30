using APIwithArchitecture.Contexts;
using APIwithArchitecture.Models;
using APIwithArchitecture_DI.Data_Access_Layer;

namespace APIwithArchitecture.Data_Access_Layer
{
    public class OrderRespository : IOrderRespository
    {
        private readonly OrdersDBContext context;
        public OrderRespository(OrdersDBContext ordersDBContext)
        {
            context = ordersDBContext;
        }

        public void AddOrder_Repo(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }
    }
}
