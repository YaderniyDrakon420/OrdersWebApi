using Microsoft.AspNetCore.Mvc;
using Orders.Models;
using static System.Reflection.Metadata.BlobBuilder;
namespace Orders.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private static readonly List<Order> Orders = new List<Order>
    {
        new Order(1, "ORD-001", 150.50m, DateTime.Now.AddDays(-5)),
        new Order(2, "ORD-002", 320.00m, DateTime.Now.AddDays(-3)),
        new Order(3, "ORD-003", 75.25m, DateTime.Now.AddDays(-1))
    };

    [HttpGet]
    public IActionResult GetOrders()
    {
        return Ok(Orders);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetOrderById(int id)
    {
        var order = Orders.FirstOrDefault(o => o.Id == id);

        if (order == null)
            return NotFound("Order not found");

        return Ok(order);
    }

    [HttpPost]
    public IActionResult CreateOrder([FromBody] OrderCreateDto orderDto)
    {
        if (string.IsNullOrWhiteSpace(orderDto.Number))
            return BadRequest("Number is required");

        if (orderDto.Total <= 0)
            return BadRequest("Total must be greater than 0");

        int newId = Orders.Max(o => o.Id) + 1;
        var order = new Order(newId, orderDto.Number, orderDto.Total, DateTime.Now);

        Orders.Add(order);

        return CreatedAtAction(
            nameof(GetOrderById),
            new { id = order.Id },
            order
        );
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateOrder(int id, [FromBody] OrderCreateDto dto)
    {
        var order = Orders.FirstOrDefault(o => o.Id == id);
        if (order == null)
            return NotFound("Order not found");

        if(string.IsNullOrWhiteSpace(dto.Number))
            return BadRequest("Number is required");

        if (dto.Total <= 0)
            return BadRequest("Total must be greater than 0");

        order.Number = dto.Number;
        order.Total = dto.Total;
        
        return Ok(order);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteOrder(int id)
    {
        var order = Orders.FirstOrDefault(o => o.Id == id);
        if (order == null)
            return NotFound("Order not found");

        Orders.Remove(order);
        return NoContent();
    }

    [HttpGet("search")]
    public IActionResult SearchOrders([FromQuery] string number, [FromQuery] decimal? minTotal)
    {
        if (string.IsNullOrWhiteSpace(number))
            return BadRequest("Number is required");

        var results = Orders
        .Where(o => o.Number.Contains(number, StringComparison.OrdinalIgnoreCase));

        if (minTotal.HasValue)
        {
            results = results.Where(o => o.Total >= minTotal.Value);
        }

        return Ok(results.ToList());
    }
}