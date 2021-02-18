using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//todo временное решение
public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject _gameMenu = null;
    [SerializeField] private GameObject _gameOver = null;

    //private void Start()
    //{
    //    _gameOver.SetActive(false);
    //    Services.Instance.TimeService.SetTimeScale(0f);
    //}

    //private InputMaster _inputMaster;

    //[SerializeField] private Button _pauseButton = null;

    //private void Awake()
    //{
    //    _inputMaster = new InputMaster();

    //    _inputMaster.Player.Touch.performed += ClickButton;
    //}

    //private void ClickButton(InputAction.CallbackContext context)
    //{
    //    _pauseButton.onClick.AddListener(Pause);
    //}

    //private void OnEnable()
    //{
    //    _inputMaster.Enable();
    //}

    //private void OnDisable()
    //{
    //    _inputMaster.Disable();
    //}

    public void StartGame()
    {
        _gameMenu.SetActive(false);
        Services.Instance.TimeService.SetTimeScale(1.0f);
    }

    public void RestartGame()
    {
        Services.Instance.TimeService.SetTimeScale(1.0f);
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        _gameOver.SetActive(true);
        Services.Instance.TimeService.SetTimeScale(0f);
    }
}