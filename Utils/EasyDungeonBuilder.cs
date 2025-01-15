using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;

namespace GamePrototype.Utils
{
    public class EasyDungeonBuilder : DungeonBuilder
    {
        public override DungeonRoom BuildDungeon()
        {
            var UnitFactoryEasy = new UnitFactoryEasy();

            var enter = new DungeonRoom("Enter");
            var monsterRoom = new DungeonRoom("Monster", UnitFactoryEasy.CreateGoblinEnemy());
            var emptyRoom = new DungeonRoom("Empty");
            var lootRoom = new DungeonRoom("Loot1", new Gold());
            var lootStoneRoom = new DungeonRoom("Loot1", new Grindstone("Stone"));
            var finalRoom = new DungeonRoom("Final", new Grindstone("Stone1"));

            
            enter.TrySetDirection(Direction.Right, monsterRoom);
            enter.TrySetDirection(Direction.Left, emptyRoom);

            monsterRoom.TrySetDirection(Direction.Forward, lootRoom);
            monsterRoom.TrySetDirection(Direction.Left, emptyRoom);

            emptyRoom.TrySetDirection(Direction.Forward, lootStoneRoom);

            lootRoom.TrySetDirection(Direction.Forward, finalRoom);
            lootStoneRoom.TrySetDirection(Direction.Forward, finalRoom);

            return enter;
        }

    }


}
