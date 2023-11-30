using APIwithArchitecture.Models;

namespace APIwithArchitecture_DI.Data_Access_Layer
{
    public interface IOrderRespository
    {
        Task AddOrder_Repo(Order order);
    }
}
