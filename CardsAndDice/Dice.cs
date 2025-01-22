
using CasinoGame.CardsAndDice;

namespace GamePrototype
{
    public struct Dice
    {
        private readonly int _min;
        private readonly int _max;
        private static readonly Random _random = new Random();

        public Dice(int min, int max)
        {
            if (min < 1 || min > int.MaxValue || max < 1 || max > int.MaxValue)
            {
                throw new WrongDiceNumberException($"Invalid range: Min = {min}, Max = {max}. Values must be between 1 and {int.MaxValue}");
            }

            if (min > max)
            {
                throw new WrongDiceNumberException($"Invalid range: Min = {min}, Max = {max}. Min value can not be greater than max value");
            }

            _min = min;
            _max = max;
        }

        public int Number
        {
            get
            {
                return _random.Next(_min, _max + 1);
            }
        }
    }
}