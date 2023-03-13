namespace WebApi_CODIFICO.Models;

public partial class Shipper
{
    public int Shipperid { get; set; }

    public string Companyname { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
