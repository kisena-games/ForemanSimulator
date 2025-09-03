using UnityEngine;

namespace ForemanSimulator.Configs
{
    [CreateAssetMenu(fileName = "PlayerMovementConfig", menuName = "Scriptable Objects/PlayerMovementConfig")]
    public class PlayerMovementConfig : ScriptableObject
    {
        [Tooltip("Скорость ходьбы")]
        public float walkSpeed = 4f;

        [Tooltip("Скорость бега")]
        public float sprintSpeed = 7f;

        [Tooltip("Высота прыжка")]
        public float jumpHeight = 2f;

        [Tooltip("Сила гравитации (с минусом)")]
        public float gravityForce = 2f;
    }
}
