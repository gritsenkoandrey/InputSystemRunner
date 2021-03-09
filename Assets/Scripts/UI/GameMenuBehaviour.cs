using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public sealed class GameMenuBehaviour : BaseUI
{
    [SerializeField] private Button _restartButton = null;
    [SerializeField] private Button[] _pauseButton = null;

    public bool IsPaused { get; private set; }

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
        IsPaused = false;

        Interface.UIGameMenu.SetActive(true);
        Interface.UIPauseMenu.SetActive(false);
        Interface.UIGameOver.SetActive(false);
    }

    private void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void PauseButton()
    {
        if (IsPaused)
        {
            Interface.UIPauseMenu.SetActive(false);
            Interface.UIGameMenu.SetActive(true);
            IsPaused = !IsPaused;
        }
        else
        {
            Interface.UIPauseMenu.SetActive(true);
            Interface.UIGameMenu.SetActive(false);
            IsPaused = !IsPaused;
        }
    }

    public void ShowGameOver()
    {
        Interface.UIGameMenu.SetActive(false);
        Interface.UIGameOver.SetActive(true);
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