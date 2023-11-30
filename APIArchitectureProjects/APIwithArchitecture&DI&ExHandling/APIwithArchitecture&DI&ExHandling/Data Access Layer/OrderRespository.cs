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

        // Async await
        // In the repository layer, we use async/await to interact
        // with the database asynchronously.
        // This allows us to perform multiple database operations concurrently
        // without blocking the thread pool.

        public async Task AddOrder_Repo(Order order)
        {
            try
            {
                throw new Exception("Order not added due to database error");
                await context.Orders.AddAsync(order);
                await context.SaveChangesAsync();

            }

            catch(Exception ex)
            {
                // Log the error.
                // Identify the cause of the error.
                // Take corrective action.
                // Throw a meaningful exception to the Service layer.
                throw ex;

            }
        }

        // This code will start the AddAsync and SaveChangesAsync methods
        // asynchronously and then return to the caller.
        // The caller will not be blocked while the AddAsync and SaveChangesAsync
        // methods are running. When the AddAsync and SaveChangesAsync methods complete,
        // the repository will resume execution.

    }
}
