namespace Race.ApplicationService.Models
{
    public class HorseData
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int NumberOfBets { get; set; } 

        public decimal PayoutIfWon { get; set; }
    }
}