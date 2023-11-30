using APIwithArchitecture.Contexts;
using APIwithArchitecture.Models;

// The Repository layer is responsible for interacting with the database.
// It should be responsible for performing CRUD operations on data.
namespace APIwithArchitecture.Data_Access_Layer
{
    public class OrderRespository
    {
        public void AddOrderRepo(Order order)
        {
            using(OrdersDBContext context =  new OrdersDBContext())
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }
    }
}
