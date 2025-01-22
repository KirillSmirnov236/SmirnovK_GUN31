
using CasinoGame.CardsAndDice;

namespace CasinoGame.GameMechanics
{
    public class BlackJack : CasinoGameBase
    {
        private readonly int _numberOfCards;
        private readonly Queue<Card> _deck = new Queue<Card>();
        private const int BlackJackValue = 21;

        public BlackJack(int numberOfCards) : base()
        {
            if (numberOfCards < 1)
            {
                throw new ArgumentOutOfRangeException("Number of cards should be greater than 0");
            }

            _numberOfCards = numberOfCards;
        }

        protected override void FactoryMethod()
        {
            List<Card> cards = new List<Card>();
            foreach (Suits suit in Enum.GetValues(typeof(Suits)))
            {
                foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                {
                    cards.Add(new Card(suit, value));
                }
            }
            Shuffle(cards);
        }
        private void Shuffle(List<Card> cards)
        {
            Random random = new Random();
            var shuffledCards = cards.OrderBy(_ => random.Next()).ToList();

            foreach (var card in shuffledCards)
            {
                _deck.Enqueue(card);
            }
        }
        public override void PlayGame()
        {
            Console.WriteLine("Starting BlackJack");

            List<Card> playerHand = new List<Card>();
            List<Card> computerHand = new List<Card>();

            // Выдача первых двух карт
            DealCard(playerHand);
            DealCard(playerHand);
            DealCard(computerHand);
            DealCard(computerHand);

            int playerPoints = CalculatePoints(playerHand);
            int computerPoints = CalculatePoints(computerHand);

            PrintResult($"Player points: {playerPoints}");
            PrintResult($"Computer points: {computerPoints}");

            // Проверка
            if (playerPoints > BlackJackValue && computerPoints > BlackJackValue)
            {
                PrintResult("Draw");
                OnDrawInvoke();
                return;
            }
            // цикл взятия дополнительных карт если очки равны и меньше 21
            while (playerPoints == computerPoints && playerPoints < BlackJackValue)
            {
                DealCard(playerHand);
                DealCard(computerHand);
                playerPoints = CalculatePoints(playerHand);
                computerPoints = CalculatePoints(computerHand);

                PrintResult($"Player points: {playerPoints}");
                PrintResult($"Computer points: {computerPoints}");
            }
            // проверка на победу
            if (playerPoints <= BlackJackValue && (computerPoints > BlackJackValue || computerPoints < playerPoints))
            {
                PrintResult("Player wins!");
                OnWinInvoke();
                return;
            }
            if (computerPoints <= BlackJackValue && (playerPoints > BlackJackValue || playerPoints < computerPoints))
            {
                PrintResult("Computer wins!");
                OnLooseInvoke();
                return;
            }
            // если вышли из цикла значит ничья
            PrintResult("Draw");
            OnDrawInvoke();

            Console.WriteLine("BlackJack finished");
        }
        private int CalculatePoints(List<Card> hand)
        {
            int sum = 0;
            int aceCount = 0;

            foreach (var card in hand)
            {
                if (card.Value >= CardValue.Six && card.Value <= CardValue.Ten)
                {
                    sum += (int)card.Value;
                }
                else if (card.Value >= CardValue.Jack && card.Value <= CardValue.King)
                {
                    sum += 10;
                }
                else if (card.Value == CardValue.Ace)
                {
                    aceCount++;
                    sum += 11;
                }
            }
            while (sum > BlackJackValue && aceCount > 0)
            {
                sum -= 10;
                aceCount--;
            }
            return sum;
        }
        private void DealCard(List<Card> hand)
        {
            if (_deck.Count > 0)
            {
                hand.Add(_deck.Dequeue());
            }
            else
            {
                FactoryMethod();
                hand.Add(_deck.Dequeue());
            }

        }


    }
}
