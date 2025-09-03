using System;
using UnityEngine;

namespace ForemanSimulator.Runtime.Services.Input
{
    public interface IInputService
    {
        event Action OnJumpAction;
        event Action OnUseAction;
        event Action OnAlternativeUseAction;
        event Action OnInteractAction;
        event Action OnMainInventoryAction;

        Vector2 NormalizedAxis { get; }
        bool IsJump { get; }
        bool IsSprint { get; }

        void Lock(bool isNeedToLock);
    }
}
