using UnityEngine;
using UnityEngine.UI;

public sealed class MainMenuBehaviour : BaseUI
{
    [SerializeField] private Button _startButtonOrtiz = null;
    [SerializeField] private Button _startButtonElvis = null;
    private GameObject _haveCoins;

    private void Awake()
    {
        _haveCoins = GameObject.FindGameObjectWithTag(TagHelper.GetTag(TypeTag.HaveCoinUI));
    }

    private void OnEnable()
    {
        _startButtonOrtiz.onClick.AddListener(StartButtonOrtiz);
        _startButtonElvis.onClick.AddListener(StartButtonElvis);
    }

    private void OnDisable()
    {
        _startButtonOrtiz.onClick.RemoveListener(StartButtonOrtiz);
        _startButtonElvis.onClick.RemoveListener(StartButtonElvis);
    }

    private void Start()
    {
        isShowedUI = true;
        Services.Instance.AudioService.PlayMusic(AudioName.MAIN_THEME);
        _haveCoins.GetComponent<Text>().text = $"You have: {UserData.LoadMaxCoin()} coins";
    }

    private void StartButtonOrtiz()
    {
        ScreenInterface.GetScreenInterface().Execute(ScreenType.GameMenu);
        Services.Instance.GameLevelService.StartGame(CharacterType.Ortiz);
        Services.Instance.AudioService.StopMusic();
    }

    private void StartButtonElvis()
    {
        ScreenInterface.GetScreenInterface().Execute(ScreenType.GameMenu);
        Services.Instance.GameLevelService.StartGame(CharacterType.Elvis);
        Services.Instance.AudioService.StopMusic();
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