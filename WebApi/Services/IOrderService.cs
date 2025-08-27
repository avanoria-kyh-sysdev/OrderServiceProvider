using WebApi.Data.Entities;

namespace WebApi.Services
{
    public interface IOrderService
    {
        Task<bool> CreateOrderAsync(OrderEntity orderEntity);
        Task<OrderEntity?> GetOrderByIdAsync(int id);
        Task<List<OrderEntity>> GetOrdersAsync();
    }
}