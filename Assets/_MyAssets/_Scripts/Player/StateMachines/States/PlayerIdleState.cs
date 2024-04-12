using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(PlayerContext context, PlayerStateManager.PlayerState stateKey) : base(context, stateKey)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        Context.Animator.Play(Context.IdleHash);
        Context.Rigidbody2D.velocity = Vector2.zero;
    }

    public override void CheckSwitchState()
    {
        if (Context.PlayerController.IsMovementPressed && Context.PlayerController.IsRunPressed)
        {
            NextState = PlayerStateManager.PlayerState.Run;
        }
        else if (Context.PlayerController.IsMovementPressed)
        {
            NextState = PlayerStateManager.PlayerState.Walk;
        }
    }

}
