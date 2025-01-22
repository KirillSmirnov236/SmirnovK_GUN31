using CasinoGame.CasinoMechanics;
using CasinoGame.GameMechanics;
using CasinoGame.Player;
using GamePrototype.Games;
using GamePrototype.Services;


namespace GamePrototype
{
    public class Casino : IGame
    {
        private readonly FileSystemSaveLoadService _saveLoadService;
        private PlayerProfile _playerProfile;
        private readonly Dictionary<int, CasinoGameBase> _games;
        private const int MaxBank = int.MaxValue;
        private const string ProfileId = "player_profile";

        public Casino(FileSystemSaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService ?? throw new ArgumentNullException(nameof(saveLoadService));

            _games = new Dictionary<int, CasinoGameBase>
            {
                { 1, new BlackJack(52) },
                { 2, new DiceGame(2, 1, 6) }
            };
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to the Casino!");
            LoadOrCreateProfile();

            // Игровой цикл
            while (_playerProfile.Bank > 0)
            {
                Console.WriteLine($"Your bank balance {_playerProfile.Bank}");
                Console.WriteLine("Do you want to continue playing? (yes/exit)");
                string input = Console.ReadLine();
                if (input == "exit")
                    break;

                if (input == "yes")
                {
                    int gameChoice = ChooseGame();
                    int bet = GetPlayerBet();
                    StartSelectedGame(gameChoice, bet);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'exit'.");
                    continue;
                }
            }
            if (_playerProfile.Bank <= 0)
            {
                Console.WriteLine("You have lost all your money! Game Over");
                _playerProfile.Bank = 100;
                
            }
            SaveProfile();
            Console.WriteLine("Goodbye, see you soon!");
        }

        
        private void LoadOrCreateProfile()
        {
            string profileData = _saveLoadService.LoadData(ProfileId);

            if (string.IsNullOrEmpty(profileData))
            {
                Console.WriteLine("No profile found. Please enter your name:");
                string playerName = Console.ReadLine();
                if (string.IsNullOrEmpty(playerName))
                    playerName = "Player";
                _playerProfile = new PlayerProfile(playerName, 100); // Default bank
                Console.WriteLine($"Welcome, {playerName}! Your starting bank balance is 100.");
            }
            else
            {
                string[] parts = profileData.Split(' ');
                if (parts.Length == 2 && int.TryParse(parts[1], out int bank))
                {
                    _playerProfile = new PlayerProfile(parts[0], bank);
                    Console.WriteLine($"Welcome back, {_playerProfile.Name}! Your bank balance is {_playerProfile.Bank}.");
                }
                else
                {
                    Console.WriteLine("Invalid profile format. Please enter your name:");
                    string playerName = Console.ReadLine();
                    if (string.IsNullOrEmpty(playerName))
                        playerName = "Player";
                    _playerProfile = new PlayerProfile(playerName, 100); // Default bank
                    Console.WriteLine($"Welcome, {playerName}! Your starting bank balance is 100.");
                }
            }
        }

        private int ChooseGame()
        {
            int gameChoice;
            do
            {
                Console.WriteLine("Choose a game:");
                Console.WriteLine("1 - BlackJack");
                Console.WriteLine("2 - Dice Game");
                if (!int.TryParse(Console.ReadLine(), out gameChoice) || !_games.ContainsKey(gameChoice))
                {
                    Console.WriteLine("Invalid input, please enter 1 or 2");
                    gameChoice = 0;
                }
            }
            while (gameChoice == 0);
            return gameChoice;
        }
        private int GetPlayerBet()
        {
            int bet;
            do
            {
                Console.WriteLine($"Please enter your bet. Max bet {_playerProfile.Bank}");
                if (!int.TryParse(Console.ReadLine(), out bet) || bet <= 0 || bet > _playerProfile.Bank)
                {
                    Console.WriteLine("Invalid input, please enter correct value");
                    bet = 0;
                }
            }
            while (bet == 0);
            return bet;
        }
        private void StartSelectedGame(int gameChoice, int bet)
        {
            var selectedGame = _games[gameChoice];

            Action onWin = () => OnGameWin(bet);
            Action onLoose = () => OnGameLoose(bet);
            Action onDraw = () => OnGameDraw();

            selectedGame.OnWin += onWin;
            selectedGame.OnLoose += onLoose;
            selectedGame.OnDraw += onDraw;

            selectedGame.PlayGame();

            selectedGame.OnWin -= onWin;
            selectedGame.OnLoose -= onLoose;
            selectedGame.OnDraw -= onDraw;
        }
        private void OnGameWin(int bet)
        {
            _playerProfile.Bank += bet;
            if (_playerProfile.Bank > MaxBank)
            {
                int excess = _playerProfile.Bank - MaxBank;
                Console.WriteLine($"You have exceeded maximum bank limit and won an additional {excess}, we are going to build a new casino! \n Your new bank balance is {MaxBank}!");
                _playerProfile.Bank = MaxBank;
            }
            else
            {
                Console.WriteLine($"Your bank balance is now {_playerProfile.Bank}");
            }
        }

        private void OnGameLoose(int bet)
        {
            _playerProfile.Bank -= bet;
            Console.WriteLine($"Your bank balance is now {_playerProfile.Bank}");
        }

        private void OnGameDraw()
        {
            Console.WriteLine($"Your bank balance is {_playerProfile.Bank}");
        }

        private void SaveProfile()
        {
            string profileData = $"{_playerProfile.Name} {_playerProfile.Bank}";
            _saveLoadService.SaveData(profileData, ProfileId);
        }
    }
}