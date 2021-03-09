using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuBehaviour : BaseUI
{
    [SerializeField] private Button _restartButton = null;
    [SerializeField] private Button[] _pauseButton = null;

    public bool IsPaused { get; private set; }

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(RestartButton);
        _pauseButton[0].onClick.AddListener(PauseButton);
        _pauseButton[1].onClick.AddListener(PauseButton);
        Services.Instance.EventService.OnShowGameOverMenu += ShowGameOverMenu;
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(RestartButton);
        _pauseButton[0].onClick.RemoveListener(PauseButton);
        _pauseButton[1].onClick.RemoveListener(PauseButton);
        Services.Instance.EventService.OnShowGameOverMenu -= ShowGameOverMenu;
    }

    private void Start()
    {
        IsPaused = false;

        uInterface.UIGameMenu.SetActive(true);
        uInterface.UIPauseMenu.SetActive(false);
        uInterface.UIGameOver.SetActive(false);
    }

    private void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void PauseButton()
    {
        if (IsPaused)
        {
            uInterface.UIPauseMenu.SetActive(false);
            uInterface.UIGameMenu.SetActive(true);
            IsPaused = !IsPaused;
        }
        else
        {
            uInterface.UIPauseMenu.SetActive(true);
            uInterface.UIGameMenu.SetActive(false);
            IsPaused = !IsPaused;
        }
    }

    private void ShowGameOverMenu()
    {
        uInterface.UIGameMenu.SetActive(false);
        uInterface.UIGameOver.SetActive(true);
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