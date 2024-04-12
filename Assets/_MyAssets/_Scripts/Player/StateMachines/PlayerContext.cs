using UnityEngine;

public class PlayerContext
{
    // Components
    public Rigidbody2D Rigidbody2D { get; set; }
    public BoxCollider2D Collider2D { get; set; }
    public Animator Animator { get; set; }
    public PlayerController PlayerController { get; set; }
    public Transform PlayerTransform { get; set; }

    // Movement Settings
    public float WalkSpeed { get; set; }
    public float RunSpeed { get; set; }

    // Teleport Settings
    public float TeleportCooldown { get; set; }

    // Animator's State Name Hash
    public readonly int IdleHash = Animator.StringToHash("Idle");
    public readonly int BlinkHash = Animator.StringToHash("Idle_blink");
    public readonly int WalkHash = Animator.StringToHash("Walk");
    public readonly int RunHash = Animator.StringToHash("Run");
    public readonly int TeleportStartHash = Animator.StringToHash("Teleport_start");
    public readonly int TeleportEndHash = Animator.StringToHash("Teleport_end");

    // Flags
    public bool IsFacingRight = true;
    public bool CanTeleport = true;
}
