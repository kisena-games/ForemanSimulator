using System;
using Infrastructure.EventBus;
using Infrastructure.EventBus.Signals;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

public class PlayerCamera : IInitializable, IDisposable
{
    private CinemachineCamera _cinemachineCamera;
    private CinemachineInputAxisController _inputAxisController;
    private EventBus _eventBus;
    
    [Inject]
    private void Construct(CinemachineCamera camera, EventBus eventBus)
    {
        _cinemachineCamera = camera;
        _eventBus = eventBus;
    }

    public void Initialize()
    {
        _inputAxisController = _cinemachineCamera.GetComponent<CinemachineInputAxisController>();
        _eventBus.Subscribe<InventoryActionSignal>(LockRotation, 0);
    }
    
    public void LockRotation(InventoryActionSignal signal)
    {
        _inputAxisController.enabled = !signal.NeedToLock;
    }

    public void Dispose()
    {
        _eventBus.Unsubscribe<InventoryActionSignal>(LockRotation);
    }
}
