namespace Homework
{
    public class Weapon
    {
        private float _durability;
        public string Name { get; }
        public int MinDamage { get; private set; }
        public int MaxDamage { get; private set; }

        public float Durability => _durability;

        public Weapon(string name) 
        {
            Name = name;
        }
        public Weapon(string name ,int minDamage , int maxDamage) : this(name) 
        {
            SetDamageParams(minDamage, maxDamage);
        }

        public void SetDamageParams(int minDamage , int maxDamage) 
        {
            if (maxDamage < minDamage)
            {
                var x = maxDamage;
                MaxDamage = minDamage;
                MinDamage = x;
                Console.WriteLine("MinDamage bigger then MaxDamage, weapon name:{1}", Name);

            }
            if (minDamage < 1) 
            {
                MinDamage = 1;
                Console.WriteLine("Forced setting of MinDamage");
            }
            if (maxDamage <= 1)
            {
                MaxDamage = 10;
            }
        }

        public int GetDamage()
        {
            return (MinDamage + MaxDamage) / 2;
        }

    }
}
