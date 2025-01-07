namespace HomeWork
{
    public class Unit
    {
        private float _health;
        private float _armor;
        private int _damage;
        public string Name { get; }
        public float Health => _health;
        public int Damage => _damage;
        public float Armor => _armor;

        public Unit() : this("Unknown Unit")
        {

        }

        public Unit(string name)
        {
            Name = name;
            _damage = 5;
            _armor = 0.6f;
        }
        public float GetRealHealth()
        {
            return Health * (1f + Armor);
        }
        public bool SetDamage(float value)
        {
            _health = Health - value * Armor;
            return Health >= 0f;
        }
    }
}
