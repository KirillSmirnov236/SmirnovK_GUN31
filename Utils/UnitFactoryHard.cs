using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Units;

namespace GamePrototype.Utils
{
    public class UnitFactoryHard : UnitFactory
    {
        public override Unit CreatePlayer(string name)
        {
            var player = new Player(name, 25, 30, 3);
            player.AddItemToInventory(new Weapon(8, 8, "Old Sword"));
            player.AddItemToInventory(new Armour(8, 8, "Old Armour"));
            player.AddItemToInventory(new HealthPotion("Potion"));
            return player;
        }

        public override Unit CreateGoblinEnemy() => new Goblin(GameConstants.Goblin, 25, 25, 4);
    }
}
