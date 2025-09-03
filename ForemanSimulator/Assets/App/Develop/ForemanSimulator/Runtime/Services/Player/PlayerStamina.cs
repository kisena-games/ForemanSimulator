using ForemanSimulator.Configs;
using ForemanSimulator.Runtime.Services.Input;
using System;
using UnityEngine;
using Zenject;

namespace ForemanSimulator.Runtime.Services.Player
{
    public class PlayerStamina
    {
        public event Action<bool> OnEmptyStamina;

        private IInputService _inputService;
        private PlayerStaminaConfig _config;
        private IStaminaRegenerationStrategy _regenerationStrategy;

        private float _currentStamina;
        
        [Inject]
        private void Construct(IInputService inputService, 
            PlayerStaminaConfig config)
        {
            _inputService = inputService;
            _regenerationStrategy = new DefaultStaminaRegenerationStrategy(config.walkRegenerateMultiplier);
            _config = config;

            _currentStamina = _config.maxStamina;
        }

        public void Update()
        {
            //Debug.Log(string.Format("_currentStamina = {0}", _currentStamina));

            CalculateStamina();
        }

        private void CalculateStamina()
        {
            bool isSprinting = _inputService.IsSprint;
            bool isMoving = _inputService.NormalizedAxis != Vector2.zero;

            if (isSprinting && isMoving)
            {
                float reduceValue = _config.reduceSpeed * Time.deltaTime;
                _currentStamina = Mathf.Max(_currentStamina - reduceValue, 0f);

                if (_currentStamina == 0)
                {
                    OnEmptyStamina?.Invoke(true);
                }
            }
            else
            {
                if (_currentStamina == 0)
                {
                    OnEmptyStamina?.Invoke(false);
                }

                float regenMultiplier = _regenerationStrategy.GetRegenerationMultiplier(_inputService);
                float regenerateSpeed = _config.regenerateSpeed * regenMultiplier * Time.deltaTime;
                _currentStamina = Mathf.Min(_currentStamina + regenerateSpeed, _config.maxStamina);
            }
        }
    }
}
