using UnityEngine;

public class PlayerTeleportState : PlayerState
{
    public PlayerTeleportState(PlayerContext context, PlayerStateManager.PlayerState stateKey) : base(context, stateKey)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        Context.Animator.Play(Context.TeleportStartHash);
        PerformTeleport();
    }

    private void PerformTeleport()
    {

    }
}
