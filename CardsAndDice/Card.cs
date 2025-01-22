namespace CasinoGame.CardsAndDice
{
    public struct Card
    {
        private readonly Suits _suit;
        private readonly CardValue _value;

        public Suits Suit => _suit; 
        public CardValue Value => _value; 

        public Card(Suits suit, CardValue value)
        {
            _suit = suit;
            _value = value;
        }
    }
}
