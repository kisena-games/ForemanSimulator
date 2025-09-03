using ForemanSimulator.Configs;
using ForemanSimulator.Runtime.Services.Inventory;
using UnityEngine;

namespace ForemanSimulator.Runtime.Services.Inventory
{
    public class MainInventorySlotView : MonoBehaviour
    {
        private MainInventoryViewConfig _config;
        private RectTransform _rectTransform;

        public InventorySlot Slot { get; private set; }
        public Vector2Int Index { get; private set; }

        public void Initialize(Vector2Int index, MainInventoryViewConfig config)
        {
            Index = index;
            _config = config;
            _rectTransform = GetComponent<RectTransform>();

            ResetView();
        }

        private void ResetView()
        {
            float offset = _config.slotOffset;
            float size = _config.slotSize;

            float slotPositionX = (size + offset) * Index.x;
            float slotPositionY = -(size + offset) * Index.y;

            _rectTransform.sizeDelta = new Vector2(size, size);
            _rectTransform.anchoredPosition = new Vector2(slotPositionX, slotPositionY);
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

