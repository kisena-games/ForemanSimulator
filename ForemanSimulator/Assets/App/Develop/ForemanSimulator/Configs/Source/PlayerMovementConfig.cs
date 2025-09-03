using UnityEngine;

namespace ForemanSimulator.Configs
{
    [CreateAssetMenu(fileName = "PlayerMovementConfig", menuName = "Scriptable Objects/PlayerMovementConfig")]
    public class PlayerMovementConfig : ScriptableObject
    {
        [Tooltip("�������� ������")]
        public float walkSpeed = 4f;

        [Tooltip("�������� ����")]
        public float sprintSpeed = 7f;

        [Tooltip("������ ������")]
        public float jumpHeight = 2f;

        [Tooltip("���� ���������� (� �������)")]
        public float gravityForce = 2f;
    }
}
