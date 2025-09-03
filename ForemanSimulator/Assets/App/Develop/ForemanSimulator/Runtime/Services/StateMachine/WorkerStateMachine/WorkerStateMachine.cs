using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace ForemanSimulator.Runtime.Services.StateMachine
{
    public class WorkerStateMachine : StateMachine
    {
        public WorkerStateMachine()
        {
            states = new Dictionary<Type, State>
            {
                //{ typeof(WorkState), new WorkState(this) },
                //{ typeof(CapturedByPlayerState), new CapturedByPlayerState(this) },
                //{ typeof(StunnedState), new StunnedState(this) }
                //{ typeof(DemotivatedState), new DemotivatedState(this) }
            };

            //SetState<WorkState>().Forget();
        }
    }
}
