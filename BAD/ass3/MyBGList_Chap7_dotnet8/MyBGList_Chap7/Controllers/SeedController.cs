using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyBGList.Models;
using MyBGList_Chap6.Data;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyBGList.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<SeedController> _logger;

        public SeedController(
            ApplicationDbContext context,
            IWebHostEnvironment env,
            ILogger<SeedController> logger)
        {
            _context = context;
            _env = env;
            _logger = logger;
        }

        [HttpPost(Name = "Seed")]
        [ResponseCache(NoStore = true)]
        public async Task<IActionResult> Post()
        {
            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                    Delimiter = ";"
                };

                using var reader = new StreamReader(Path.Combine(_env.ContentRootPath, "Data/sample_data.csv"));
                using var csv = new CsvReader(reader, config);

                // Orders
                var orders = csv.GetRecords<Order>().ToList();
                _context.Orders.AddRange(orders);

                // Packets
                var packets = csv.GetRecords<Packet>().ToList();
                _context.Packets.AddRange(packets);

                // BakingGoods
                var bakingGoods = csv.GetRecords<BakingGood>().ToList();
                _context.BakingGoods.AddRange(bakingGoods);

                // Batches
                var batches = csv.GetRecords<Batch>().ToList();
                _context.Batches.AddRange(batches);

                // Stocks
                var stocks = csv.GetRecords<Stock>().ToList();
                _context.Stocks.AddRange(stocks);

                // OrderContents
                var orderBakingGoods = csv.GetRecords<OrderBakingGood>().ToList();
                _context.OrderContents.AddRange(orderBakingGoods);

                // BakingGoodBatches
                var bakingGoodBatches = csv.GetRecords<BakingGoodBatch>().ToList();
                _context.BakingGoodBatches.AddRange(bakingGoodBatches);

                // BatchDetails
                var batchStock = csv.GetRecords<BatchStock>().ToList();
                _context.BatchDetails.AddRange(batchStock);

                await _context.SaveChangesAsync();

                return Ok(new { Message = "Database seeded successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while seeding database");
                return StatusCode(500, "Error occurred while seeding database");
            }
        }
    }
}
