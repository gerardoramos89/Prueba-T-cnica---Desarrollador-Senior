using Microsoft.AspNetCore.Mvc;
using WebApi_CODIFICO.Models;

namespace WebApi_CODIFICO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        public readonly StoreSampleContext _dbcontext;

        public EmployerController(StoreSampleContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("EmployerListall")]

        public IActionResult List()
        {
            try
            {
                List<Employee> lista = new List<Employee>();
                lista = _dbcontext.Employees.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista.ToList() });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { error = "error", response = ex.Message });

            }
        }
    }
}
