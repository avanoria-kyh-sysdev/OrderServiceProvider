using Microsoft.EntityFrameworkCore;
using WebApi.Data.Contexts;
using WebApi.Data.Entities;

namespace WebApi.Services;

public class OrderService(DataContext context) : IOrderService
{
    private readonly DataContext _context = context;

    public async Task<bool> CreateOrderAsync(OrderEntity orderEntity)
    {
        orderEntity.OrderDate = DateTime.Now;
        orderEntity.DueDate = DateTime.Now.AddDays(30);

        // Customer Information




        await _context.Orders.AddAsync(orderEntity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<List<OrderEntity>> GetOrdersAsync()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<OrderEntity?> GetOrderByIdAsync(int id)
    {
        return await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
    }
}
