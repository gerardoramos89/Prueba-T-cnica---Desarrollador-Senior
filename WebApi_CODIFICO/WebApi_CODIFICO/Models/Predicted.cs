namespace WebApi_CODIFICO.Models
{
    public class Predicted
    {
        public int Custid { get; set; }

        public string Companyname { get; set; } = null!;

        public DateTime? LastOrderDate { get; set; }

        public DateTime? NextPredictedOrder { get; set; }

    }
}
