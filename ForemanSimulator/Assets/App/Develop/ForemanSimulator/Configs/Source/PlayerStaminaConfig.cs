using UnityEngine;

namespace ForemanSimulator.Configs
{
    [CreateAssetMenu(fileName = "PlayerStaminaConfig", menuName = "Scriptable Objects/PlayerStaminaConfig")]
    public class PlayerStaminaConfig : ScriptableObject
    {
        [Tooltip("������������ �������� �������")]
        public float maxStamina = 100f;

        [Tooltip("�������� ���������� ������� ��� ����")]
        public float reduceSpeed = 20f;

        [Tooltip("�������� �������������� �������")]
        public float regenerateSpeed = 15f;

        [Tooltip("����������� �������������� ������� ��� ������")]
        public float walkRegenerateMultiplier = 0.3f;
    }
}
