using UnityEngine;

namespace ForemanSimulator.Configs
{
    [CreateAssetMenu(fileName = "PlayerStaminaConfig", menuName = "Scriptable Objects/PlayerStaminaConfig")]
    public class PlayerStaminaConfig : ScriptableObject
    {
        [Tooltip("Максимальное значение стамины")]
        public float maxStamina = 100f;

        [Tooltip("Скорость уменьшения стамины при беге")]
        public float reduceSpeed = 20f;

        [Tooltip("Скорость восстановления стамины")]
        public float regenerateSpeed = 15f;

        [Tooltip("Коэффициент восстановления стамины при ходьбе")]
        public float walkRegenerateMultiplier = 0.3f;
    }
}
