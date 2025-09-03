using ForemanSimulator.Configs;
using UnityEngine;

namespace ForemanSimulator.Runtime.Services.Inventory
{
    public class MainInventoryView : MonoBehaviour
    {
        [SerializeField] private MainInventorySlotView _slotPrefab;
        [SerializeField] private MainInventoryViewConfig _config;

        private MainInventorySlotView[,] _slotViews;
        private RectTransform _viewRect;

        private void Start()
        {
            _slotViews = new MainInventorySlotView[3, 5];
            _viewRect = GetComponent<RectTransform>();

            ResetView();
            RenderSlots();
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        private void ResetView()
        {
            int rowsCount = _slotViews.GetLength(0);
            int columnsCount = _slotViews.GetLength(1);

            float slotSize = _config.slotSize;
            float offset = _config.slotOffset;

            float width = (slotSize + offset) * columnsCount - offset;
            float height = (slotSize + offset) * rowsCount - offset;

            _viewRect.sizeDelta = new Vector2(width, height);
        }

        private void RenderSlots()
        {
            int rowsCount = _slotViews.GetLength(0);
            int columnsCount = _slotViews.GetLength(1);

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    var slot = Instantiate(_slotPrefab, transform);
                    var index = new Vector2Int(j, i);
                    slot.Initialize(index, _config);
                    _slotViews[i, j] = slot;
                }

            }
        }
    }
}
