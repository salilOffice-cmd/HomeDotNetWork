using APIwithArchitecture.DTOs;

namespace APIwithArchitecture_DI.Services
{
    public interface IOrderService
    {
        void AddOrder_Service(AddOrderDTO dto);
    }
}
