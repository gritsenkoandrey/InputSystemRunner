using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public sealed class GameMenuBehaviour : BaseUI
{
    [SerializeField] private Button _restartButton = null;

    private GameObject _gameOverUI;
    private GameObject _pauseMenuUI;
    private GameObject _gameMenuUI;

    private bool _isPaused;

    private void Awake()
    {
        _gameMenuUI = GameObject.FindGameObjectWithTag(TagHelper.GetTag(TypeTag.GameMenuUI));
        _gameOverUI = GameObject.FindGameObjectWithTag(TagHelper.GetTag(TypeTag.GameOverUI));
        _pauseMenuUI = GameObject.FindGameObjectWithTag(TagHelper.GetTag(TypeTag.PauseMenuUI));
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
        isShowedUI = false;

        _isPaused = false;

        Services.Instance.AudioService.PlayMusic(AudioName.GAME_THEME);
        _gameMenuUI.SetActive(true);
        _pauseMenuUI.SetActive(false);
        _gameOverUI.SetActive(false);
    }

    private void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseButton()
    {
        if (!isShowedUI)
        {
            if (_isPaused)
            {
                Services.Instance.TimeService.SetTimeScale(1.0f);
                Services.Instance.AudioService.UnPauseMusic();
                _pauseMenuUI.SetActive(false);
                _gameMenuUI.SetActive(true);
                _isPaused = !_isPaused;
            }
            else
            {
                Services.Instance.TimeService.SetTimeScale(0f);
                Services.Instance.AudioService.PauseMusic();
                _pauseMenuUI.SetActive(true);
                _gameMenuUI.SetActive(false);
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
        isShowedUI = true;
        Services.Instance.AudioService.StopMusic();
        Services.Instance.AudioService.PlayMusic(AudioName.GAME_OVER);
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