using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController(IOrderService orderService) : ControllerBase
{
    private readonly IOrderService _orderService = orderService;

    [HttpPost] 
    public async Task<IActionResult> Create(OrderRequest orderRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _orderService.CreateOrderAsync(new()
        {
            CustomerId = orderRequest.CustomerId
        });

        if (!result)
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create order.");
        
        return Ok("Order created successfully.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        if (order == null)
            return NotFound("Order not found.");
        
        return Ok(order);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _orderService.GetOrdersAsync();
        return Ok(orders);
    }
}
