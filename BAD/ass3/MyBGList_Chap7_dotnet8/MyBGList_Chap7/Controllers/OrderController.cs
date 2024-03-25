using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBGList.DTO;
using MyBGList.Models;
using MyBGList_Chap6.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBGList.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}", Name = "GetOrder")]
        public async Task<ActionResult<OrderDTO>> GetOrder(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Packets)
                .Include(o => o.OrderBakingGoods)
                .ThenInclude(oc => oc.BakingGood)
                .FirstOrDefaultAsync(o => o.OrderId == id);

            if (order == null)
            {
                return NotFound();
            }

            var orderDto = new OrderDTO
            {
                OrderId = order.OrderId,
                DeliveryPlace = order.DeliveryPlace,
                DeliveryDate = order.DeliveryDate,
                Packets = order.Packets.Select(p => new PacketDTO
                {
                    PacketId = p.PacketId,
                    TrackId = p.TrackId
                }).ToList(),
                OrderBakingGood = order.OrderBakingGoods.Select(oc => new OrderBakingGoodDTO
                {
                    BakingGoodId = oc.BakingGoodId,
                    Quantity = oc.Quantity,
                    BakingGood = new BakingGoodDTO
                    {
                        BakingGoodId = oc.BakingGood.BakingGoodId,
                        BgName = oc.BakingGood.BgName,
                        DateProduced = oc.BakingGood.DateProduced
                    }
                }).ToList()
            };

            return Ok(orderDto);
        }

        [HttpPost(Name = "CreateOrder")]
        public async Task<ActionResult<OrderDTO>> CreateOrder(OrderDTO orderDto)
        {
            var order = new Order
            {
                DeliveryPlace = orderDto.DeliveryPlace,
                DeliveryDate = orderDto.DeliveryDate,
                Packets = orderDto.Packets.Select(p => new Packet
                {
                    TrackId = p.TrackId
                }).ToList(),
                OrderBakingGoods = orderDto.OrderBakingGood.Select(oc => new OrderBakingGood
                {
                    BakingGoodId = oc.BakingGoodId,
                    Quantity = oc.Quantity
                }).ToList()
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, orderDto);
        }

        [HttpDelete("{id}", Name = "DeleteOrder")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
