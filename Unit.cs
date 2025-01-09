
namespace HomeWork
{
    public class Unit
    {
        private float _health;
        private float _armor;
        private Interval _damage;

        public string Name { get; }
        public float Health => _health;
        public Interval Damage => _damage;
        public float Armor => _armor;

        public Unit() : this("Unknown Unit")
        {

        }

        public Unit(string name)
        {
            Name = name;
            _damage = new Interval(0, 5);
            _armor = 0.6f;
        }
        public Unit(string name, int minDamage, int maxDamage)
        {
            Name = name;
            _damage = new Interval(minDamage, maxDamage);
            _armor = 0.6f;
        }
        public float GetRealHealth()
        {
            return Health * (1f + Armor);
        }
        public bool SetDamage(float value)
        {
            _health = Health - value * Armor;

            return Health <= 0f;

        }
    }
}
