using UnityEngine;
using UnityEngine.UI;

public sealed class PauseMenuBehaviour : BaseMenu
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
        Services.Instance.GameLevelService.UnpauseGame();
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