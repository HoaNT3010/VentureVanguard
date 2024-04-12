using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
public class PlayerStateManager : BaseStateManager<PlayerStateManager.PlayerState>
{
    public enum PlayerState
    {
        Idle,
        Walk,
        Run,
        Attack,
        Death,
        Teleport,
    }

    private PlayerContext context;

    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 1.0f;
    [SerializeField] private float runSpeed = 2.0f;
    [Header("Teleport Settings")]
    [SerializeField] private float teleportCooldown = 3.0f;

    private void Awake()
    {
        InitializeComponents();
        InitializeContext();
        InitializeStates();
    }

    public override void InitializeStates()
    {
        States.Add(PlayerState.Idle, new PlayerIdleState(context, PlayerState.Idle));
        States.Add(PlayerState.Walk, new PlayerWalkState(context, PlayerState.Walk));
        States.Add(PlayerState.Run, new PlayerRunState(context, PlayerState.Run));
        States.Add(PlayerState.Attack, new PlayerAttackState(context, PlayerState.Attack));
        States.Add(PlayerState.Death, new PlayerDeathState(context, PlayerState.Death));

        CurrentState = States[PlayerState.Idle];
    }

    private void InitializeComponents()
    {

    }

    private void InitializeContext()
    {
        context = new PlayerContext();
        context.Rigidbody2D = GetComponent<Rigidbody2D>();
        context.Collider2D = GetComponent<BoxCollider2D>();
        context.Animator = GetComponent<Animator>();
        context.PlayerController = GetComponent<PlayerController>();
        context.PlayerTransform = gameObject.transform;
        context.WalkSpeed = walkSpeed;
        context.RunSpeed = runSpeed;
        context.TeleportCooldown = teleportCooldown;
    }
}
