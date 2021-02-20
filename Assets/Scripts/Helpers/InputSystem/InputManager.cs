using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : /*InputSingleton<InputManager>*/ MonoBehaviour
{
    private InputMaster _inputMaster;

    private void Awake()
    {
        _inputMaster = new InputMaster();
    }

    private void OnEnable()
    {
        _inputMaster.Enable();
    }

    private void OnDisable()
    {
        _inputMaster.Disable();
    }

    private void Start()
    {
        _inputMaster.Player.TouchPress.started += context => StartTouch(context);
        _inputMaster.Player.TouchPress.started += context => EndTouch(context);

    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch started " + _inputMaster.Player.TouchPosition.ReadValue<Vector2>());
    }
    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch ended");
    }
}