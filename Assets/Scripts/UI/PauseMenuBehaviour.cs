using UnityEngine;
using UnityEngine.UI;

public sealed class PauseMenuBehaviour : BaseUI
{
    [SerializeField] private Button _pauseButton = null;

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(PauseButton);
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(PauseButton);
    }

    private void PauseButton()
    {
        Services.Instance.GameLevelService.UnPauseGame();
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