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
        public Weapon(string name , int minDamage , int maxDamage) : this(name) 
        {
            Damage = new Interval(minDamage , maxDamage);
        }

        public int GetDamage()
        {
            return Damage.Get();
        }

    }
}
