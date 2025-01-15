using GamePrototype.Units;

namespace GamePrototype.Utils
{
    public abstract class UnitFactory
    {
        public abstract Unit CreatePlayer(string name);
        

        public abstract Unit CreateGoblinEnemy();
    }
}
