using UnityEngine;

public class PlayerWalkState : PlayerState
{
    public PlayerWalkState(PlayerContext context, PlayerStateManager.PlayerState stateKey) : base(context, stateKey)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        Context.Animator.Play(Context.WalkHash);
    }

    public override void CheckSwitchState()
    {
        if (!Context.PlayerController.IsMovementPressed)
        {
            NextState = PlayerStateManager.PlayerState.Idle;
        }
        else if (Context.PlayerController.IsMovementPressed && Context.PlayerController.IsRunPressed)
        {
            NextState = PlayerStateManager.PlayerState.Run;
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        Vector2 baseVelocity = new Vector2(Context.PlayerController.MovementInput.x, Context.PlayerController.MovementInput.y);
        Context.Rigidbody2D.velocity = baseVelocity * Context.WalkSpeed;
    }
}
