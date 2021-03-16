using UnityEngine;
using UnityEngine.UI;

public sealed class SettingsMenuBehaviour : BaseMenu
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
        Services.Instance.AudioService.PlaySound(AudioHelper.GetName(AudioType.Click));
        ScreenInterface.GetScreenInterface().Execute(ScreenType.MainMenu);
    }

    //todo при переходе на окно main menu нужно обновить доступность персонажей CheckCharacterIsUnlocked
    private void ResetProgress()
    {
        Services.Instance.AudioService.PlaySound(AudioHelper.GetName(AudioType.Reset));
        gameData.CleanData();
        gameData.LoadData();
        Services.Instance.EventService.HaveCoin(gameData.Coins);
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