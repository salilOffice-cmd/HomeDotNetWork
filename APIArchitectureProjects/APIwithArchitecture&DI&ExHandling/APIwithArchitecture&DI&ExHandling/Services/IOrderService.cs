using APIwithArchitecture.DTOs;

namespace APIwithArchitecture_DI.Services
{
    public interface IOrderService
    {
        Task AddOrder_Service(AddOrderDTO dto);
    }
}
