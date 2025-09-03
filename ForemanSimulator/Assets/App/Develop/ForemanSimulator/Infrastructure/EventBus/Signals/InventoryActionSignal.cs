namespace Infrastructure.EventBus.Signals
{
    public class InventoryActionSignal
    {
        public readonly bool IsOpen;

        public InventoryActionSignal(bool isOpen)
        {
            IsOpen = isOpen;
        }
    }
}