using ForemanSimulator.Configs;
using UnityEngine;

namespace ForemanSimulator.Runtime.Services.Inventory
{
    public class QuickAccessInventoryView : MonoBehaviour
    {
        [SerializeField] private QuickAccessInventorySlotView _slotPrefab;
        [SerializeField] private QuickAccessInventoryViewConfig _config;

        private QuickAccessInventorySlotView[] _slotViews;
        private RectTransform _viewRect;

        private void Start()
        {
            _slotViews = new QuickAccessInventorySlotView[9];
            _viewRect = GetComponent<RectTransform>();

            ResetView();
            RenderSlots();
        }

        private void ResetView()
        {
            float width = (_config.slotSize * _slotViews.Length) + ((_slotViews.Length - 1) * _config.slotHorizontalkOffset);
            float height = _config.slotSize;
            _viewRect.sizeDelta = new Vector2(width, height);
        }

        private void RenderSlots()
        {
            for (int i = 0; i < _slotViews.Length; i++)
            {
                QuickAccessInventorySlotView slot = Instantiate(_slotPrefab, transform);
                slot.Initialize(i, _config);
                _slotViews[i] = slot;
            }
        }
    }
}
