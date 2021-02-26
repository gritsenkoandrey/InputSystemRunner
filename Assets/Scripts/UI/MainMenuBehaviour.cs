using UnityEngine;
using UnityEngine.UI;

public sealed class MainMenuBehaviour : BaseUI
{
    [SerializeField] private Button _startButtonFatBoy = null;
    [SerializeField] private Button _startButtonElvis = null;
    private GameObject _haveCoins;

    private void Awake()
    {
        _haveCoins = GameObject.FindGameObjectWithTag(TagHelper.GetTag(TypeTag.HaveCoinUI));
    }

    private void OnEnable()
    {
        _startButtonFatBoy.onClick.AddListener(StartButtonFatBoy);
        _startButtonElvis.onClick.AddListener(StartButtonElvis);
    }

    private void OnDisable()
    {
        _startButtonFatBoy.onClick.RemoveListener(StartButtonFatBoy);
        _startButtonElvis.onClick.RemoveListener(StartButtonElvis);
    }

    private void Start()
    {
        isShowedUI = true;

        _haveCoins.GetComponent<Text>().text = $"You have: {UserData.LoadMaxCoin()} coins";
    }

    private void StartButtonFatBoy()
    {
        ScreenInterface.GetScreenInterface().Execute(ScreenType.GameMenu);
        Services.Instance.GameLevelService.StartGame(CharacterType.FatBoy);
    }

    private void StartButtonElvis()
    {
        ScreenInterface.GetScreenInterface().Execute(ScreenType.GameMenu);
        Services.Instance.GameLevelService.StartGame(CharacterType.Elvis);
    }

    public void PauseButton()
    {
        CustomDebug.Log("StartGame");
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