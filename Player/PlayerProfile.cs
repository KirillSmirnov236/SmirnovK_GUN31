

namespace CasinoGame.Player
{
    public sealed class PlayerProfile
    {
        public string Name;

        public int Bank;


        public PlayerProfile(string name , int bank)
        {
            Name = name;
            Bank = bank;
        }

        public override string ToString()
        {
            return Name +" "+ Bank;
        }
    }
}
