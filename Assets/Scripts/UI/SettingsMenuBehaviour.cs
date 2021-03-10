using UnityEngine;
using UnityEngine.UI;

public sealed class SettingsMenuBehaviour : BaseUI
{
    [SerializeField] private Button _returnMainMenu = null;
    [SerializeField] private Button _resetProgress = null;

    private void OnEnable()
    {
        _returnMainMenu.onClick.AddListener(ReturnMainMenu);
        _resetProgress.onClick.AddListener(ResetProgress);
    }

    private void OnDisable()
    {
        _returnMainMenu.onClick.RemoveListener(ReturnMainMenu);
        _resetProgress.onClick.RemoveListener(ResetProgress);
    }

    private void ReturnMainMenu()
    {
        ScreenInterface.GetScreenInterface().Execute(ScreenType.MainMenu);
    }

    private void ResetProgress()
    {
        gameData.CleanData();
        gameData.LoadData();
        Services.Instance.EventService.ShowHaveCoins();
    }

    public override void Hide()
    {
        gameObject.SetActive(false);
    }

    public override void Show()
    {
        gameObject.SetActive(true);
    }
}