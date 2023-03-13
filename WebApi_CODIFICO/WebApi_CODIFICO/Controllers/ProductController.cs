using Microsoft.AspNetCore.Mvc;
using WebApi_CODIFICO.Models;

namespace WebApi_CODIFICO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly StoreSampleContext _dbcontext;

        public ProductController(StoreSampleContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Listall")]

        public IActionResult List()
        {
            try
            {
                List<Product> lista = new List<Product>();
                lista = _dbcontext.Products.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { error = "error", response = ex.Message });

            }
        }
    }
}
