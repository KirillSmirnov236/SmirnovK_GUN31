using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Utils;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace GamePrototype.Units
{
    public sealed class Player : Unit
    {
        private readonly Dictionary<EquipSlot, EquipItem> _equipment = new();

        public Player(string name, uint health, uint maxHealth, uint baseDamage) : base(name, health, maxHealth, baseDamage)
        {            
        }

        public override uint GetUnitDamage()
        {
            
            if (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon) 
            {
                return BaseDamage + weapon.Damage;
            }
            //task2
            else
            {
                if (_equipment.TryGetValue(EquipSlot.RangeWeapon, out var item2) && item2 is RangeWeapon rangeWeapon)
                {
                    return BaseDamage + rangeWeapon.Damage;
                }
            }
            //
            return BaseDamage;
        }

        public override void HandleCombatComplete()
        {
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++) 
            {
                if (items[i] is EconomicItem economicItem) 
                {
                    UseEconomicItem(economicItem);
                    Inventory.TryRemove(items[i]);
                }
            }
        }

        public override void AddItemToInventory(Item item)
        {
            if (item is EquipItem equipItem && _equipment.TryAdd(equipItem.Slot, equipItem)) 
            {
                // Item was equipped
                return;
            }
            
            if (item is EquipItem equipItem1)
            {
                Console.WriteLine($"Have you received {equipItem1.Name}, do you want to use it instead of the old one?");
                Console.WriteLine("Yes-1 , No-0");
                int input = int.Parse(Console.ReadLine());
                if (input == 1) 
                {
                    var slotType = equipItem1.Slot;
                    _equipment[slotType] = equipItem1;
                }
                return;
            }
            //
            base.AddItemToInventory(item);
        }

        private void UseEconomicItem(EconomicItem economicItem)
        {
            if (economicItem is HealthPotion healthPotion) 
            {
                Health += healthPotion.HealthRestore;
            }
            //task1
            if (economicItem is Grindstone grindstone) 
            {
                if (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon)
                {
                    weapon.Repair(grindstone.DurabilityRestore);
                }
            }
            //
        }

        protected override uint CalculateAppliedDamage(uint damage)
        {
            //task1 and task2
            uint reduceDurabilityPerHit = 1;

            if (_equipment.TryGetValue(EquipSlot.Armour, out var item) && item is Armour armour) 
            {
                damage -= (uint)(damage * (armour.Defence / 100f));
                armour.ReduceDurability(reduceDurabilityPerHit);
            }

            if (_equipment.TryGetValue(EquipSlot.Helmet, out var item2) && item2 is Helmet helmet)
            {
                damage -= (uint)(damage * (helmet.Defence / 100f));
                helmet.ReduceDurability(reduceDurabilityPerHit);
            }
            //
            return damage;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(Name);
            builder.AppendLine($"Health {Health}/{MaxHealth}");
            builder.AppendLine("Loot:");
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++) 
            {
                builder.AppendLine($"[{items[i].Name}] : {items[i].Amount}");
            }
            return builder.ToString();
        }
    }
}
