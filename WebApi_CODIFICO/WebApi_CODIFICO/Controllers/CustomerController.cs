using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_CODIFICO.Models;

namespace WebApi_CODIFICO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public readonly StoreSampleContext _dbcontext;
        private List<Customer> usersInDb;

        public CustomerController(StoreSampleContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Listall")]

        public IActionResult List()
        {
            try
            {
                var list = _dbcontext.Set<Predicted>().FromSqlRaw
                (
                    "SELECT c.custid, c.companyname, MAX(o.orderdate) AS LastOrderDate,DATEADD(DAY, AVG(DATEDIFF(DAY, o.fecha_anterior, o.orderdate)) - 7, MAX(o.orderdate)) AS NextPredictedOrder,AVG(DATEDIFF(DAY, o.fecha_anterior, o.orderdate)) As Promedio_Dias FROM Sales.Customers c INNER JOIN( SELECT custid, orderdate, (SELECT MAX(orderdate) FROM Sales.Orders o2 WHERE o2.custid = o1.custid AND o2.orderdate < o1.orderdate) AS fecha_anterior, (SELECT AVG(DATEDIFF(DAY, o2.orderdate, o3.orderdate)) FROM Sales.Orders o2 INNER JOIN Sales.Orders o3 ON o3.custid = o2.custid AND o3.orderdate < o2.orderdate  WHERE o2.custid = o1.custid AND o2.orderdate = (SELECT MAX(orderdate) FROM Sales.Orders WHERE custid = o1.custid) GROUP BY o2.custid) AS promedio_dias_anteriores FROM Sales.Orders o1) o ON c.custid = o.custid GROUP BY c.custid , c.companyname;"
                )
                .ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = list });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { error = "error", response = ex.Message });

            }
        }
    }
}
