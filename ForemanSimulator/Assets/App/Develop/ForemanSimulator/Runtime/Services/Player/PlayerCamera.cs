using Unity.Cinemachine;
using UnityEngine;
using Zenject;

public class PlayerCamera : IInitializable
{
    private CinemachineCamera _cinemachineCamera;
    private CinemachineInputAxisController _inputAxisController;

    [Inject]
    private void Construct(CinemachineCamera camera)
    {
        _cinemachineCamera = camera;
    }

    public void Initialize()
    {
        _inputAxisController = _cinemachineCamera.GetComponent<CinemachineInputAxisController>();
    }
    
    public void LockRotation(bool isNeedToLock)
    {
        _inputAxisController.enabled = !isNeedToLock;
    }
}
