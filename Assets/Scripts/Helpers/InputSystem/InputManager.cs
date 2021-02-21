using UnityEngine.InputSystem;

public sealed class InputManager : Singleton<InputManager>
{
    #region InputMaster

    private InputMaster _input;

    #endregion

    #region Delegate

    public delegate void StartMoveEvent(float input);
    public event StartMoveEvent OnStartMove;

    public delegate void StartJumpEvent();
    public event StartJumpEvent OnStartJump;

    #endregion

    #region UnityMethods

    private void Awake()
    {
        _input = new InputMaster();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Start()
    {
        _input.Player.Move.performed += StartMove;
        _input.Player.Jump.performed += StartJump;

        //_input.Player.Move.performed += context => OnStartMove?.Invoke(context.ReadValue<float>());
        //_input.Player.Jump.performed += context => OnStartJump?.Invoke();
    }

    #endregion

    #region Methods

    private void StartMove(InputAction.CallbackContext context)
    {
        OnStartMove?.Invoke(context.ReadValue<float>());
    }

    private void StartJump(InputAction.CallbackContext context)
    {
        OnStartJump?.Invoke();
    }

    #endregion
}