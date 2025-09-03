using ForemanSimulator.Runtime.Game.Player;
using UnityEngine;
using Zenject;

namespace ForemanSimulator.Infrastructure
{
    public class TestInstaller : MonoInstaller
    {
        [SerializeField] private Player _playerPrefab;

        public override void InstallBindings()
        {
            
        }

        public override void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
