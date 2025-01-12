using GamePrototype.Utils;

namespace GamePrototype.Items.EconomicItems
{
    public sealed class Gold : EconomicItem
    {
        public override bool Stackable => true;

        public Gold() : base(GameConstants.Gold)
        {            
        }       
    }
}
