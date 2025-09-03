using UnityEngine;

namespace ForemanSimulator.Configs
{
    [CreateAssetMenu(fileName = "MainInventoryViewConfig", menuName = "Scriptable Objects/MainInventoryViewConfig")]
    public class MainInventoryViewConfig : ScriptableObject
    {
        [Tooltip("������ ������ ���������")]
        public float slotSize = 100f;

        [Tooltip("������ ����� ��������")]
        public float slotOffset = 10f;
    }
}
