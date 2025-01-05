
namespace HomeWork
{
    public class Unit
    {
        private float _health;
        private float _armor;
        public string Name { get; }
        public float Health => _health;
        public Interval Damage;
        public float Armor => _armor;

        public Unit() : this("Unknown Unit")
        {
            
        }

        public Unit(string name)
        {
            Name = name;
            Damage = new Interval(0, 5);
            _armor = 0.6f;
        }
        public Unit(string name, int minDamage, int maxDamage) 
        {
            Name = name;
            Damage = new Interval(minDamage, maxDamage);
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
