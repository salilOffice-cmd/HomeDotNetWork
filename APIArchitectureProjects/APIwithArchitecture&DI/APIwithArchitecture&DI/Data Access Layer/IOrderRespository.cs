using APIwithArchitecture.Models;

namespace APIwithArchitecture_DI.Data_Access_Layer
{
    public interface IOrderRespository
    {
        void AddOrder_Repo(Order order);
    }
}
