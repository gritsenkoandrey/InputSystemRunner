using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public sealed class GameMenuBehaviour : BaseMenu
{
    [SerializeField] private Button _restartButton = null;

    private GameObject _gameOverUI;
    private GameObject _pauseMenuUI;

    private bool _isPaused;

    private void Awake()
    {
        _gameOverUI = GameObject.FindGameObjectWithTag(TagHelper.GetTag(TypeTag.GAMEOVERUI));
        _pauseMenuUI = GameObject.FindGameObjectWithTag(TagHelper.GetTag(TypeTag.PAUSEMENUUI));
    }

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(RestartButton);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(RestartButton);
    }

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        isShowedMenu = false;

        _isPaused = false;
        _pauseMenuUI.SetActive(false);
        _gameOverUI.SetActive(false);
        Services.Instance.TimeService.SetTimeScale(1.0f);
    }

    private void RestartButton()
    {
        Services.Instance.TimeService.SetTimeScale(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseButton()
    {
        if (!isShowedMenu)
        {
            if (_isPaused)
            {
                Services.Instance.TimeService.SetTimeScale(1.0f);
                _pauseMenuUI.SetActive(false);
                _isPaused = !_isPaused;
            }
            else
            {
                Services.Instance.TimeService.SetTimeScale(0f);
                _pauseMenuUI.SetActive(true);
                _isPaused = !_isPaused;
            }
        }
        else if (_gameOverUI)
        {
            RestartButton();
        }
    }

    public void ShowGameOver()
    {
        isShowedMenu = true;

        _gameOverUI.SetActive(true);
        Services.Instance.TimeService.SetTimeScale(0f);
    }

    public override void Show()
    {
        gameObject.SetActive(true);
    }

    public override void Hide()
    {
        gameObject.SetActive(false);
    }
}