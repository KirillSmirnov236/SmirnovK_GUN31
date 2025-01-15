using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;

namespace GamePrototype.Utils
{
    public class HardDungeonBuilder : DungeonBuilder
    {
        public override DungeonRoom BuildDungeon()
        {
            var UnitFactoryHard = new UnitFactoryHard();

            var enter = new DungeonRoom("Enter");
            var monsterRoom = new DungeonRoom("Monster", UnitFactoryHard.CreateGoblinEnemy());
            var emptyRoom = new DungeonRoom("Empty");
            var lootRoom = new DungeonRoom("Loot1", new Gold());
            var lootStoneRoom = new DungeonRoom("Loot1", new Grindstone("Stone"));
            var finalRoom = new DungeonRoom("Final", new Grindstone("Stone1"));


            enter.TrySetDirection(Direction.Right, lootStoneRoom);
            enter.TrySetDirection(Direction.Left, emptyRoom);

            monsterRoom.TrySetDirection(Direction.Forward, enter);
            monsterRoom.TrySetDirection(Direction.Left, emptyRoom);

            emptyRoom.TrySetDirection(Direction.Left, monsterRoom);
            emptyRoom.TrySetDirection(Direction.Right, monsterRoom);
            emptyRoom.TrySetDirection(Direction.Forward, lootRoom);


            lootRoom.TrySetDirection(Direction.Forward, finalRoom);
            lootStoneRoom.TrySetDirection(Direction.Forward, emptyRoom);

            return enter;
        }

    }


}
