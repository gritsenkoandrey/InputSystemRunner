using UnityEngine;
using UnityEngine.UI;

public sealed class MainMenuBehaviour : BaseUI
{
    private GameObject _haveCoins;
    [SerializeField] private Button _startButton = null;

    private void Awake()
    {
        _haveCoins = GameObject.FindGameObjectWithTag(TagHelper.GetTag(TypeTag.HAVECOINS));
    }

    private void OnEnable()
    {
        _startButton.onClick.AddListener(StartButton);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(StartButton);
    }

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        isShowedUI = true;

        _haveCoins.GetComponent<Text>().text = $"You have: {UserData.LoadMaxCoin()} coins";
        Services.Instance.TimeService.SetTimeScale(0f);
    }

    private void StartButton()
    {
        ScreenInterface.GetScreenInterface().Execute(ScreenType.GameMenu);
        EventBus.RaiseEvent<IStartGame>(h => h.StartGame());
    }

    public void PauseButton()
    {
        StartButton();
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