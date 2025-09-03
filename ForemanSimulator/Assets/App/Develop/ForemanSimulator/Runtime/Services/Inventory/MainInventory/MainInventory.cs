using System;

namespace ForemanSimulator.Runtime.Services.Inventory
{
    public class MainInventory : Inventory
    {
        private InventorySlot[,] _slots;

        public MainInventory(int rowsCount, int colsCount)
        {
            if (rowsCount <= 0 || colsCount <= 0)
            {
                throw new Exception("Inventory size must be positive!");
            }

            _slots = new InventorySlot[rowsCount, colsCount];
            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    _slots[i, j] = new InventorySlot();
                }
            }
        }
    }
}
