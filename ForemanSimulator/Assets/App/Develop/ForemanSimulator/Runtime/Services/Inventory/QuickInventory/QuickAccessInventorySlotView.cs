using ForemanSimulator.Configs;
using ForemanSimulator.Runtime.Services.Inventory;
using UnityEngine;

namespace ForemanSimulator.Runtime.Services.Inventory
{
    public class QuickAccessInventorySlotView : MonoBehaviour
    {
        private QuickAccessInventoryViewConfig _config;
        private RectTransform _rectTransform;

        public InventorySlot Slot { get; private set; }
        public int Index { get; private set; }

        public void Initialize(int index, QuickAccessInventoryViewConfig config)
        {
            Index = index;
            _config = config;
            _rectTransform = GetComponent<RectTransform>();

            ResetView();
        }

        private void ResetView()
        {
            float slotPositionX = (_config.slotSize + _config.slotHorizontalkOffset) * Index;
            _rectTransform.sizeDelta = new Vector2(_config.slotSize, _config.slotSize);
            _rectTransform.anchoredPosition = new Vector2(slotPositionX, 0f);
        }

        public void SetItem(InventorySlot slot)
        {
            Slot = slot;
        }

        public void Clear()
        {
            Slot = null;
        }
    }
}
