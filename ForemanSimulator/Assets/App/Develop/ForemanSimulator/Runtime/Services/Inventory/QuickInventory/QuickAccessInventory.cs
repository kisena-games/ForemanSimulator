
namespace ForemanSimulator.Runtime.Services.Inventory
{
    public class QuickAccessInventory : Inventory
    {
        private InventorySlot[] _slots;

        public QuickAccessInventory(int inventorySize)
        {
            _slots = new InventorySlot[inventorySize];
            for (int i = 0; i < _slots.Length; i++)
            {
                _slots[i] = new InventorySlot();
            }
        }
    }
}
