

using Homework;

namespace HomeWork
{
    public class Dungeon
    {
        private Room[] rooms;

        public Dungeon()
        {
            //
            var w1 = new Weapon("sword", 5, 10);
            var w2 = new Weapon("dagger", 1, 5);
            var w3 = new Weapon("bow", 5, 15);
            //
            var u1 = new Unit("orc");
            var u2 = new Unit("skeleton");
            var u3 = new Unit("bandit");
            //
            var r1 = new Room(u1, w1);
            var r2 = new Room(u2, w2);
            var r3 = new Room(u3, w3);
            //
            rooms = new Room[3] { r1, r2, r3 };
        }
        public void ShowRooms()
        {
            for (int i = 0; i < rooms.Length; i++)
            {
                Console.WriteLine("Unit of room: " + rooms[i].Unit.Name);
                Console.WriteLine("Weapon of room: " + rooms[i].Weapon.Name);
                Console.WriteLine("-----");
            }
        }
    }
}
