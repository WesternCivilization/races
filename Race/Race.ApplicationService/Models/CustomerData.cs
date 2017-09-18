namespace Race.ApplicationService.Models
{
    public class CustomerData
    {
        public int Id { get; set; }

        public int NumberOfBets { get; set; }

        public decimal TotalAmountOnBets { get; set; }

        public bool IsAtRisk { get; set; }
    }
}