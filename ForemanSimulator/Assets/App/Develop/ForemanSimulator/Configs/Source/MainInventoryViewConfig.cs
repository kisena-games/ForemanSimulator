using UnityEngine;

namespace ForemanSimulator.Configs
{
    [CreateAssetMenu(fileName = "MainInventoryViewConfig", menuName = "Scriptable Objects/MainInventoryViewConfig")]
    public class MainInventoryViewConfig : ScriptableObject
    {
        [Tooltip("Размер ячейки инвентаря")]
        public float slotSize = 100f;

        [Tooltip("Отступ между ячейками")]
        public float slotOffset = 10f;
    }
}
