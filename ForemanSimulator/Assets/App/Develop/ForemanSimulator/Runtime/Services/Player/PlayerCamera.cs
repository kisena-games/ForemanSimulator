using Unity.Cinemachine;
using UnityEngine;

public class PlayerCamera
{
    private CinemachineInputAxisController _inputAxisController;

    public PlayerCamera(CinemachineCamera camera)
    {
        _inputAxisController = camera.GetComponent<CinemachineInputAxisController>();
    }

    public void LockRotation(bool isNeedToLock)
    {
        _inputAxisController.enabled = !isNeedToLock;
    }
}
