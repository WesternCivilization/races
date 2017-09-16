namespace Race.Domain
{
    public class Bet
    {
        public Customer Customer { get; set; }

        public Horse Horse { get; set; }

        public Race Race { get; set; }

        public decimal Stake { get; set; }
    }
}
