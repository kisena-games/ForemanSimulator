using ForemanSimulator.Runtime.Services.Input;

namespace ForemanSimulator.Runtime.Services.Player
{
    public interface IStaminaRegenerationStrategy
    {
        float GetRegenerationMultiplier(IInputService input);
    }
}