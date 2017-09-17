namespace Race.ApplicationService.Models
{
    public class HorseData
    {
        public string Name { get; set; }

        public int NumberOfBetsOnMe { get; set; } 

        public decimal PayoutIfIWin { get; set; }
    }
}