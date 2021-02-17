using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class GameMenu : MonoBehaviour
{
    private InputMaster _inputMaster;

    [SerializeField] private Button _pauseButton = null;

    private void Awake()
    {
        _inputMaster = new InputMaster();

        _inputMaster.Player.Touch.performed += ClickButton;
    }

    private void ClickButton(InputAction.CallbackContext context)
    {
        _pauseButton.onClick.AddListener(Pause);
    }

    private void OnEnable()
    {
        _inputMaster.Enable();
    }

    private void OnDisable()
    {
        _inputMaster.Disable();
    }

    private void Pause()
    {
        Debug.Log("Pause");
    }
}