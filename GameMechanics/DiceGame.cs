
using CasinoGame.CardsAndDice;
using CasinoGame.GameMechanics;

namespace GamePrototype.Games
{
    public class DiceGame : CasinoGameBase
    {
        private readonly int _numberOfDice;
        private readonly int _minDiceValue;
        private readonly int _maxDiceValue;
        private List<Dice> _dices;
        public DiceGame(int numberOfDice, int minDiceValue, int maxDiceValue) : base()
        {
            if (numberOfDice <= 0)
            {
                throw new ArgumentOutOfRangeException("Number of dices must be greater than 0");
            }

            if (minDiceValue < 1 || minDiceValue > int.MaxValue || maxDiceValue < 1 || maxDiceValue > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException($"Invalid range: Min = {minDiceValue}, Max = {maxDiceValue}. Values must be between 1 and {int.MaxValue}");
            }
            if (minDiceValue > maxDiceValue)
            {
                throw new ArgumentOutOfRangeException($"Invalid range: Min = {minDiceValue}, Max = {maxDiceValue}. Min value can not be greater than max value");
            }
            _numberOfDice = numberOfDice;
            _minDiceValue = minDiceValue;
            _maxDiceValue = maxDiceValue;
        }
        protected override void FactoryMethod()
        {
            _dices = new List<Dice>();
            for (int i = 0; i < _numberOfDice; i++)
            {
                _dices.Add(new Dice(_minDiceValue, _maxDiceValue));
            }
        }

        public override void PlayGame()
        {
            FactoryMethod();

            Console.WriteLine("Starting DiceGame");
            // Бросаем кости для игрока
            int playerSum = RollDice();
            PrintResult($"Player sum: {playerSum}");
            // Бросаем кости для компьютера
            int computerSum = RollDice();
            PrintResult($"Computer sum: {computerSum}");
            // Определяем победителя
            if (playerSum > computerSum)
            {
                PrintResult("Player wins!");
                OnWinInvoke();
            }
            else if (computerSum > playerSum)
            {
                PrintResult("Computer wins!");
                OnLooseInvoke();
            }
            else
            {
                PrintResult("Draw");
                OnDrawInvoke();
            }
            Console.WriteLine("DiceGame finished");
        }
        private int RollDice()
        {
            return _dices.Sum(dice => dice.Number);
        }
    }
}
