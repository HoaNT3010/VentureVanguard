using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStateManager<EState> : MonoBehaviour where EState : Enum
{
    protected Dictionary<EState, BaseState<EState>> States = new Dictionary<EState, BaseState<EState>>();
    protected BaseState<EState> CurrentState;
    protected bool IsTransitioningState = false;

    private void Start()
    {
        CurrentState.EnterState();
    }

    private void Update()
    {
        EState nextState = CurrentState.GetNextState();
        // Next state is equal to current state and not transitioning.
        if (nextState.Equals(CurrentState.StateKey) && !IsTransitioningState)
        {
            CurrentState.LogicUpdate();
        }
        // Current state changed but not transition yet.
        else if (!IsTransitioningState)
        {
            TransitionToState(nextState);
        }
    }

    private void FixedUpdate()
    {
        EState nextState = CurrentState.GetNextState();
        // Execute physic update only next state is equal to current state and not transitioning.
        if (nextState.Equals(CurrentState.StateKey) && !IsTransitioningState)
        {
            CurrentState.PhysicUpdate();
        }
    }

    public abstract void InitializeStates();

    public void TransitionToState(EState stateKey)
    {
        IsTransitioningState = true;
        CurrentState.ExitState();
        CurrentState = States[stateKey];
        CurrentState.EnterState();
        IsTransitioningState = false;
    }

    void OnTriggerEnter(Collider other)
    {
        CurrentState.OnTriggerEnter(other);
    }

    void OnTriggerStay(Collider other)
    {
        CurrentState.OnTriggerStay(other);
    }

    void OnTriggerExit(Collider other)
    {
        CurrentState.OnTriggerExit(other);
    }
}
