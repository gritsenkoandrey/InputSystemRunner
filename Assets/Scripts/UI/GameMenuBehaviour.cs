using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public sealed class GameMenuBehaviour : BaseUI
{
    [SerializeField] private Button _restartButton = null;
    [SerializeField] private Button[] _pauseButton = null;

    private GameObject _gameOverUI;
    private GameObject _pauseMenuUI;
    private GameObject _gameMenuUI;

    public bool IsPaused { get; private set; }

    private void Awake()
    {
        _gameMenuUI = GameObject.FindGameObjectWithTag(TagHelper.GetTag(TypeTag.GameMenuUI));
        _gameOverUI = GameObject.FindGameObjectWithTag(TagHelper.GetTag(TypeTag.GameOverUI));
        _pauseMenuUI = GameObject.FindGameObjectWithTag(TagHelper.GetTag(TypeTag.PauseMenuUI));
    }

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(RestartButton);
        _pauseButton[0].onClick.AddListener(PauseButton);
        _pauseButton[1].onClick.AddListener(PauseButton);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(RestartButton);
        _pauseButton[0].onClick.RemoveListener(PauseButton);
        _pauseButton[1].onClick.RemoveListener(PauseButton);
    }

    private void Start()
    {
        IsShowedUI = false;
        IsPaused = false;

        Services.Instance.AudioService.PlayMusic(AudioHelper.GetName(AudioType.GameTheme));
        _gameMenuUI.SetActive(true);
        _pauseMenuUI.SetActive(false);
        _gameOverUI.SetActive(false);
    }

    private void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void PauseButton()
    {
        if (IsPaused)
        {
            Services.Instance.TimeService.SetTimeScale(1.0f);
            Services.Instance.AudioService.UnPauseMusic();
            _pauseMenuUI.SetActive(false);
            _gameMenuUI.SetActive(true);
            IsPaused = !IsPaused;
        }
        else
        {
            Services.Instance.TimeService.SetTimeScale(0f);
            Services.Instance.AudioService.PauseMusic();
            _pauseMenuUI.SetActive(true);
            _gameMenuUI.SetActive(false);
            IsPaused = !IsPaused;
        }
    }

    public void PressPauseButton()
    {
        if (!IsShowedUI)
        {
            PauseButton();
        }
        else if (_gameOverUI)
        {
            RestartButton();
        }
    }

    public void ShowGameOver()
    {
        IsShowedUI = true;
        Services.Instance.AudioService.PlayMusic(AudioHelper.GetName(AudioType.GameOver));
        _gameMenuUI.SetActive(false);
        _gameOverUI.SetActive(true);
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