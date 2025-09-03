using UnityEngine;

namespace ForemanSimulator.Configs
{
    [CreateAssetMenu(fileName = "QuickAccessInventoryViewConfig", menuName = "Scriptable Objects/QuickAccessInventoryViewConfig")]
    public class QuickAccessInventoryViewConfig : ScriptableObject
    {
        [Tooltip("������ ������ ���������")]
        public float slotSize = 100f;

        [Tooltip("������ ����� ��������")]
        public float slotHorizontalkOffset = 10f;
    }
}
