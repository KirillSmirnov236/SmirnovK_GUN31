using Homework;

namespace HomeWork
{
    public struct Room
    {
        public Unit Unit;
        public Weapon Weapon;

        public Room(Unit unit, Weapon weapon) 
        {
            Unit = unit;
            Weapon = weapon;
        }
    }
}
