using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

namespace ForemanSimulator.Runtime.Services.StateMachine
{
    public abstract class State
    {
        protected readonly StateMachine _stateMachine;

        private CancellationTokenSource _cts;

        public State(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public virtual async UniTask OnEnterAsync(CancellationToken token)
        {
            await UniTask.Yield(token);

            _cts = new CancellationTokenSource();
        }

        public virtual async UniTask OnExitAsync(CancellationToken token)
        {
            if (_cts != null)
            {
                _cts.Cancel();
                _cts.Dispose();
                _cts = null;
            }

            await UniTask.Yield(token);
        }

        public async UniTask OnUpdate()
        {
            try
            {
                while (!_cts.IsCancellationRequested)
                {
                    Update();

                    await UniTask.Yield(PlayerLoopTiming.Update, _cts.Token);
                }
            }
            catch (OperationCanceledException){ }
            catch (Exception ex)
            {
                throw new Exception("Error in State Update", ex);
            }
        }

        protected abstract void Update();
    }
}
