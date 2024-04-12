using System;
using UnityEngine;

public abstract class BaseState<EState> where EState : Enum
{
    public EState StateKey { get; private set; }
    public EState NextState { get; protected set; }
    public BaseState(EState stateKey)
    {
        StateKey = stateKey;
        NextState = StateKey;
    }

    public abstract EState GetNextState();
    public abstract void CheckSwitchState();
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void LogicUpdate();
    public abstract void PhysicUpdate();
    public abstract void OnTriggerEnter(Collider other);
    public abstract void OnTriggerExit(Collider other);
    public abstract void OnTriggerStay(Collider other);
}
