using ForemanSimulator.Runtime.Services.Input;

public interface IStaminaRegenerationStrategy 
{
    float GetRegenerationMultiplier(IInputService input);
}