using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputAction inputAction;
    public Vector2 MovementInput { get; private set; }
    public bool IsMovementPressed { get; private set; }
    public bool IsRunPressed { get; private set; }
    public bool IsTeleportPressed { get; private set; }


    private void Awake()
    {
        inputAction = new PlayerInputAction();
    }

    private void OnEnable()
    {
        inputAction.Enable();
        ListenInputEvent();
    }

    private void OnDisable()
    {
        inputAction.Disable();
        UnlistenInputEvent();
    }

    private void ListenInputEvent()
    {
        // Movement
        inputAction.Player.Move.started += OnMovementInput;
        inputAction.Player.Move.performed += OnMovementInput;
        inputAction.Player.Move.canceled += OnMovementInput;

        // Run
        inputAction.Player.Run.started += OnRunInput;
        inputAction.Player.Run.canceled += OnRunInput;

        // Teleport
        inputAction.Player.Teleport.started += OnTeleportInput;
        inputAction.Player.Teleport.canceled += OnTeleportInput;
    }

    private void UnlistenInputEvent()
    {
        // Movement
        inputAction.Player.Move.started -= OnMovementInput;
        inputAction.Player.Move.performed -= OnMovementInput;
        inputAction.Player.Move.canceled -= OnMovementInput;

        // Run
        inputAction.Player.Run.started -= OnRunInput;
        inputAction.Player.Run.canceled -= OnRunInput;

        // Teleport
        inputAction.Player.Teleport.started -= OnTeleportInput;
        inputAction.Player.Teleport.canceled -= OnTeleportInput;
    }

    private void OnMovementInput(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
        IsMovementPressed = MovementInput.x != 0 || MovementInput.y != 0;
    }

    private void OnRunInput(InputAction.CallbackContext context)
    {
        IsRunPressed = context.ReadValueAsButton();
    }

    private void OnTeleportInput(InputAction.CallbackContext context)
    {
        IsTeleportPressed = context.ReadValueAsButton();
    }
}
