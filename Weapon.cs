using HomeWork;

namespace Homework
{
    public class Weapon
    {
        private float _durability;
        public string Name { get; }

        public Interval Damage;

        public float Durability => _durability;

        public Weapon(string name) 
        {
            Name = name;
        }
        public Weapon(string name , Interval damage) : this(name) 
        {
            Damage = damage;
        }

        public int GetDamage()
        {
            return Damage.Get();
        }

    }
}
