namespace CardApi.Models.Cards
{
    public enum CardType
    {
        Attack,
        Defence
    }
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CardType Type { get; set; }
    }
}
