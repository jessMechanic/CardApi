using CardApi.Models.Cards;
using System.Diagnostics.CodeAnalysis;

namespace CardApi.Models.Account
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }

        [AllowNull]
        public  List<Deck>? Decks { get; set; }
        public string PassHash { get; set; }

    }
}
