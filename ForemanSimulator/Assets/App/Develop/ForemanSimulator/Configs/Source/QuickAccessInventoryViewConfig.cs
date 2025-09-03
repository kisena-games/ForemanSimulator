using UnityEngine;

namespace ForemanSimulator.Configs
{
    [CreateAssetMenu(fileName = "QuickAccessInventoryViewConfig", menuName = "Scriptable Objects/QuickAccessInventoryViewConfig")]
    public class QuickAccessInventoryViewConfig : ScriptableObject
    {
        [Tooltip("Размер ячейки инвентаря")]
        public float slotSize = 100f;

        [Tooltip("Отступ между ячейками")]
        public float slotHorizontalkOffset = 10f;
    }
}
