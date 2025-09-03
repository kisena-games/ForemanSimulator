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

        public State(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public virtual async UniTask OnEnterAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public virtual async UniTask OnExitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public async UniTask OnUpdate(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    Update();

                    await UniTask.Yield(PlayerLoopTiming.Update, token);
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
