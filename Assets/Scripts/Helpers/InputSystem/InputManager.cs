using UnityEngine;

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

    public delegate void StartPauseEvent();
    public event StartPauseEvent OnStartPause;

    public delegate void StartTouch(Vector2 pos, float time);
    public event StartTouch OnStartTouch;

    public delegate void EndTouch(Vector2 pos, float time);
    public event EndTouch OnEndTouch;

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
        _input.Player.Move.performed += context => OnStartMove?.Invoke(context.ReadValue<float>());
        _input.Player.Jump.performed += context => OnStartJump?.Invoke();
        _input.Player.Pause.performed += context => OnStartPause?.Invoke();

        _input.Player.PrimaryContact.started += context =>
            OnStartTouch?.Invoke(_input.Player.PrimaryPosition.ReadValue<Vector2>(), (float)context.startTime);
        _input.Player.PrimaryContact.canceled += context =>
            OnEndTouch?.Invoke(_input.Player.PrimaryPosition.ReadValue<Vector2>(), (float)context.time);
    }

    #endregion
}