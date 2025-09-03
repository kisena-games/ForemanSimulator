namespace Infrastructure.EventBus.Signals
{
    public class InventoryActionSignal
    {
        public readonly bool NeedToLock;

        public InventoryActionSignal(bool needToLock)
        {
            NeedToLock = needToLock;
        }
    }
}