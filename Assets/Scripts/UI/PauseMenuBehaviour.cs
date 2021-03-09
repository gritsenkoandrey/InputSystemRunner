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

    private void Start()
    {
        Services.Instance.AudioService.PauseMusic();
        Services.Instance.TimeService.SetTimeScale(0f);
    }

    private void PauseButton()
    {
        Services.Instance.AudioService.UnPauseMusic();
        Services.Instance.TimeService.SetTimeScale(1.0f);
        ScreenInterface.GetScreenInterface().Execute(ScreenType.GameMenu);
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