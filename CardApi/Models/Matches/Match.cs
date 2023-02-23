namespace CardApi.Models.Matches
{
    public class Match
    {
        public Guid Id { get; set; }
        public Guid Player1 { get; set; }
        public Guid? Player2 { get; set; }

        public Match(Guid player1)
        {
            Player1 = player1;
        }
    }
}
