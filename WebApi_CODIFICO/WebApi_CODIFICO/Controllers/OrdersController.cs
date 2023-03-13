using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_CODIFICO.Models;

namespace WebApi_CODIFICO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public readonly StoreSampleContext _dbcontext;
        private List<Order> usersInDb;

        public OrdersController(StoreSampleContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Listall")]

        public IActionResult List()
        {
            try
            {
                List<Order> lista = new List<Order>();
                lista = _dbcontext.Orders.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status404NotFound, new { error = "error", response = ex.Message });

            }
        }

        [HttpGet("Order")]
        public IActionResult GetOrderDetailsById(int custId)
        {
            if (custId <= 0)
                return NotFound("not found");

            Order Orders;
            try
            {
                List<Order> lista = new List<Order>();
                lista = _dbcontext.Orders.Where(e => e.Custid == custId).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { error = "error", response = ex.Message });
            }
        }
    }
}
