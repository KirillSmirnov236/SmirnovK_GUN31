

namespace CasinoGame.CardsAndDice
{
    public class WrongDiceNumberException : Exception
    {
        public WrongDiceNumberException(string message) : base(message)
        {
        }
    }
}
