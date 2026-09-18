using LibraryWebApi.LibraryBusiness.DTOs.Order;
using LibraryWebApi.LibraryBusiness.Services;
using LibraryWebApi.LibraryData.Repository.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraryWebApi.LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderRepository OrderRepository { get; }
        OrderItemRepository OrderItemRepository { get; }
        public OrderController(OrderRepository orderRepository,OrderItemRepository orderItemRepository)
        {
            OrderRepository = orderRepository;
            OrderItemRepository = orderItemRepository;
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders =  OrderServices.OrdersToGetDTO(OrderRepository.GetAllAsync().Result);
            return Ok(orders);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderByID(int id)
        {
            var order = OrderServices.OrderToGetDTO(OrderRepository.GetByIdAsync(id).Result);
            return Ok(order);

        }
        [HttpGet("{id}/Items")]
        public async Task<IActionResult> GetItemsInCategory(int id)
        {
            var items = await OrderItemRepository.GetItemsInOrderAsync(id);
            if (items == null) return NotFound();
            return Ok(items);
        }
        [HttpPost("Create")]
        [Authorize]
        public async Task<IActionResult> AddOrder(OrderCreateDTO order)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var _order=OrderServices.CreateDtoToOrder(order,userId);
            await OrderRepository.AddAsync(_order);
            await OrderRepository.SaveAsync();
            return CreatedAtAction("GetOrderByID", new { ID = _order.ID }, order);

        }
        [HttpPut("Update/{id}")]
        [Authorize]
        public async Task<IActionResult> EditOrder(int id, OrderDTO order)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var _order = OrderServices.DtoToOrder(order,userId);
            await OrderRepository.Update(id, _order);
            await OrderRepository.SaveAsync();
            return NoContent();

        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await OrderRepository.DeleteAsync(id);
            await OrderRepository.SaveAsync();
            return NoContent();

        }
    }
}
