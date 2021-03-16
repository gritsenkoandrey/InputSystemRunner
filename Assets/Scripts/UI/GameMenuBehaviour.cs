using UnityEngine;
using UnityEngine.UI;

public sealed class GameMenuBehaviour : BaseMenu
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
        Services.Instance.AudioService.PlayMusic(AudioHelper.GetName(AudioType.GameTheme));
    }

    private void PauseButton()
    {
        Services.Instance.GameLevelService.PauseGame();
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