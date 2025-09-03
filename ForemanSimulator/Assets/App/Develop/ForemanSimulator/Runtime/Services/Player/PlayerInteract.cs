using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace ForemanSimulator.Runtime.Services.Player
{
    public class PlayerInteract
    {
        private readonly Vector3 _screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);

        private Camera _playerCamera;
        private LayerMask _interactMask;
        private const float _rayDistance = 3f;
        
        [Inject]
        private void Construct(Camera playerCamera, LayerMask interactMask)
        {
            _playerCamera = playerCamera;
            _interactMask = interactMask;
        }

        public void Interact()
        {
            Ray ray = _playerCamera.ScreenPointToRay(_screenCenter);
            RaycastHit[] hits = new RaycastHit[1];

            if (Physics.RaycastNonAlloc(ray, hits, _rayDistance, _interactMask) > 0)
            {
                RaycastHit hit = hits[0];
                Debug.Log(string.Format("Interact with {0}", hit.collider.gameObject.name));
            }
        }
    }
}
