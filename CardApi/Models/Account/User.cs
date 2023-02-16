using CardApi.Models.Cards;

namespace CardApi.Models.Account
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public List<Deck>? Decks { get; set; }

    }
}
