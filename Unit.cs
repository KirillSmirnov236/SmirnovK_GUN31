using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    public class Unit
    {
        private float _health;
        private float _armor;
        public string Name { get; }
        public float Health => _health;
        public int Damage;
        public float Armor => _armor;

        public Unit() : this("Unknown Unit")
        {
            
        }

        public Unit(string name)
        {
            Name = name;
            Damage = 5;
            _armor = 0.6f;
        }
        public float GetRealHealth()
        {
            return Health * (1f + Armor);
        }
        public bool SetDamage(float value)
        {
            _health = Health - value * Armor;
            
            if (Health <= 0f)
            {
                return true;
            }
            else 
            { 
                return false; 
            }
        }
    }
}
