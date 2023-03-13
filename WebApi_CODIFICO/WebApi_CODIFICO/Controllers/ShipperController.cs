using Microsoft.AspNetCore.Mvc;
using WebApi_CODIFICO.Models;

namespace WebApi_CODIFICO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        public readonly StoreSampleContext _dbcontext;

        public ShipperController(StoreSampleContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Listall")]

        public IActionResult List()
        {
            try
            {
                List<Shipper> lista = new List<Shipper>();
                lista = _dbcontext.Shippers.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { error = "error", response = ex.Message });

            }
        }
    }
}
