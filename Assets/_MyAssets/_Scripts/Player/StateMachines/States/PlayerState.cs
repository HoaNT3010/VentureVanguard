using UnityEngine;

public class PlayerState : BaseState<PlayerStateManager.PlayerState>
{
    protected PlayerContext Context;
    public PlayerState(PlayerContext context, PlayerStateManager.PlayerState stateKey) : base(stateKey)
    {
        Context = context;
    }

    public override void CheckSwitchState() { }

    public override void EnterState()
    {
        // Reset NextState key
        NextState = StateKey;
    }

    public override void ExitState() { }

    public override PlayerStateManager.PlayerState GetNextState()
    {
        return NextState;
    }

    public override void LogicUpdate()
    {
        CheckSwitchState();
        HandleAnimation();
        CheckFlipCharacter();
    }

    public override void PhysicUpdate() { }

    public override void OnTriggerEnter(Collider other) { }

    public override void OnTriggerExit(Collider other) { }

    public override void OnTriggerStay(Collider other) { }

    public virtual void HandleAnimation() { }

    public virtual void CheckFlipCharacter()
    {
        // Flip Right
        if(Context.PlayerController.MovementInput.x > 0 && !Context.IsFacingRight)
        {
            Context.IsFacingRight = true;
            FlipCharacter();
        }
        // Flip Left
        else if (Context.PlayerController.MovementInput.x < 0 && Context.IsFacingRight)
        {
            Context.IsFacingRight = false;
            FlipCharacter();
        }
    }

    private void FlipCharacter()
    {
        Vector3 newScale = Context.PlayerTransform.localScale;
        newScale.x *= -1;
        Context.PlayerTransform.localScale = newScale;
    }
}
