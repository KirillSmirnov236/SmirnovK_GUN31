using GamePrototype.Combat;
using GamePrototype.Dungeon;
using GamePrototype.Units;
using GamePrototype.Utils;

namespace GamePrototype.Game
{
    public sealed class GameLoop
    {
        private Unit _player;
        private DungeonRoom _dungeon;
        private readonly CombatManager _combatManager = new CombatManager();
        
        public void StartGame() 
        {
            Initialize();
            Console.WriteLine("Entering the dungeon");
            StartGameLoop();
        }

        #region Game Loop

        private void Initialize()
        {
            Console.WriteLine("Welcome, player!");

            Console.WriteLine("Type the difficulty level(Easy,Hard):");
            var input = Console.ReadLine();
            var difficulty = new DifficultyLevel();
            if (input == "Easy")
            {
                difficulty = DifficultyLevel.Easy;
                Console.WriteLine("Difficulty level: Easy.");
            }
            else
            {
                difficulty = DifficultyLevel.Hard;
                Console.WriteLine("Difficulty level: Hard.");
            }

            Console.WriteLine("Enter your name");
            var playerName = Console.ReadLine();

            switch (difficulty)
            {
                case DifficultyLevel.Easy:
                    var UnitFactoryEasy = new UnitFactoryEasy();
                    var EasyDungeonBuilder = new EasyDungeonBuilder();

                    _player = UnitFactoryEasy.CreatePlayer(playerName);
                    _dungeon = EasyDungeonBuilder.BuildDungeon();
                    break;

                case DifficultyLevel.Hard:
                    var UnitFactoryHard = new UnitFactoryHard();
                    var HardDungeonBuilder = new HardDungeonBuilder();

                    _player = UnitFactoryHard.CreatePlayer(playerName);
                    _dungeon = HardDungeonBuilder.BuildDungeon();
                    break;

            }
            
            Console.WriteLine($"Hello {_player.Name}");
        }

        private void StartGameLoop()
        {
            var currentRoom = _dungeon;
            
            while (currentRoom.IsFinal == false) 
            {
                StartRoomEncounter(currentRoom, out var success);
                if (!success) 
                {
                    Console.WriteLine("Game over!");
                    return;
                }
                DisplayRouteOptions(currentRoom);
                while (true) 
                {
                    if (Enum.TryParse<Direction>(Console.ReadLine(), out var direction) ) 
                    {
                        currentRoom = currentRoom.Rooms[direction];
                        break;
                    }
                    else 
                    {
                        Console.WriteLine("Wrong direction!");
                    }
                }
            }
            Console.WriteLine($"Congratulations, {_player.Name}");
            Console.WriteLine("Result: ");
            Console.WriteLine(_player.ToString());
        }

        private void StartRoomEncounter(DungeonRoom currentRoom, out bool success)
        {
            success = true;
            if (currentRoom.Loot != null) 
            {
                _player.AddItemToInventory(currentRoom.Loot);
            }
            if (currentRoom.Enemy != null) 
            {
                if (_combatManager.StartCombat(_player, currentRoom.Enemy) == _player)
                {
                    _player.HandleCombatComplete();
                    LootEnemy(currentRoom.Enemy);
                }
                else 
                {
                    success = false;
                }
            }

            void LootEnemy(Unit enemy)
            {
                _player.AddItemsFromUnitToInventory(enemy);
            }
        }

        private void DisplayRouteOptions(DungeonRoom currentRoom)
        {
            Console.WriteLine("Where to go?");
            foreach (var room in currentRoom.Rooms)
            {
                Console.Write($"{room.Key} - {(int) room.Key}\t");
            }
        }

        
        #endregion
    }
}
