using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardApi.Models.Cards
{
    public enum CardType
    {
        Attack,
        Defence
    }
    public class Card
    {
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CardType Type { get; set; }
    }
}
