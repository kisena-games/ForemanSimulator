using ForemanSimulator.Runtime.Services.Input;
using UnityEngine;

public class DefaultStaminaRegenerationStrategy : IStaminaRegenerationStrategy
{
    private const float STAY_REGENERATE_MULTUPLIER = 1f;
    private readonly float _walkRegenerateMultiplier;

    public DefaultStaminaRegenerationStrategy(float walkRegenerateMultiplier)
    {
        _walkRegenerateMultiplier = walkRegenerateMultiplier;
    }

    public float GetRegenerationMultiplier(IInputService input)
    {
        if (input.NormalizedAxis != Vector2.zero)
            return _walkRegenerateMultiplier;

        return STAY_REGENERATE_MULTUPLIER;
    }
}
