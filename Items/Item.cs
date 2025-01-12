namespace GamePrototype.Items.EconomicItems
{
    public abstract class Item
    {
        public abstract bool Stackable { get; }

        public virtual uint Amount { get; protected set; }

        public string Name { get; }

        protected Item(string name)
        {
            Name = name;
            Amount = 1;
        }

        public bool TryStack(Item item)
        {
            if (!Stackable)
            {
                return false;
            }
            Amount++;
            return true;
        }
    }
}
