namespace CardApi.Models.Cards
{
    public class Deck
    {
        public Guid Id { get; set; }
        public List<Card>? Cards { get; set; }
    }
}
